using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();

            SliderDetail sliderDetail = await _context.SliderDetails.Where(m => !m.SoftDelete).FirstOrDefaultAsync();

            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Product> products = await _context.Products.Include("Category").Include("Images").Where(m => !m.SoftDelete).ToListAsync();

            About about = await _context.About.Include("Lists").Where(m => !m.SoftDelete).FirstOrDefaultAsync();

            IEnumerable<Expert> experts = await _context.Experts.Where(m => !m.SoftDelete).ToListAsync();

            BlogHeader blogHeader = await _context.BlogHeader.FirstOrDefaultAsync();

            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Comment> comments = await _context.Comments.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Instagram> instagram = await _context.Instagram.Where(m => !m.SoftDelete).ToListAsync();

            HomeVM model = new() 
            { 
                Sliders = sliders,
                SliderDetail = sliderDetail,
                Categories = categories,
                Products  = products,
                About = about,
                Experts = experts,
                BlogHeader = blogHeader,
                Blogs = blogs,
                Comments = comments,
                Instagram = instagram
            };

            return View(model);
        }
    }
}