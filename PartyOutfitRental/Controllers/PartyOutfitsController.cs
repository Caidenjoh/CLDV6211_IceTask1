using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartyOutfitRental.Data;
using PartyOutfitRental.Models;

namespace PartyOutfitRental.Controllers
{
    public class PartyOutfitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartyOutfitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PartyOutfits
        public async Task<IActionResult> Index(bool onlyAvailable = false)
        {
            var outfits = from m in _context.PartyOutfits
                          select m;
            if (onlyAvailable)
            {
                outfits = outfits.Where(o => o.Availability);
            }

            return View(await outfits.ToListAsync());
        }

        // GET: PartyOutfits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyOutfit = await _context.PartyOutfits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partyOutfit == null)
            {
                return NotFound();
            }

            return View(partyOutfit);
        }

        // GET: PartyOutfits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartyOutfits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Size,Price,Availability")] PartyOutfit partyOutfit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partyOutfit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partyOutfit);
        }

        // GET: PartyOutfits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyOutfit = await _context.PartyOutfits.FindAsync(id);
            if (partyOutfit == null)
            {
                return NotFound();
            }
            return View(partyOutfit);
        }

        // POST: PartyOutfits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Size,Price,Availability")] PartyOutfit partyOutfit)
        {
            if (id != partyOutfit.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partyOutfit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyOutfitExists(partyOutfit.ID))
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
            return View(partyOutfit);
        }

        // GET: PartyOutfits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyOutfit = await _context.PartyOutfits
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partyOutfit == null)
            {
                return NotFound();
            }

            return View(partyOutfit);
        }

        // POST: PartyOutfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partyOutfit = await _context.PartyOutfits.FindAsync(id);
            if (partyOutfit != null)
            {
                _context.PartyOutfits.Remove(partyOutfit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyOutfitExists(int id)
        {
            return _context.PartyOutfits.Any(e => e.ID == id);
        }
    }
}
