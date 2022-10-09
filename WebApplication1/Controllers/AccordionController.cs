using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace OneTwoMany_Fiorello.Controllers
{
    public class AccordionController : Controller
    {
        private readonly AppDbContext _context;
        public AccordionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            AccordionTitle accordionTitle = await _context.AccordionTitle.FirstOrDefaultAsync();
            IEnumerable<AccordionDetail> accordionDetails = await _context.AccordionDetails.ToListAsync();

            AccordionVM accordionVM = new AccordionVM
            {
                AccordionTitle = accordionTitle,
                AccordionDetails = accordionDetails
            };

            return View(accordionVM);
        }
    }
}