using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);   
            if (objFromDb != null)
            {
                objFromDb.ISBN = obj.ISBN;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Description = obj.Description;
                objFromDb.Title = obj.Title;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                if(obj.ImageURL != null)
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }

        }
    }
}
