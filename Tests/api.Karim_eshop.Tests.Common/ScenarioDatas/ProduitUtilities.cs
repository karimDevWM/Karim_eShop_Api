//using api.Karim_eshop.Data.Context.Contract;
//using api.Karim_eshop.Data.Entity.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace api.Karim_eshop.Tests.Common.ScenarioDatas
//{
//    public static class ProduitUtilities
//    {
//        public static void CreateProduit(this IKarimeshopDbContext Karim_eshopDBContex)
//        {
//            var unite = new Produit { ProduitId = 1, ProduitLibelle = "telephone à cadran" };
//            Karim_eshopDBContex.Produits.Add(unite);
//            Karim_eshopDBContex.SaveChanges();
//        }

//        public static void CreateProduits(this IKarimeshopDbContext Karim_eshopDBContex)
//        {
//            var unite1 = new Produit { ProduitId = 2, ProduitLibelle = "lustre en diamant" };
//            var unite2 = new Produit { ProduitId = 3, ProduitLibelle = "badminton" };
//            Karim_eshopDBContex.Produits.AddRange(unite1, unite2);
//            Karim_eshopDBContex.SaveChanges();
//        }
//    }
//}
