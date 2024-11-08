using Repositorypattern.core.IDatabaseRepository;
using Repositorypattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorypattern.core.UnitofWork
{
    public interface IUnitOFWork : IDisposable
    {
        IProductRepository Products  { get; }

        int Compelet();
        void Dispose();
    }
}
