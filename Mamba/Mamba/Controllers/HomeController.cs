using Mamba.DAL;
using Mamba.ViewModels.Teams;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mamba.Controllers
{
    public class HomeController(MambaDdContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }
    }
}
