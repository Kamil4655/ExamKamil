using Mamba.DAL;
using Mamba.Models;
using Mamba.ViewModels.Teams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;

namespace Mamba.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamsController(MambaDdContext _context, IWebHostEnvironment _env) : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View(await _context.Teams.Select(s => new GetTeamVM
            {
                Id = s.Id,
                ImageFile = s.ImageFile,
                Name = s.Name,
                Job = s.Job,
                SocialMedia = s.SocialMedia,
            }).ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateTeamVM vm)
        {
            if (!ModelState.IsValid) return BadRequest();
            string fileName = Guid.NewGuid().ToString() + vm.ImageFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets", "imgs", fileName);
            FileStream fileStream = new FileStream(path, FileMode.Create);
            await vm.ImageFile.CopyToAsync(fileStream);
            await _context.Teams.AddAsync(new Team
            {
                ImageUrl = fileName,
                Name = vm.Name,
                CreatedTime = DateTime.Now,
                Job = vm.Job,
                SocialMedia = vm.SocialMedia,
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();
            var model = new EditTeamVM
            {
                Job = team.Job,
                Name = team.Name,
                SocialMedia = team.SocialMedia
                
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int? id, EditTeamVM vm)
        {
            if(id == null) return BadRequest();
            var existed = await _context.Teams.FindAsync(id);
            if (existed == null) return BadRequest(vm);
            existed.UpdatedTime = DateTime.Now;
            existed.Job = vm.Job;
            existed.Name = vm.Name;
            existed.ImageUrl = vm.ImageFile;
            existed.SocialMedia = vm.SocialMedia;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var delete = await _context.Teams.FindAsync(id);
            if (delete == null) return NotFound();
            _context.Teams.Remove(delete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}
