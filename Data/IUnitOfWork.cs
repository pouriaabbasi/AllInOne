using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        // void Commit();
        Task CommitAsync();
    }
}