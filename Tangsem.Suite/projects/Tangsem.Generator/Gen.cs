using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

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
using Tangsem.Generator.Templates.StoredProc;

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
    public GeneratorConfiguration GeneratorConfiguration { get; }

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


      var pairs = string.Join(",", tableMetadatas.Select(x => $"[{x.Name}:{x.EntityName}]"));
      this.Log("List of Metadata to generate code from", pairs);

      this.Log("Code generation based on single metadata", "Started..");
      this.GenerateForSingleMetadataTemplate(tableMetadatas);
      this.Log("Code generation based on single metadata", "Finished");

      this.Log("Code generation based on multiple metadata", "Started..");
      this.GenerateForMultipleMetadataTemplates(tableMetadatas);
      this.Log("Code generation based on multiple metadata", "Finished");

      if (this.GeneratorConfiguration.OpenOutputDirAfterGeneration)
      {
        try
        {
          this.Log("Openning Directory", this.GeneratorConfiguration.ProjectDirPath);
          Process.Start(this.GeneratorConfiguration.ProjectDirPath);
        }
        catch
        {
          this.Log("Unable to open folder: " + this.GeneratorConfiguration.ProjectDirPath);
        }
      }
    }

    private void GenerateForMultipleMetadataTemplates(List<TableMetadata> tableMetadatas)
    {
      var templates = new List<ITemplateBase>();

      templates.Add(new RepositoryClassTemplate(this.GeneratorConfiguration, tableMetadatas));
      templates.Add(new RepositoryInterfaceTemplate(this.GeneratorConfiguration, tableMetadatas));
      
      if (this.GeneratorConfiguration.GenAutoMapper)
      {
        templates.Add(new PocoModelAutoMapperConfigurationTemplate(this.GeneratorConfiguration, tableMetadatas));
      }

      if (this.GeneratorConfiguration.GenNgApp)
      {
        templates.Add(new NgApiService(this.GeneratorConfiguration, tableMetadatas));
        templates.Add(new NgModels(this.GeneratorConfiguration, tableMetadatas));

        templates.Add(new NgModule(this.GeneratorConfiguration, tableMetadatas));
        templates.Add(new NgRoutingModule(this.GeneratorConfiguration, tableMetadatas));
      }

      if (this.GeneratorConfiguration.GenStoredProc)
      {
        templates.Add(new StoredProc(this.GeneratorConfiguration, tableMetadatas));
      }

      this.ExecuteTemplates(templates.ToArray());
      
      this.SaveConfigFile();
    }

    private void GenerateForSingleMetadataTemplate(List<TableMetadata> tableMetadatas)
    {
      foreach (var tableMetadata in tableMetadatas)
      {
        var templates = new List<ISingleTableMetadataTemplate>();

        // Poco Entity
        templates.Add(new PocoTemplate(this.GeneratorConfiguration, tableMetadata));

        var mappingGen = new PocoNHibernateFluentTemplate(this.GeneratorConfiguration, tableMetadata)
                           {
                             TableNameInMapping = tblName =>
                               {
                                 var openQ = this.GeneratorConfiguration.TableNameOpenQuote;
                                 var closeQ = this.GeneratorConfiguration.TableNameCloseQuote;

                                 return $"{openQ}{tblName}{closeQ}";
                               }
                           };
        // Entity Mapping
        templates.Add(mappingGen);

        // PocoDTO
        templates.Add(new PocoDTOTemplate(this.GeneratorConfiguration, tableMetadata));

        if (this.GeneratorConfiguration.GenAspNetController)
        {
          templates.Add(new ApiControllerBaseTemplate(this.GeneratorConfiguration, tableMetadata));
          templates.Add(new ApiControllerTemplate(this.GeneratorConfiguration, tableMetadata));
          templates.Add(new SearchParamTemplate(this.GeneratorConfiguration, tableMetadata));
        }

        // ng listing
        if (this.GeneratorConfiguration.GenNgApp)
        {
          templates.Add(new NgListingComponent(this.GeneratorConfiguration, tableMetadata));
          templates.Add(new NgListingComponentHtml(this.GeneratorConfiguration, tableMetadata));
          templates.Add(new NgFilterComponent(this.GeneratorConfiguration, tableMetadata));
          templates.Add(new NgFilterComponentHtml(this.GeneratorConfiguration, tableMetadata));

          templates.Add(new NgEditorComponent(this.GeneratorConfiguration, tableMetadata));
          templates.Add(new NgEditorComponentHtml(this.GeneratorConfiguration, tableMetadata));
        }

        // poco dto mapping.
        if (this.GeneratorConfiguration.GenAutoMapper)
        {
          templates.Add(new PocoModelAutoMapperProfileTemplate(this.GeneratorConfiguration, tableMetadata));
        }

        this.ExecuteTemplates(templates.ToArray());
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
      var sourceConfigFileInfo = new FileInfo(this.GeneratorConfiguration.ConfigFilePath);
      var configPath = $"{this.GeneratorConfiguration.IRepositoriesDirPath}/{this.GeneratorConfiguration.RepositoryName}{sourceConfigFileInfo.Extension}";
      File.WriteAllText(configPath, File.ReadAllText(sourceConfigFileInfo.FullName));
      this.Log("Saved", configPath);
    }

    private void Log(string title, string message = "")
    {
      Console.WriteLine("[{0}] <{1}>:{2}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), title, message);
    }
  }
}
