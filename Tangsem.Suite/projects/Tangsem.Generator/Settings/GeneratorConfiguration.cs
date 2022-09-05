using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Tangsem.Generator.Metadata.Builder;

namespace Tangsem.Generator.Settings
{
  [XmlRoot("GeneratorConfiguration")]
  public class GeneratorConfiguration
  {
    public static GeneratorConfiguration FromFile(string filePath)
    {
      var instance = GeneratorConfiguration.ReadFile(filePath);
      instance.Init();
      instance.ConfigFilePath = filePath;

      return instance;
    }

    private static GeneratorConfiguration ReadFile(string filePath)
    {
      var fileContents = File.ReadAllText(filePath);

      if (filePath.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
      {
        return JsonConvert.DeserializeObject<GeneratorConfiguration>(fileContents);
      }

      var xmlSer = new XmlSerializer(typeof(GeneratorConfiguration));

      return (GeneratorConfiguration)xmlSer.Deserialize(new StringReader(fileContents));
    }

    [XmlIgnore]
    public string ConfigFilePath { get; private set; }

    [XmlAttribute]
    public bool GenRelationship { get; set; }

    [XmlAttribute]
    public bool SupportAsync { get; set; }

    [XmlAttribute]
    public bool UseTimestampInOutputFolder { get; set; }

    /// <summary>
    /// Gets or sets ProjectName.
    /// </summary>
    [XmlAttribute]
    public string ProjectName { get; set; }

    public string RootProjectName => this.ProjectName.Split('.')[0];

    /// <summary>
    /// Gets or sets OutputDir.
    /// </summary>
    [XmlAttribute]
    public string OutputDir { get; set; }

    /// <summary>
    /// Database connection string.
    /// </summary>
    [XmlAttribute]
    public string ConnectionString { get; set; }

    /// <summary>
    /// Gets or sets RepositoryName.
    /// </summary>
    [XmlAttribute]
    public string RepositoryName { get; set; }

    /// <summary>
    /// Gets or sets RepositoryName.
    /// </summary>
    [XmlAttribute]
    public string RepositoryBaseClassName { get; set; }

    /// <summary>
    /// The MeatadataBuilder type name. Format: className[;assemblyName]
    /// </summary>
    [XmlAttribute]
    public string MetadataBuilder { get; set; }

    /// <summary>
    /// Whether to Open OutputDir After Generation or not.
    /// </summary>
    [XmlAttribute]
    public bool OpenOutputDirAfterGeneration { get; set; }

    [XmlAttribute]
    public string OrmFramework { get; set; }

    [XmlAttribute]
    public string TableNameOpenQuote { get; set; } = "[";

    [XmlAttribute]
    public string TableNameCloseQuote { get; set; } = "]";

    public OrmTypes OrmType
    {
      get
      {
        if (string.IsNullOrEmpty(this.OrmFramework))
        {
          // default NHibernate.
          return OrmTypes.NHibernate;
        }

        if (this.OrmFramework.ToLower() == OrmTypes.EntityFramework.ToString().ToLower() || this.OrmFramework.ToLower() == "ef")
        {
          return OrmTypes.EntityFramework;
        }

        return OrmTypes.NHibernate;
      }
    }

    /// <summary>
    /// Tables to ignore.
    /// </summary>
    [XmlElement("IgnoredTable")]
    public List<string> IgnoredTables { get; set; }

    [XmlElement("IncludeTable")]
    public List<string> IncludeTables { get; set; }

    /// <summary>
    /// Project dir path. This property is depending on OutputDir and ProjectName.
    /// </summary>
    public string ProjectDirPath => Path.Combine(this.OutputDir, this.ProjectName);

    /// <summary>
    /// Gets EntitiesDirPath.
    /// </summary>
    public string DomainDirPath => Path.Combine(this.ProjectDirPath, this.DomainNamespace.Substring(this.ProjectName.Length + 1).Replace(".", @"\"));

    /// <summary>
    /// Gets EntitiesDirPath.
    /// </summary>
    public string EntitiesDirPath => Path.Combine(this.DomainDirPath, "Entities");

    /// <summary>
    /// Gets Entity Mappings Dir Path.
    /// </summary>
    public string MappingDirPath => Path.Combine(this.EntitiesDirPath, "Mappings", this.OrmType.AsNamespacePart());

    public string AutoMappingConfigsDirPath => Path.Combine(this.EntitiesDirPath, "Mappings", "AutoMapper");

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string DTODirPath => Path.Combine(this.EntitiesDirPath, "DTOs");

    public string NgAppFolder => Path.Combine(this.OutputDir, "ng-app");

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string NgModelsFolder => Path.Combine(this.NgAppFolder, "models");

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string NgServicesFolder => Path.Combine(this.NgAppFolder, "services");

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string NgComponentsFolder => Path.Combine(this.NgAppFolder, "autogen-components");

    /// <summary>
    /// Gets IRepositoriesDirPath.
    /// </summary>
    public string IRepositoriesDirPath => Path.Combine(this.DomainDirPath, "Repositories");

    /// <summary>
    /// Gets RepositoriesDirPath.
    /// </summary>
    public string RepositoriesDirPath => Path.Combine(this.DomainDirPath, "Repositories", this.OrmType.AsNamespacePart());

    /// <summary>
    /// Gets ServicesDirPath.
    /// </summary>
    public string ServicesDirPath => Path.Combine(this.DomainDirPath, "Services");

    /// <summary>
    /// Caculate the domain namespace.
    /// </summary>
    public string DomainNamespace => this.ProjectName + ".Domain";

    /// <summary>
    /// Gets the entity namespace.
    /// </summary>
    public string EntityNamespace => this.DomainNamespace + ".Entities";

    /// <summary>
    /// Gets the mapping namespace.
    /// </summary>
    public string MappingNamespace => this.EntityNamespace + ".Mappings." + this.OrmType.AsNamespacePart();

    /// <summary>
    /// Gets the DTOs namespace.
    /// </summary>
    public string DTONamespace => this.EntityNamespace + ".DTOs";

    /// <summary>
    /// Gets the Repository Namespace.
    /// </summary>
    public string RepositoryNamespace => this.DomainNamespace + ".Repositories";

    /// <summary>
    /// Gets or sets ServiceNamespace.
    /// </summary>
    public string ServiceNamespace => this.DomainNamespace + ".Services";

    public bool GenAutoMapper { get; set; }

    public bool GenAspNetController { get; set; }

    public bool GenNgApp { get; set; }

    public bool GenStoredProc { get; set; } = true;

    public bool IncludeTangsemIdentity { get; set; }

    public bool UpdateSqlForModifiedColumnsOnly { get; set; }

    public void Init()
    {
      if (string.IsNullOrWhiteSpace(this.ConnectionString))
      {
        throw new Exception("ConnectionString is required in configuration.");
      }

      if (string.IsNullOrEmpty(this.ProjectName))
      {
        this.ProjectName = "MyProject";
      }

      if (string.IsNullOrEmpty(this.RepositoryName))
      {
        this.RepositoryName = "MyRepository";
      }

      if (string.IsNullOrEmpty(this.OutputDir))
      {
        this.OutputDir = Path.Combine(Path.GetTempPath(), "TangsemCodeGen", $"{this.ProjectName}");

        if (this.UseTimestampInOutputFolder)
        {
          this.OutputDir += $"_{DateTime.Now:yyyyMMdd_HHmmss}";
        }
      }

      // convert to absolute path.
      this.OutputDir = new DirectoryInfo(this.OutputDir).FullName;
    }

    /// <summary>
    /// Get the type of 
    /// </summary>
    /// <returns></returns>
    public Type GetMetadataBuilderType()
    {
      var classAndAssemblyNames = this.MetadataBuilder.Split(';');

      var assemblyName = classAndAssemblyNames.Length > 1
                ? classAndAssemblyNames[1].Trim()
                : null;

      var className = classAndAssemblyNames.Length > 0
                ? classAndAssemblyNames[0].Trim()
                : null;

      var ass = string.IsNullOrWhiteSpace(assemblyName) ? typeof(MetadataBuilder).Assembly : Assembly.Load(assemblyName);
      var type = string.IsNullOrWhiteSpace(className) ? typeof(SqlServer2008MetadataBuilder) : ass.GetType(className);

      return type;
    }

    /// <summary>
    /// Create a new meta builder.
    /// </summary>
    /// <returns></returns>
    public MetadataBuilder CreateMetadataBuilder()
    {
      var type = this.GetMetadataBuilderType();

      var constructorInfo = type.GetConstructor(new[] { typeof(string) });

      if (constructorInfo == null)
      {
        throw new Exception("MetadataBuilder and its subclasses should have constructor ctor(connectionString)!");
      }

      var builder = constructorInfo.Invoke(new[] { this.ConnectionString }) as MetadataBuilder;

      return builder;
    }
  }
}
