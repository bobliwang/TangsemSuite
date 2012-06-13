using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tangsem.Generator.Metadata.Builder;
using Tangsem.Generator.Settings;
using Tangsem.Generator.Templates.Entities;
using Tangsem.Generator.Templates.Repositories;

namespace Tangsem.Generator.Test
{
	[TestClass]
	public class PocosTest
	{
		public static string GeneratedCodesDir = Path.Combine(Path.GetTempPath(), "Tangsem.Generator.NHibernateTest");

		public GeneratorConfiguration GeneratorConfiguration { get; set; }

		public MetadataBuilder MetadataBuilder { get; private set; }

		[TestInitialize]
		public void SetUp()
		{
			var xmlSer = new XmlSerializer(typeof(GeneratorConfiguration));

			using (var stream = File.OpenRead("GeneratorConfiguration.xml"))
			{
				this.GeneratorConfiguration = xmlSer.Deserialize(stream) as GeneratorConfiguration;

				this.GeneratorConfiguration.Init();
			}

			Assert.IsNotNull(this.GeneratorConfiguration, "this.GeneratorConfiguration is null");

			this.MetadataBuilder = this.GeneratorConfiguration.CreateMetadataBuilder();
			this.MetadataBuilder.Build();

			this.Log("", "SetUp is finished");
		}

		[TestMethod]
		public void GeneratePocos()
		{
			foreach(var tbName in this.MetadataBuilder.AllTableNames)
			{
				if (!this.GeneratorConfiguration.IgnoredTables.Any(x => x.Equals(tbName, StringComparison.CurrentCultureIgnoreCase)))
				{
					this.GenerateCodeForEntity(tbName);	
				}
			}

			var repoTemplate = new Repository_NHibernate_Designer { Configuration = this.GeneratorConfiguration, MetadataBuilder = this.MetadataBuilder };
			var repoCode = repoTemplate.TransformText().Trim();

			var repoDir = GeneratedCodesDir + "/Domain/Repositories";
			this.CreateDirIfNotExists(repoDir);
			var repoDesignerFilePath = repoDir + "/" + this.GeneratorConfiguration.RepositoryName + ".Designer.cs";

			File.WriteAllText(repoDesignerFilePath, repoCode);

			Process.Start(GeneratedCodesDir);
		}

		private void GenerateCodeForEntity(string entityName)
		{
			var tableMetadata = this.MetadataBuilder.GetTableMetadata(entityName);

			var pocoTemplate = new Poco_NHibernate_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };

			var code = pocoTemplate.TransformText().Trim();

			var entityDir = GeneratedCodesDir + "/Domain/Entities";
			this.CreateDirIfNotExists(entityDir);
			var entityDesignerFilePath = entityDir + "/" + tableMetadata.EntityName + ".Designer.cs";

			File.WriteAllText(entityDesignerFilePath, code);

			this.Log("Saved", "Generated Poco for " + entityName + ":");

			var mappingTemplate = new Poco_NHibernate_Fluent_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };
			var mappingCode = mappingTemplate.TransformText().Trim();

			var mappingDir = entityDir + "/Mappings";
			this.CreateDirIfNotExists(mappingDir);
			var entityMappingDesignerFilePath = mappingDir + "/" + tableMetadata.EntityName + "Map.cs";

			File.WriteAllText(entityMappingDesignerFilePath, mappingCode);
			this.Log("Saved", "Generated Mapping for " + entityName + ":");
		}

		private void CreateDirIfNotExists(string entityDir)
		{
			if (!Directory.Exists(entityDir))
			{
				Directory.CreateDirectory(entityDir);
			}
		}

		private void Log(string message, string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Console.WriteLine("=============================");
				Console.WriteLine(title);
				Console.WriteLine("=============================");
			}

			Console.WriteLine(message);
		}
	}
}
