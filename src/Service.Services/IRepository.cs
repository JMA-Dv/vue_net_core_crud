using Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IRepository<T,P,Z>
    {
        public Task<T> Create(P model);
        public Task<Z> Update(P model, int id);
        public Task<Z> GetById(int id);
        public Task Delete(int id);
        
        
    }
}