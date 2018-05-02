using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt.FlickrData;
using Projekt.GmapsData;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Controllers
{
    public class DiningExperiencesController : Controller
    {
        private readonly ProjektContext _context;
        private readonly IFlickrService _flickerService;
        private readonly IGmapsService _gmailService;

        public DiningExperiencesController(ProjektContext context, IFlickrService flickrService, IGmapsService gmailService)
        {
            _context = context;
            _flickerService = flickrService;
            _gmailService = gmailService;
        }

        // GET: DiningExperiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiningExperience.ToListAsync());
        }

        // GET: DiningExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diningExperience = await _context.DiningExperience
                .SingleOrDefaultAsync(m => m.Id == id);

            var diningExperience2 = await _context.DiningExperience.Include(t => t.SearchTagsList)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diningExperience == null)
            {
                return NotFound();
            }

            DiningExpDetailsVM dinExpDetailVM = new DiningExpDetailsVM();
            dinExpDetailVM.DinExp = diningExperience;
            dinExpDetailVM.Photos = _flickerService.GetPhotosByTagList(diningExperience.SearchTagsList);

            ViewData["GmapsAPIandKey"] = _gmailService.GetGmapsAPIandKey();

            return View(dinExpDetailVM);

            //return View(diningExperience);
        }

        // GET: DiningExperiences/Create
        public IActionResult Create()
        {
            ViewData["GmapsAPIandKey"] = _gmailService.GetGmapsAPIandKey();
            return View();
        }

        // POST: DiningExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Restaurant,Dish,Description")] DiningExperience diningExperience)
        public async Task<IActionResult> Create(DiningExperience diningExperience)
        {

            if (ModelState.IsValid)
            {
                _context.Add(diningExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diningExperience);
        }

        // GET: DiningExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diningExperience = await _context.DiningExperience.SingleOrDefaultAsync(m => m.Id == id);
            if (diningExperience == null)
            {
                return NotFound();
            }
            return View(diningExperience);
        }

        // POST: DiningExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Restaurant,Dish,Description,Latitude,Longitude")] DiningExperience diningExperience)
        {
            if (id != diningExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diningExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiningExperienceExists(diningExperience.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(diningExperience);
        }

        // GET: DiningExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diningExperience = await _context.DiningExperience
                .SingleOrDefaultAsync(m => m.Id == id);
            if (diningExperience == null)
            {
                return NotFound();
            }

            return View(diningExperience);
        }

        // POST: DiningExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diningExperience = await _context.DiningExperience.SingleOrDefaultAsync(m => m.Id == id);
            _context.DiningExperience.Remove(diningExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [AjaxOnly]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult NewItem()
        {
            return PartialView("SearchTag", new SearchTag());
        }

        private bool DiningExperienceExists(int id)
        {
            return _context.DiningExperience.Any(e => e.Id == id);
        }
    }
}
