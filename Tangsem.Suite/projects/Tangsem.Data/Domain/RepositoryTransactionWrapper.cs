using System;

namespace Tangsem.Data.Domain
{
  public class RepositoryTransactionWrapper : IDisposable
  {
    private bool isDisposing = false;

    public IRepository Repository { get; }

    public object Transaction { get; }

    public RepositoryTransactionWrapper(IRepository repo, object transaction)
    {
      this.Repository = repo;
      this.Transaction = transaction;
    }

    public void Dispose()
    {
      if (this.isDisposing)
      {
        return;
      }

      this.isDisposing = true;

      if (this.Repository.IsInTransaction)
      {
        try
        {
          this.Repository.Commit();
        }
        catch (Exception exCommit)
        {
          try
          {
            this.Repository.Rollback();
            throw;
          }
          catch (Exception exRollback)
          {
            var errMsg = $"{exRollback.Message} => {exRollback}, {exCommit.Message} => {exCommit}";

            throw new Exception(errMsg, exCommit);
          }
        }
      }
    }
  }
}