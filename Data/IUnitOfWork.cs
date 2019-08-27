using System;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void commit();
    }
}