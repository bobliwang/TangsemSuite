////using System.Text.RegularExpressions;

////using Xunit;
////using Xunit.Abstractions;

////namespace Tangsem.NHibernate.Tests
////{
////  public class RegexTests
////  {
////    private readonly ITestOutputHelper output;

////    public RegexTests(ITestOutputHelper output)
////    {
////      this.output = output;
////    }

////    [Fact(DisplayName = nameof(ReplaceLink))]
////    public void ReplaceLink()
////    {
////      var input =
////        $@"The world is beautiful https://www.microsoft.com https://admin.ipropertyexpress.com/doc/plcr/96bc5a8c-dcb6-489a-9a7e-43c7ba979501/636697382652574305/ Do you think so";

////      var newLink = "https://google.com";

////      var pattern = @"^http(s)?://admin.ipropertyexpress.com/([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$";
////      var result = Regex.Replace(input, pattern, newLink, RegexOptions.IgnoreCase);

////      this.output.WriteLine($"Input: {input}");
////      this.output.WriteLine($"Output: {result}");

////      Assert.Equal($@"The world is beautiful https://www.microsoft.com {newLink} Do you think so", result);
////    }
////  }
////}