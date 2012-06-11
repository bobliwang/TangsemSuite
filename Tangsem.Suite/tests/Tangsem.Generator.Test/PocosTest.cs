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

namespace Tangsem.Generator.Test
{
	[TestClass]
	public class PocosTest
	{
		public GeneratorConfiguration GeneratorConfiguration { get; set; }

		public MetadataBuilder MetadataBulder { get; private set; }

		[TestInitialize]
		public void SetUp()
		{
			var xmlSer = new XmlSerializer(typeof(GeneratorConfiguration));

			using (var stream = File.OpenRead("GeneratorConfiguration.xml"))
			{
				this.GeneratorConfiguration = xmlSer.Deserialize(stream) as GeneratorConfiguration;
			}

			Assert.IsNotNull(this.GeneratorConfiguration, "this.GeneratorConfiguration is null");

			this.MetadataBulder = this.GeneratorConfiguration.CreateMetadataBuilder();
			this.MetadataBulder.Build();

			this.Log("", "SetUp is finished");
		}

		[TestMethod]
		public void GeneratePocos_Country()
		{
			this.GenerateCodeForEntity("Country");
		}

		[TestMethod]
		public void GeneratePocos_State()
		{
			this.GenerateCodeForEntity("State");
		}

		[TestMethod]
		public void DummyTest()
		{
			this.Log("", "DummyTest is finished");
		}

		private void GenerateCodeForEntity(string entityName)
		{
			var tableMetadata = this.MetadataBulder.GetTableMetadata(entityName);

			var pocoTemplate = new Poco_NHibernate_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };

			var code = pocoTemplate.TransformText().Trim();

			this.Log(code, "Generated Poco for " + entityName + ":");

			var mappingTemplate = new Poco_NHibernate_Fluent_Designer { TableMetadata = tableMetadata, Configuration = this.GeneratorConfiguration };
			code = mappingTemplate.TransformText().Trim();
			this.Log(code, "Generated Mapping for " + entityName + ":");
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
