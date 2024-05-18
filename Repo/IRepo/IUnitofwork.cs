using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repo.IRepo
{
    public interface IUnitofwork
    {
        IProductRepo productRepo { get; }
        void Save();
    }
}