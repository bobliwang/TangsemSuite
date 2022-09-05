using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

using NHibernate;

using Tangsem.NHibernate.Extensions;
using Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities;
using Tangsem.NHibernate.Tests.PostgreTest1.Models;

using Xunit;
using Xunit.Abstractions;
using static System.Console;
using static Xunit.Assert;

namespace Tangsem.NHibernate.Postgres.Tests
{
  /// <summary>
  /// Test cases for PostgreSQL.
  /// </summary>
  public class Postgre_UnitTest1 : TestBase
  {
    public Postgre_UnitTest1(ITestOutputHelper output)
      : base(output)
    {
    }

    [Fact]
    public void Postgre_Test1()
    {
      using (var repo = this.OpenRepository())
      {
        var prodSaved = repo.SaveProduct(new Product
         {
           ProductName = "test prod name like",
           ExtdProps = new []
             {
               new PictureModel
                 {
                   Base64Thumbnails = "base64Image",
                   Url = "http://ab.com"
                 }
             }
         });

        var prod = repo.Products.FirstOrDefault(x => x.ProductName.IsLike("%prod%"));

        var prodPhoto = repo.SaveProductPhoto(new ProductPhoto
        {
          Product = prodSaved,
          ImageData = File.ReadAllBytes(@"C:\Users\wlwlw\Pictures\Saved Pictures\1-1.jpg"),
          CreatedDate = DateTime.UtcNow
        });

        NotNull(prod);
        True(prod.ProductName.Contains("prod", StringComparison.InvariantCultureIgnoreCase));
      }
    }

    [Fact]
    public void Postgre_GetBinaryData()
    {
      using (var repo = this.OpenRepository())
      {
        var prodPhoto = repo.ProductPhotos.FirstOrDefault();

        False(NHibernateUtil.IsPropertyInitialized(prodPhoto, nameof(ProductPhoto.ImageData)));
        var imgData = prodPhoto.ImageData;
        True(NHibernateUtil.IsPropertyInitialized(prodPhoto, nameof(ProductPhoto.ImageData)));

        NotNull(prodPhoto);

        File.WriteAllBytes(@"C:\Users\wlwlw\Pictures\Saved Pictures\1-1_A.jpg", imgData);
      }
    }

    [Fact]
    public void Postgre_Test2()
    {
      using (var repo = this.OpenRepository())
      {
        var prods = repo.Products.Where(x => x.ProductCategoryMaps.Count > 0).ToList();

        WriteLine($"Prods: {prods.Count}");
      }
    }

    [Fact]
    public void Postgre_Insert_100_ProductCategoryMap()
    {
      using (var repo = this.OpenRepository())
      {
        repo.BeginTransaction(IsolationLevel.Snapshot);

        var prod = repo.Products.FirstOrDefault();
        var cat = repo.Categories.FirstOrDefault();

        var sw = Stopwatch.StartNew();
        for (var i = 0; i < 1000; i++)
        {
          repo.SaveProductCategoryMap(new ProductCategoryMap { Product = prod, Category = cat });
        }

        sw.Stop();
        WriteLine($"Time used to insert 1000 records: {sw.ElapsedMilliseconds}ms");

        sw.Start();
        repo.Commit();

        sw.Stop();
        WriteLine($"Time used to commit: {sw.ElapsedMilliseconds}ms");
      }
    }
  }
}
