using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public SliderDetail SliderDetail { get; set; }
        public About Abouts { get; set; }
        public AboutDetail AboutDetail { get; set; }
    }
}
