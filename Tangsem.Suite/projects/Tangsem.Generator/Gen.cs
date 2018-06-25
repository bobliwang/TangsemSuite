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
using Tangsem.Generator.Templates;
using Tangsem.Generator.Templates.Angular;
using Tangsem.Generator.Templates.Entities;
using Tangsem.Generator.Templates.MVC.AutoMapper;
using Tangsem.Generator.Templates.MVC.Controllers;
using Tangsem.Generator.Templates.MVC.ViewModels;
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
                  .Where(x => this.GeneratorConfiguration.IncludeTables == null
                              || !this.GeneratorConfiguration.IncludeTables.Any()
                              || this.GeneratorConfiguration.IncludeTables.Any(it => it.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase)))
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
        this.Log("Openning Directory", this.GeneratorConfiguration.ProjectDirPath);
        Process.Start(this.GeneratorConfiguration.ProjectDirPath);
      }
    }

    private void GenerateForMultipleMetadataTemplates(List<TableMetadata> tableMetadatas)
    {
      var templates = new ITemplateBase[]
      {
        new RepositoryClassTemplate(this.GeneratorConfiguration, tableMetadatas),
        new RepositoryInterfaceTemplate(this.GeneratorConfiguration, tableMetadatas),

        new NgApiService (this.GeneratorConfiguration, tableMetadatas ),
        new NgModels(this.GeneratorConfiguration, tableMetadatas ),
        new PocoModelAutoMapperConfigurationTemplate(this.GeneratorConfiguration, tableMetadatas),
      };

      this.ExecuteTemplates(templates);


      this.SaveConfigFile();
    }

    private void GenerateForSingleMetadataTemplate(List<TableMetadata> tableMetadatas)
    {
      foreach (var tableMetadata in tableMetadatas)
      {
        var templates = new ITemplateBase[]
        {
          // Poco Entity
          new PocoTemplate(this.GeneratorConfiguration, tableMetadata),

          // Entity Mapping
          this.GeneratorConfiguration.OrmType == OrmTypes.NHibernate ?
            (ITemplateBase) new NHibernateFluentTemplate(this.GeneratorConfiguration, tableMetadata)
            : new EntityFxFluentTemplate(this.GeneratorConfiguration, tableMetadata),

          // PocoDTO
          new PocoDTOTemplate(this.GeneratorConfiguration, tableMetadata),
          new PocoModelAutoMapperProfileTemplate(this.GeneratorConfiguration, tableMetadata),
          new ApiControllerTemplate(this.GeneratorConfiguration, tableMetadata),
          new SearchParamTemplate(this.GeneratorConfiguration, tableMetadata),

          // ng listing
          new NgListingComponent(this.GeneratorConfiguration, tableMetadata),
          new NgListingComponentHtml(this.GeneratorConfiguration, tableMetadata),
          new NgFilterComponent(this.GeneratorConfiguration, tableMetadata),
          new NgFilterComponentHtml(this.GeneratorConfiguration, tableMetadata)
        };

        this.ExecuteTemplates(templates);
      }
    }

    private void ExecuteTemplates(ITemplateBase[] templates)
    {
      foreach (var template in templates)
      {
        var code = template.TransformText().Trim();
        var path = template.GetPathToSave(this.GeneratorConfiguration);

        var file = new FileInfo(path);
        if (!file.Directory.Exists)
        {
          Directory.CreateDirectory(file.Directory.FullName);
        }

        File.WriteAllText(path, code);
        this.Log("Saved", path);
      }
    }

    private void SaveConfigFile()
    {
      // save the generator config xml too.
      var configPath = this.GeneratorConfiguration.IRepositoriesDirPath + "/" + this.GeneratorConfiguration.RepositoryName
                       + ".xml";
      File.WriteAllText(configPath, File.ReadAllText(this.GeneratorConfiguration.ConfigFilePath));
      this.Log("Saved", configPath);
    }

    private void Log(string title, string message = "")
    {
      Console.WriteLine("[{0}] <{1}>:{2}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), title, message);
    }
  }
}
