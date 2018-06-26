using Tangsem.Data.Domain;

namespace GeneratorTest.Host
{
  public class FakeDataContext: IDataContext
  {
    public int CurrentUserId { get; } = 1;
  }
}