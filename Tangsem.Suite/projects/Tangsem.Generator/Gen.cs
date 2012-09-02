using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using RazorGenerator.Templating;

using Tangsem.Generator.Metadata;
using Tangsem.Generator.Metadata.Builder;
using Tangsem.Generator.Settings;
using Tangsem.Generator.Templates.Entities;
using Tangsem.Generator.Templates.Repositories;

namespace Tangsem.Generator
{
  public class Gen
  {
    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="config">The GeneratorConfiguration instance.</param>
    public Gen(GeneratorConfiguration config)
    {
      this.GeneratorConfiguration = config;
    }

    /// <summary>
    /// The GeneratorConfiguration instance.
    /// </summary>
    public GeneratorConfiguration GeneratorConfiguration { get; private set; }

    /// <summary>
    /// The metadata builder.
    /// </summary>
    public MetadataBuilder MetadataBuilder { get; private set; }


    public void Run()
    {
      this.Log("START RUNNING...");
      this.MetadataBuilder = this.GeneratorConfiguration.CreateMetadataBuilder();
      this.MetadataBuilder.Build();
      this.Log("MetadataBuilder.Build() finished.");


      var tableMetadatas = this.MetadataBuilder
                  .CachedTableMetadata
                  .Values
                  .Where(x => !this.GeneratorConfiguration.IgnoredTables.Any(y => x.Name.Equals(y, StringComparison.CurrentCultureIgnoreCase)))
                  .ToList();
      var pairs = string.Join(",", tableMetadatas.Select(x => string.Format("[{0}:{1}]", x.Name, x.EntityName)));
      this.Log("List of Metadata to generate code from", pairs);

      this.Log("Code generation based on single metadata", "Started..");
      this.GenerateForSingleMetadataTemplate(tableMetadatas);
      this.Log("Code generation based on single metadata", "Finished");

      this.Log("Code generation based on multiple metadata", "Started..");
      this.GenerateForMultipleMetadataTemplates(tableMetadatas);
      this.Log("Code generation based on multiple metadata", "Finished");

      if (this.GeneratorConfiguration.OpenOutputDirAfterGeneration)
      {
        Log("Openning Directory", this.GeneratorConfiguration.ProjectDirPath);
        Process.Start(this.GeneratorConfiguration.ProjectDirPath);
      }
    }

    private void GenerateForMultipleMetadataTemplates(List<TableMetadata> tableMetadatas)
    {
      string code;
      string path;
      RazorTemplateBase template = null;

      template = new Repository_Designer { Configuration = this.GeneratorConfiguration, TableMetadatas = tableMetadatas };
      code = template.TransformText().Trim();
      path = this.GeneratorConfiguration.IRepositoriesDirPath + "/" + this.GeneratorConfiguration.OrmType.AsNamespacePart() +  "/" + this.GeneratorConfiguration.RepositoryName +
             ".Designer.cs";
      File.WriteAllText(path, code);
      this.Log("Saved", path);

      template = new IRepository_Designer { Configuration = this.GeneratorConfiguration, TableMetadatas = tableMetadatas };
      code = template.TransformText().Trim();
      path = this.GeneratorConfiguration.IRepositoriesDirPath + "/I" + this.GeneratorConfiguration.RepositoryName +
             ".Designer.cs";
      File.WriteAllText(path, code);
      this.Log("Saved", path);
    }

    private void GenerateForSingleMetadataTemplate(List<TableMetadata> tableMetadatas)
    {
      foreach (var tableMetadata in tableMetadatas)
      {
        var pocoTemplate = new Poco_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };

        var entityCode = pocoTemplate.TransformText().Trim();
        var entityDesignerFilePath = this.GeneratorConfiguration.EntitiesDirPath + "/" + tableMetadata.EntityName + ".Designer.cs";
        File.WriteAllText(entityDesignerFilePath, entityCode);
        this.Log("Saved", entityDesignerFilePath);

        if (this.GeneratorConfiguration.OrmType == OrmTypes.NHibernate)
        {
          var mappingTemplate = new Poco_NHibernate_Fluent_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };
          var mappingCode = mappingTemplate.TransformText().Trim();
          var entityMappingDesignerFilePath = this.GeneratorConfiguration.MappingDirPath + "/" + tableMetadata.EntityName + "Map.Designer.cs";
          File.WriteAllText(entityMappingDesignerFilePath, mappingCode);
          this.Log("Saved", entityMappingDesignerFilePath);
        }
        else
        {
          var mappingTemplate = new Poco_EF_Fluent_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };
          var mappingCode = mappingTemplate.TransformText().Trim();
          var entityMappingDesignerFilePath = this.GeneratorConfiguration.MappingDirPath + "/" + tableMetadata.EntityName + "Map.Designer.cs";
          File.WriteAllText(entityMappingDesignerFilePath, mappingCode);
          this.Log("Saved", entityMappingDesignerFilePath);
        }




        var dtoTemplate = new Poco_DTO_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };
        var dtoCode = dtoTemplate.TransformText().Trim();
        var dtoDesignerFilePath = this.GeneratorConfiguration.DTODirPath + "/" + tableMetadata.EntityName + "DTO.Designer.cs";
        File.WriteAllText(dtoDesignerFilePath, dtoCode);
        this.Log("Saved", dtoDesignerFilePath);
      }
    }

    private void Log(string title, string message = "")
    {
      Console.WriteLine("[{0}] <{1}>:{2}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), title, message);
    }
  }
}
