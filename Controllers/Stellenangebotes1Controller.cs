using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bewerber.Data;
using Bewerber.Models;

namespace Bewerber.Controllers
{
    public class Stellenangebotes1Controller : Controller
    {
        private readonly StellenangeboteContext _context;

        public Stellenangebotes1Controller(StellenangeboteContext context)
        {
            _context = context;
        }

        // GET: Stellenangebotes1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stellenanzeigen.ToListAsync());
        }

        // GET: Stellenangebotes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellenangebote = await _context.Stellenanzeigen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stellenangebote == null)
            {
                return NotFound();
            }

            return View(stellenangebote);
        }

        // GET: Stellenangebotes1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stellenangebotes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NL,BEZ,Detail,VDatum,BDatum,Preis,Referenz,Gesamt,Eingestellt,Unbearbeitet")] Stellenangebote stellenangebote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stellenangebote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stellenangebote);
        }

        // GET: Stellenangebotes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellenangebote = await _context.Stellenanzeigen.FindAsync(id);
            if (stellenangebote == null)
            {
                return NotFound();
            }
            return View(stellenangebote);
        }

        // POST: Stellenangebotes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NL,BEZ,Detail,VDatum,BDatum,Preis,Referenz,Gesamt,Eingestellt,Unbearbeitet")] Stellenangebote stellenangebote)
        {
            if (id != stellenangebote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stellenangebote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StellenangeboteExists(stellenangebote.Id))
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
            return View(stellenangebote);
        }

        // GET: Stellenangebotes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellenangebote = await _context.Stellenanzeigen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stellenangebote == null)
            {
                return NotFound();
            }

            return View(stellenangebote);
        }

        // POST: Stellenangebotes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stellenangebote = await _context.Stellenanzeigen.FindAsync(id);
            _context.Stellenanzeigen.Remove(stellenangebote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StellenangeboteExists(int id)
        {
            return _context.Stellenanzeigen.Any(e => e.Id == id);
        }
    }
}
