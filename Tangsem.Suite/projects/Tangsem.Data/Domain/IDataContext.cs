namespace Tangsem.Data.Domain
{
  public interface IRepositoryContext
  {
    int CurrentUserId { get; }
  }

  public interface IDataContext : IRepositoryContext
  {
  }

  public class DefaultRepoContext : IDataContext
  {
    public int CurrentUserId { get; set; }
  }
}