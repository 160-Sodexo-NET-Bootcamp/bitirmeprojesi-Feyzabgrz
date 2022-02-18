using PCP.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Data.Concrete.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }


        Task<int> SaveAsync();
        //void SaveAsync();
        //ValueTask DisposeAsync(); //bunun neye yaradığını bikmiyorum
    }
}
