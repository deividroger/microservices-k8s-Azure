using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ProductContext _productContext;

    public ProductController(ILogger<ProductController> logger,ProductContext productContext)
    {
        _logger = logger;
        _productContext = productContext;
    }

    [HttpGet]
   public async Task< IEnumerable<Product>> Get() 
        =>await _productContext
                    .Products
                    .Find(p=> true)
                    .ToListAsync(); 
}