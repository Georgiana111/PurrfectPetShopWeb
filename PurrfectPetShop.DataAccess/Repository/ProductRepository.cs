using PurrfectPetShop.DataAccess.Data;
using PurrfectPetShop.DataAccess.Repository.IRepository;
using PurrfectPetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrfectPetShop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var obj = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (obj != null)
            {
                obj.Name = product.Name;
                obj.ProductPrice = product.ProductPrice;
                obj.CategoryId = product.CategoryId;
                obj.Description = product.Description;
                obj.Status = product.Status;
                if (product.ImageUrl != null)
                {
                    obj.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
