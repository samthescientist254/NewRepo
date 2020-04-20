using LoanAppraisalApi.Models.DataManager;
using System.Collections.Generic;

namespace LoanAppraisalApi.Models.Repository
{
    public interface IDataRepository<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(U id);
        object Add(TEntity b);
        long Update(U id, TEntity b);
        long Delete(U id);
    }
}
