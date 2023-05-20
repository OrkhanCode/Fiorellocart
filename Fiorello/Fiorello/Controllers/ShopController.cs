using Fiorello.Data;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.Products.Include("Category").Include("Images").Where(m => !m.SoftDelete).Take(4).ToListAsync();
            int count = await _context.Products.Where(m=> !m.SoftDelete).CountAsync();
            ViewBag.count = count;
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ShowMore(int skip)
        {
            IEnumerable<Product> products = await _context.Products.Where(m => !m.SoftDelete).Skip(skip).Take(4).ToListAsync();
            return PartialView("_ProductsPartial", products);
        }
    }
}
