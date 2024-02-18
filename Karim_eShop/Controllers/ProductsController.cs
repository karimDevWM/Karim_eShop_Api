using api.Karim_eshop.Business.DTOs;
using api.Karim_eshop.Business.Service;
using api.Karim_eshop.Common.Extensions;
using api.Karim_eshop.Common.RequestHelpers;
using api.Karim_eshop.Data.Entity;
using api.Karim_eshop.Data.Entity.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Karim_eShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly KarimeshopDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(KarimeshopDbContext context, IMapper mapper, SignInManager<User> signInManager,
            UserManager<User> userManager, ILogger<ProductsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException( nameof(ProductsController));
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery] ProductParams productParams)
        {
            var query = _context.Products
                //.Sort(productParams.OrderBy)
                //.Search(productParams.SearchTerm)
                //.Filter(productParams.Brands, productParams.Types)
                .AsQueryable
                ();

            var products =
                await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);

            Response.AddPaginationHeader(products.MetaData);

            return products;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsWithoutFilters()
        {
            //var query = _context.Products
            //    //.Sort(productParams.OrderBy)
            //    //.Search(productParams.SearchTerm)
            //    //.Filter(productParams.Brands, productParams.Types)
            //    .AsQueryable
            //    ();

            var products = await _context.Products.ToListAsync();

            //Response.AddPaginationHeader(products.MetaData);

            return products;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();

            return product;
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var brands = await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();
            var types = await _context.Products.Select(p => p.Type).Distinct().ToListAsync();

            return Ok(new { brands, types });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductDto productDto)
        {

            var product = _mapper.Map<Product>(productDto);

            _context.Products.Add(product);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return CreatedAtRoute("GetProduct", new { Id = product.Id }, product);

            return BadRequest(new ProblemDetails { Title = "Problem creating new product" });

            //if(_signInManager.IsSignedIn(User))
            //{
            //    var user = await _userManager.GetUserAsync(User);

            //    var roles = await _userManager.GetRolesAsync(user);

            //    foreach (var role in roles)
            //    {
            //        if (role == "Admin")
            //        {

            //        }
            //    }
            //}

            return Unauthorized();
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPut]
        //public async Task<ActionResult<Product>> UpdateProduct([FromForm] UpdateProductDto productDto)
        //{
        //    var product = await _context.Products.FindAsync(productDto.Id);

        //    if (product == null) return NotFound();

        //    _mapper.Map(productDto, product);

        //    _mapper.Map(productDto, product);

        //    var result = await _context.SaveChangesAsync() > 0;

        //    if (result) return Ok(product);

        //    return BadRequest(new ProblemDetails { Title = "Problem updating product" });
        //}

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();

            _context.Products.Remove(product);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem deleting product" });
        }
    }
}
