using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T> //Typeı işaret eder t sembolü
    {
        IQueryable<T> FindAll(bool trackChanges);

    }
}
