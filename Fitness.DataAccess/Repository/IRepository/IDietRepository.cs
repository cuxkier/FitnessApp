using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataAccess.Repository.IRepository
{
    public interface IDietRepository : IRepository<Diet>
    {
        void Update(Diet obj);
    }
}
