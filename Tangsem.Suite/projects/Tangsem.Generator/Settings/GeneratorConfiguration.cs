using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Tangsem.Generator.Metadata.Builder;

namespace Tangsem.Generator.Settings
{
  [XmlRoot("GeneratorConfiguration")]
  public class GeneratorConfiguration
  {
    public static GeneratorConfiguration FromFile(string filePath)
    {
      var xmlSer = new XmlSerializer(typeof(GeneratorConfiguration));

      using (var stream = File.OpenRead(filePath))
      {
        var instance = (GeneratorConfiguration)xmlSer.Deserialize(stream);
        instance.Init();

        instance.ConfigFilePath = filePath;

        return instance;
      }
    }

    [XmlIgnore]
    public string ConfigFilePath { get; private set; }

    [XmlAttribute]
    public bool GenRelationship { get; set; }

    [XmlAttribute]
    public bool UseTimestampInOutputFolder { get; set; }

    /// <summary>
    /// Gets or sets ProjectName.
    /// </summary>
    [XmlAttribute]
    public string ProjectName { get; set; }

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
        else
        {
          return OrmTypes.NHibernate;
        }
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
    public string ProjectDirPath
    {
      get
      {
        return Path.Combine(this.OutputDir, this.ProjectName);
      }
    }

    /// <summary>
    /// Gets EntitiesDirPath.
    /// </summary>
    public string DomainDirPath
    {
      get
      {
        return Path.Combine(this.ProjectDirPath, this.DomainNamespace.Substring(this.ProjectName.Length + 1).Replace(".", @"\"));
      }
    }

    /// <summary>
    /// Gets EntitiesDirPath.
    /// </summary>
    public string EntitiesDirPath
    {
      get
      {
        return Path.Combine(this.DomainDirPath, "Entities");
      }
    }

    /// <summary>
    /// Gets Entity Mappings Dir Path.
    /// </summary>
    public string MappingDirPath
    {
      get
      {
        return Path.Combine(this.EntitiesDirPath, "Mappings", this.OrmType.AsNamespacePart());
      }
    }

    public string AutoMappingConfigsDirPath
    {
      get
      {
        return Path.Combine(this.EntitiesDirPath, "Mappings", "AutoMapper");
      }
    }

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string DTODirPath
    {
      get
      {
        return Path.Combine(this.EntitiesDirPath, "DTOs");
      }
    }

    public string NgAppFolder
    {
      get
      {
        return Path.Combine(this.OutputDir, "ng-app");
      }
    }

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string NgModelsFolder
    {
      get
      {
        return Path.Combine(this.NgAppFolder, "models");
      }
    }

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string NgServicesFolder
    {
      get
      {
        return Path.Combine(this.NgAppFolder, "services");
      }
    }

    /// <summary>
    /// Gets DTODirPath.
    /// </summary>
    public string NgComponentsFolder
    {
      get
      {
        return Path.Combine(this.NgAppFolder, "autogen-components");
      }
    }

    /// <summary>
    /// Gets IRepositoriesDirPath.
    /// </summary>
    public string IRepositoriesDirPath
    {
      get
      {
        return Path.Combine(this.DomainDirPath, "Repositories");
      }
    }

    /// <summary>
    /// Gets RepositoriesDirPath.
    /// </summary>
    public string RepositoriesDirPath
    {
      get
      {
        return Path.Combine(this.DomainDirPath, "Repositories", this.OrmType.AsNamespacePart());
      }
    }

    /// <summary>
    /// Gets ServicesDirPath.
    /// </summary>
    public string ServicesDirPath
    {
      get
      {
        return Path.Combine(this.DomainDirPath, "Services");
      }
    }

    /// <summary>
    /// Caculate the domain namespace.
    /// </summary>
    public string DomainNamespace
    {
      get
      {
        return this.ProjectName + ".Domain";
      }
    }

    /// <summary>
    /// Gets the entity namespace.
    /// </summary>
    public string EntityNamespace
    {
      get
      {
        return this.DomainNamespace + ".Entities";
      }
    }

    /// <summary>
    /// Gets the mapping namespace.
    /// </summary>
    public string MappingNamespace
    {
      get
      {
        return this.EntityNamespace + ".Mappings." + this.OrmType.AsNamespacePart();
      }
    }

    /// <summary>
    /// Gets the DTOs namespace.
    /// </summary>
    public string DTONamespace
    {
      get
      {
        return this.EntityNamespace + ".DTOs";
      }
    }

    /// <summary>
    /// Gets the Repository Namespace.
    /// </summary>
    public string RepositoryNamespace
    {
      get
      {
        return this.DomainNamespace + ".Repositories";
      }
    }

    /// <summary>
    /// Gets or sets ServiceNamespace.
    /// </summary>
    public string ServiceNamespace
    {
      get
      {
        return this.DomainNamespace + ".Services";
      }
    }

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
          this.OutputDir += $"_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
        }
      }

      // convert to absolute path.
      this.OutputDir = new DirectoryInfo(this.OutputDir).FullName;

      // create project dir if it doesn't exist.
      this.CreateDirIfNotExists(this.ProjectDirPath);

      // create entities dir if it doesn't exist.
      this.CreateDirIfNotExists(this.EntitiesDirPath);

      // create mapping dir if it doesn't exist.
      this.CreateDirIfNotExists(this.MappingDirPath);
      this.CreateDirIfNotExists(this.AutoMappingConfigsDirPath);

      // create dto dir if it doesn't exist.
      this.CreateDirIfNotExists(this.DTODirPath);
      
      // create interface repositories dir if it doesn't exist.
      this.CreateDirIfNotExists(this.IRepositoriesDirPath);

      // create repositories dir if it doesn't exist.
      this.CreateDirIfNotExists(this.RepositoriesDirPath);


      // Angular Related
      this.CreateDirIfNotExists(this.NgAppFolder);
      this.CreateDirIfNotExists(this.NgModelsFolder);
      this.CreateDirIfNotExists(this.NgComponentsFolder);
      this.CreateDirIfNotExists(this.NgServicesFolder);
    }

    /// <summary>
    /// Get the type of 
    /// </summary>
    /// <returns></returns>
    public Type GetMetadataBuilderType()
    {
      var classAndAssemblyNames = this.MetadataBuilder.Split(new[] { ';' });

      var assemblyName = classAndAssemblyNames.Length > 1
                ? classAndAssemblyNames[1]
                : null;

      var className = classAndAssemblyNames.Length > 0
                ? classAndAssemblyNames[0]
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

    /// <summary>
    /// Create the dir if it doesn't exist.
    /// </summary>
    /// <param name="entityDir"></param>
    private void CreateDirIfNotExists(string entityDir)
    {
      if (!Directory.Exists(entityDir))
      {
        Directory.CreateDirectory(entityDir);
      }
    }
  }
}
