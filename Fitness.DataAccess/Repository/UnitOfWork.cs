using Fitness.DataAccess.Data;
using Fitness.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IDietsCategoryRepository DietsCategory { get; private set; }
        public IDietRepository Diet { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            DietsCategory = new DietsCategoryRepository(_db);
            Diet = new DietRepository(_db);
        }
        public IDietsCategoryRepository IDietRepository {get; private set;}

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
