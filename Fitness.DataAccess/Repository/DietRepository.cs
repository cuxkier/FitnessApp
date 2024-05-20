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
    public class DietRepository : Repository<Diet>, IDietRepository
    {
        private ApplicationDbContext _db;

        public DietRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Diet obj)
        {
            var objFromDb = _db.Diets.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb == null)
            {
                objFromDb.DietName = obj.DietName;
                objFromDb.Kcal = obj.Kcal;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryDietId = obj.CategoryDietId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
