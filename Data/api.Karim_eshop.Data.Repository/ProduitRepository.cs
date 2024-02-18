//using api.Karim_eshop.Data.Context.Contract;
//using api.Karim_eshop.Data.Entity.Model;
//using api.Karim_eshop.Data.Repository.Contract;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace api.Karim_eshop.Data.Repository
//{
//    public class ProduitRepository : IProduitRepository
//    {
//        private readonly IKarimeshopDbContext _dbContext;

//        public ProduitRepository(IKarimeshopDbContext karim_EshopDBContext)
//        {
//            _dbContext = karim_EshopDBContext;
//        }

//        public async Task<Produit> CreateProductAsync(Produit produit)
//        {
//            var elementAdded = await _dbContext.Produits.AddAsync(produit).ConfigureAwait(false);
//            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
//            return elementAdded.Entity;
//        }

//        public async Task<List<Produit>> GetAllProductsAsync()
//        {
//            var elements = await _dbContext.Produits.ToListAsync().ConfigureAwait(false);
//            return elements;
//        }

//        public async Task<Produit> GetProductByIdAsync(int produitId)
//        {
//            var element = await _dbContext.Produits.FirstOrDefaultAsync(product => product.ProduitId == produitId);
//            return element!;
//        }

//        public async Task<Produit> UpdateProductAsync(Produit produit)
//        {
//            var elementUpdated = _dbContext.Produits.Update(produit);

//            await _dbContext.SaveChangesAsync().ConfigureAwait (false);

//            return elementUpdated.Entity;
//        }
//    }
//}
