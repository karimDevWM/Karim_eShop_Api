//using api.Karim_eshop.Business.DTOs;
//using api.Karim_eshop.Data.Context.Contract;
//using api.Karim_eshop.Tests.Common.ScenarioDatas;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Json;
//using System.Text;
//using System.Threading.Tasks;

//namespace api.karim_eshop.Tests.integra
//{
//    public class ProduitsControllerIntegrationTest : IClassFixture<WebApplicationFactory<Program>>, IDisposable
//    {
//        private readonly WebApplicationFactory<Program> _factory;
//        private readonly HttpClient _client;
//        protected readonly IKarimeshopDbContext _context;

//        public ProduitsControllerIntegrationTest(WebApplicationFactory<Program> factory)
//        {
//            _factory = factory.WithWebHostBuilder(builder =>
//            {
//                builder.UseEnvironment("Test");
//            });

//            _context = _factory.Services.GetService<IKarimeshopDbContext>()!;

//            _client = _factory.CreateClient();

//            _context!.Database.EnsureDeleted();
//            _context.Database.EnsureCreated();
//        }

//        [Fact]
//        public async Task GetProduits_ReturnAllUnites()
//        {
//            // Arrange
//            _context.CreateProduits();

//            // Act
//            var produits = await _factory.CreateClient().GetFromJsonAsync<List<ProduitDto>>("/api/Produit/GetProductsDTO");

//            // Assert
//            Assert.NotNull(produits);
//            Assert.NotEmpty(produits);
//            Assert.Equal(2, produits.Count);
//        }

//        public void Dispose()
//        {
//            _context.Database.EnsureDeleted();
//            _context.Dispose();
//        }
//    }
//}
