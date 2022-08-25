using Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Common
{
    public interface IRepository<T,Z,P> 
    {
        public Task<T> Create(Z model);
        public Task Update(P model, int id);
        public Task<T> GetById(int id);
        public Task Delete(int id);
        
        
    }
}