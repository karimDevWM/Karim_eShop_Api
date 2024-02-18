//using api.Karim_eshop.Business.DTOs;
//using api.Karim_eshop.Business.Service.Contract;
//using api.Karim_eshop.Data.Repository.Contract;
//using AutoMapper;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;

//namespace Karim_eShop.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class ProduitController : ControllerBase
//    {
//        private readonly IProduitService _produitService;

//        /// <summary>
//        /// Initialize a new instance of the <see cref="ProductController"/> class.
//        /// </summary>
//        /// <param name="productService">The product service.</param>
//        public ProduitController(IProduitService produitService)
//        {
//            _produitService = produitService;
//        }

//        // POST api/Produit
//        /// <summary>
//        /// Ressource pour créer un nouveau produit.
//        /// </summary>
//        /// <param name="produit">les données du produit à créer</param>
//        /// <returns></returns>
//        [HttpPost]
//        [ProducesResponseType(typeof(ProduitDto), 200)]
//        public async Task<ActionResult> CreateProductsDTOAsync([FromBody] ProduitDto produitDTO)
//        {
//            try
//            {
//                var productAdded = await _produitService.CreateProductDTOAsync(produitDTO);

//                return Ok(productAdded);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new
//                {
//                    Error = ex.Message,
//                });
//            }
//        }

//        // Get api/Produits
//        /// <summary>
//        /// Ressource pour créer un nouveau produit.
//        /// </summary>
//        /// <param name="produit">les données du produit à créer</param>
//        /// <returns></returns>
//        [HttpGet]
//        [ProducesResponseType(typeof(ProduitDto), 200)]
//        public async Task<ActionResult> GetProductsDTOAsync()
//        {
//            try
//            {
//                var products = await _produitService.GetProductsAsync();

//                return Ok(products);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new
//                {
//                    Error = ex.Message,
//                });
//            }
//        }

//        // Get api/Produit
//        /// <summary>
//        /// Ressource pour récupérer un produit par son id.
//        /// </summary>
//        /// <param name="produit">les données du produit à récupérer</param>
//        /// <returns></returns>
//        [HttpGet()]
//        [ProducesResponseType(typeof(ProduitDto), 200)]
//        public async Task<ActionResult> GetProductByIdAsync(int produitId)
//        {
//            try
//            {
//                var product = await _produitService.GetProductByIdAsync(produitId).ConfigureAwait(false);

//                return Ok(product);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new
//                {
//                    Error = ex.Message,
//                });
//            }
//        }

//        [HttpPut("{id}")]
//        [ProducesResponseType(typeof(ProduitDto), 200)]
//        public async Task<ActionResult> UpdateProductAsync([FromBody] ProduitDto produitDto, int produitId)
//        {
//            try
//            {
//                var product = await _produitService.UpdateProductAsync(produitDto, produitId).ConfigureAwait(false);

//                return Ok(product);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new
//                {
//                    Error = ex.Message,
//                });
//            }
//        }
//    }
//}
