using System;
using System.Collections.Generic;
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
		/// <summary>
		/// The namespace for entities.
		/// </summary>
		[XmlAttribute]
		public string EntityNamespace { get; set; }

		/// <summary>
		/// Database connection string.
		/// </summary>
		[XmlAttribute]
		public string ConnectionString { get; set; }

		/// <summary>
		/// Gets or sets RepositoryNamespace.
		/// </summary>
		[XmlAttribute]
		public string RepositoryNamespace { get; set; }

		/// <summary>
		/// Gets or sets RepositoryName.
		/// </summary>
		[XmlAttribute]
		public string RepositoryName { get; set; }

		/// <summary>
		/// Gets or sets ServiceNamespace.
		/// </summary>
		[XmlAttribute]
		public string ServiceNamespace { get; set; }
		
		/// <summary>
		/// The MeatadataBuilder type name. Format: className[;assemblyName]
		/// </summary>
		[XmlAttribute]
		public string MetadataBuilder { get; set; }

		[XmlElement("IgnoredTable")]
		public List<string> IgnoredTables { get; set; }

		public void Init()
		{
			if (string.IsNullOrWhiteSpace(this.EntityNamespace))
			{
				throw new Exception("EntityNamespace is required in configuration.");
			}

			if (string.IsNullOrWhiteSpace(this.ConnectionString))
			{
				throw new Exception("ConnectionString is required in configuration.");
			}

			var lastDotPosInEntityNamespace = this.EntityNamespace.LastIndexOf('.');

			if (lastDotPosInEntityNamespace < 1)
			{
				throw new Exception("EntityNamespace is not valid in configuration.");
			}

			if (string.IsNullOrEmpty(this.RepositoryNamespace))
			{

				this.RepositoryNamespace = this.EntityNamespace.Substring(0, lastDotPosInEntityNamespace) + "." + "Repositories";
			}

			if (string.IsNullOrEmpty(this.ServiceNamespace))
			{
				this.ServiceNamespace = this.EntityNamespace.Substring(0, lastDotPosInEntityNamespace) + "." + "Services";
			}

			if (string.IsNullOrEmpty(this.RepositoryName))
			{
				this.RepositoryName = "MyRepository";
			}
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
