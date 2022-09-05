using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Mapping;
using FluentNHibernate.Mapping.Providers;

namespace Tangsem.NHibernate.Tests.PostgreTest1.Domain.Entities.Mappings.NHibernate
{
  /// <summary>
  /// The mapping configuration for ProductPhoto.
  /// </summary>
  public partial class ProductPhotoMap
  {
    partial void CustomMappingConfig()
    {
      (this.Providers.Properties.OfType<IPropertyMappingProvider>()
         .FirstOrDefault(x => x.GetPropertyMapping().Name == nameof(ProductPhoto.ImageData)) as PropertyPart)
        ?.LazyLoad();

      // (x => x.ImageData).LazyLoad();
    }
  }
}
