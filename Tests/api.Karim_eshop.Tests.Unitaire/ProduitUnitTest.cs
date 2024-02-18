//using api.Karim_eshop.Data.Entity.Model;
//using api.Karim_eshop.Data.Repository;
//using api.Karim_eshop.Data.Repository.Contract;
//using api.Karim_eshop.Tests.Common;
//using api.Karim_eshop.Tests.Common.ScenarioDatas;
//using Microsoft.Extensions.DependencyInjection;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace api.Karim_eshop.Tests.Unitaire
//{
//    [TestFixture]
//    public class ProduitUnitTest : TestBase
//    {
//        private IProduitRepository _produitRepository;
//        [SetUp]
//        public void Setup()
//        {
//            SetupTest();

//            IProduitRepository? produitRepository = _serviceProvider?.GetService<IProduitRepository>();
//            _produitRepository = produitRepository!;

//            _context!.CreateProduit();
//        }

//        [TearDown]
//        public void Teardown()
//        {
//            CleanTest();
//        }

//        [Test]
//        public async Task CreateProduit()
//        {
//            // Arrange
//            var produit = new Produit()
//            {
//                ProduitId = 2,
//                ProduitLibelle = "Mixeur",
//                ProduitDescription = "Mixeur pour bébé",
//                ProduitPrix = (decimal?)49.99,
//                ProduitImage = "mixeur.jpeg"
//            };

//            // Act
//            var productToAdd = await _produitRepository.CreateProductAsync(produit).ConfigureAwait(false);

//            // Assert
//            Assert.Multiple(() =>
//            {
//                Assert.That(productToAdd, Is.Not.Null);
//                Assert.That(produit.ProduitLibelle, Is.EqualTo(productToAdd.ProduitLibelle));
//            });
//        }

//        [Test]
//        public async Task GetProducts()
//        {
//            var produits = await _produitRepository.GetAllProductsAsync().ConfigureAwait(false);

//            Assert.That(produits, Is.Not.Null);
//        }

//        [Test]
//        public async Task GetProductById()
//        {
//            int id = 1;
//            var produit = await _produitRepository.GetProductByIdAsync(id).ConfigureAwait(false);

//            Assert.That(id, Is.EqualTo(produit.ProduitId));
//        }
//    }
//}
