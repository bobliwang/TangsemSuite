using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using RazorGenerator.Templating;

using Tangsem.Generator.Metadata.Builder;
using Tangsem.Generator.Settings;
using Tangsem.Generator.Templates.Entities;
using Tangsem.Generator.Templates.Repositories;

namespace Tangsem.Generator.Test
{
	[TestClass]
	public class PocosTest
	{
		[TestMethod]
		public void TestGeneration()
		{
			var gen = new Gen(GeneratorConfiguration.FromFile("GeneratorConfiguration.xml"));

			gen.Run();
		}

		////[TestMethod]
		////public void Test_Expressions()
		////{
		////    var auName = "Australia";
		////    var auCode = "AU";
		////    Expression<Predicate<Country>> expr = c => c.Name == auName && c.CountryCode == auCode;

		////    Console.WriteLine(expr.ToString());
		////}

		////public GeneratorConfiguration GeneratorConfiguration { get; set; }

		////public MetadataBuilder MetadataBuilder { get; private set; }

		////[TestInitialize]
		////public void SetUp()
		////{
		////    this.GeneratorConfiguration = GeneratorConfiguration.FromFile("GeneratorConfiguration.xml");
		////    this.MetadataBuilder = this.GeneratorConfiguration.CreateMetadataBuilder();
		////    this.MetadataBuilder.Build();

		////    this.Log("", "SetUp is finished");
		////}



		////[TestMethod]
		////public void GeneratePocos()
		////{
		////    foreach(var tbName in this.MetadataBuilder.AllTableNames)
		////    {
		////        if (!this.GeneratorConfiguration.IgnoredTables.Any(x => x.Equals(tbName, StringComparison.CurrentCultureIgnoreCase)))
		////        {
		////            this.GenerateCodeForEntity(tbName);	
		////        }
		////    }

		////    var code = string.Empty;
		////    var path = string.Empty;
		////    RazorTemplateBase template = null;

		////    var tableMetadatas = this.MetadataBuilder
		////                            .CachedTableMetadata
		////                            .Values
		////                            .Where(x => !this.GeneratorConfiguration.IgnoredTables.Any(y => x.Name.Equals(y, StringComparison.CurrentCultureIgnoreCase)))
		////                            .ToList();

		////    template = new Repository_NHibernate_Designer { Configuration = this.GeneratorConfiguration, TableMetadatas = tableMetadatas};
		////    code = template.TransformText().Trim();
		////    path = this.GeneratorConfiguration.RepositoriesDirPath + "/" + this.GeneratorConfiguration.RepositoryName + ".Designer.cs";
		////    File.WriteAllText(path, code);

		////    template = new IRepository_NHibernate_Designer { Configuration = this.GeneratorConfiguration, TableMetadatas = tableMetadatas};
		////    code = template.TransformText().Trim();
		////    path = this.GeneratorConfiguration.RepositoriesDirPath + "/I" + this.GeneratorConfiguration.RepositoryName + ".Designer.cs";
		////    File.WriteAllText(path, code);

		////    if (this.GeneratorConfiguration.OpenOutputDirAfterGeneration)
		////    {
		////        Log("Openning Directory:" + this.GeneratorConfiguration.ProjectDirPath, "Openning Directory");
		////        Process.Start(this.GeneratorConfiguration.ProjectDirPath);	
		////    }
		////}

		////private void GenerateCodeForEntity(string entityName)
		////{
		////    var tableMetadata = this.MetadataBuilder.GetTableMetadata(entityName);

		////    var pocoTemplate = new Poco_NHibernate_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };

		////    var entityCode = pocoTemplate.TransformText().Trim();
		////    var entityDesignerFilePath = this.GeneratorConfiguration.EntitiesDirPath + "/" + tableMetadata.EntityName + ".Designer.cs";
		////    File.WriteAllText(entityDesignerFilePath, entityCode);
		////    this.Log("Saved", "Generated Poco for " + entityName + ":");

		////    var mappingTemplate = new Poco_NHibernate_Fluent_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };
		////    var mappingCode = mappingTemplate.TransformText().Trim();
		////    var entityMappingDesignerFilePath = this.GeneratorConfiguration.MappingDirPath + "/" + tableMetadata.EntityName + "Map.Designer.cs";
		////    File.WriteAllText(entityMappingDesignerFilePath, mappingCode);
		////    this.Log("Saved", "Generated Mapping for " + entityName + ":");

		////    var dtoTemplate = new Poco_DTO_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };
		////    var dtoCode = dtoTemplate.TransformText().Trim();
		////    var dtoDesignerFilePath = this.GeneratorConfiguration.DTODirPath + "/" + tableMetadata.EntityName + "DTO.Designer.cs";
		////    File.WriteAllText(dtoDesignerFilePath, dtoCode);
		////    this.Log("Saved", "Generated dto for " + entityName + ":");
		////}
		
		////private void Log(string message, string title)
		////{
		////    if (!string.IsNullOrEmpty(title))
		////    {
		////        Console.WriteLine("=============================");
		////        Console.WriteLine(title);
		////        Console.WriteLine("=============================");
		////    }

		////    Console.WriteLine(message);
		////}
	}
}
