using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using Fitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataAccess.Repository
{
    public class DietsCategoryRepository : Repository<DietsCategory>, IDietsCategoryRepository
    {
        private ApplicationDbContext _db;

        public DietsCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(DietsCategory obj)
        {
            _db.DietsCategory.Update(obj);
        }
    }
}
