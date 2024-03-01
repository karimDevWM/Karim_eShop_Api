using api.Karim_eshop.Data.Context.Contract;
using api.Karim_eshop.Data.Entity;
using api.Karim_eshop.Data.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Karim_eshop.Tests.Common.ScenarioDatas
{
    public static class ProduitUtilities
    {
        public static void CreateProduit(this KarimeshopDbContext Karim_eshopDBContex)
        {
            var unite = new Product { Id = 1, Name = "telephone à cadran" };
            Karim_eshopDBContex.Products.Add(unite);
            Karim_eshopDBContex.SaveChanges();
        }

        public static void CreateProduits(this KarimeshopDbContext Karim_eshopDBContex)
        {
            var unite1 = new Product { Id = 2, Name = "lustre en diamant" };
            var unite2 = new Product { Id = 3, Name = "badminton" };
            Karim_eshopDBContex.Products.AddRange(unite1, unite2);
            Karim_eshopDBContex.SaveChanges();
        }
    }
}
