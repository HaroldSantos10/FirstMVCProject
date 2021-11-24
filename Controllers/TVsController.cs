using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComputProject.Controllers
{
    [Authorize]
    public class TVsController : Controller
    {
        private readonly TVsContext _context;

        public TVsController(TVsContext context)
        {
            _context = context;
        }

        // GET: TVs
        public async Task<IActionResult> Index()
        {
            var tVsContext = _context.TVs.Include(t => t.Stores);
            return View(await tVsContext.ToListAsync());
        }

        // GET: TVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVs = await _context.TVs
                .Include(t => t.Stores)
                .FirstOrDefaultAsync(m => m.tvId == id);
            if (tVs == null)
            {
                return NotFound();
            }

            return View(tVs);
        }

        // GET: TVs/Create
        public IActionResult Create()
        {
            ViewData["storeId"] = new SelectList(_context.Set<Store>(), "storeId", "Address");
            return View();
        }

        // POST: TVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvId,marca,modelo,color,size,year,storeId")] TVs tVs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tVs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["storeId"] = new SelectList(_context.Set<Store>(), "storeId", "Address", tVs.storeId);
            return View(tVs);
        }

        // GET: TVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVs = await _context.TVs.FindAsync(id);
            if (tVs == null)
            {
                return NotFound();
            }
            ViewData["storeId"] = new SelectList(_context.Set<Store>(), "storeId", "Address", tVs.storeId);
            return View(tVs);
        }

        // POST: TVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tvId,marca,modelo,color,size,year,storeId")] TVs tVs)
        {
            if (id != tVs.tvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tVs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVsExists(tVs.tvId))
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
            ViewData["storeId"] = new SelectList(_context.Set<Store>(), "storeId", "Address", tVs.storeId);
            return View(tVs);
        }

        // GET: TVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tVs = await _context.TVs
                .Include(t => t.Stores)
                .FirstOrDefaultAsync(m => m.tvId == id);
            if (tVs == null)
            {
                return NotFound();
            }

            return View(tVs);
        }

        // POST: TVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tVs = await _context.TVs.FindAsync(id);
            _context.TVs.Remove(tVs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVsExists(int id)
        {
            return _context.TVs.Any(e => e.tvId == id);
        }
    }
}
