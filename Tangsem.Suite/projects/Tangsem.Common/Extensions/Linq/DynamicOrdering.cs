using System.Linq.Expressions;

namespace Tangsem.Common.Extensions.Linq
{
  internal class DynamicOrdering
  {
    public Expression Selector;
    public bool Ascending;
  }
}