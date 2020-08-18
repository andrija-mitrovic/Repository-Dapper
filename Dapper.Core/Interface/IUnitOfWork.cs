using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Core.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
