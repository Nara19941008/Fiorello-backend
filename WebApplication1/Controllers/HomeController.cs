using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
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
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderDetail sliderDetail = await _context.SliderDetails.FirstOrDefaultAsync();
            IEnumerable<Category> categories = await _context.Categories.Where(m => m.IsDeleted == false).ToListAsync();
            IEnumerable<Product> products = await _context.Products
                .Where(m => m.IsDeleted == false)
                .Include(m => m.Category)
                .Include(m => m.ProductImages).Take(8).ToListAsync();
            IEnumerable<About> Abouts = await _context.Abouts.FirstOrDefaultAsync();
            ExpertTitle expertTitle = await _context.ExpertTitle.FirstOrDefaultAsync();
            IEnumerable<Expert> experts = await _context.Experts.ToListAsync();
            Subscribe subscribe = await _context.Subscribe.FirstOrDefaultAsync();
            BlogTitle blogTitle = await _context.BlogTitle.FirstOrDefaultAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.ToListAsync();
            IEnumerable<Say> says = await _context.Says.ToListAsync();
            IEnumerable<Instagram> instagrams = await _context.Instagrams.ToListAsync();

            HomeVM model = new HomeVM
            {
                Sliders = sliders,
                SliderDetail = sliderDetail,
                Categories = categories,
                Products=products,
                About=abouts,
                ExpertTitle = expertTitle,
                Experts = experts,
                Subscribe = subscribe,
                BlogTitle = blogTitle,
                Blogs = blogs,
                Instagrams = instagrams
            };

            return View(homeVM);
        }
    }
}
