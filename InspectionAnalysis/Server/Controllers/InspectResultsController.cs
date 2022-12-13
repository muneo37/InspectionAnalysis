using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InspectionAnalysis;

namespace InspectionAnalysis.Server.Controllers
{
    public class InspectResultsController : Controller
    {
        private readonly InspectionDatasContext _context;

        public InspectResultsController(InspectionDatasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public InspectResult Get()
        {
            return new InspectResult();
        }


        // GET: InspectResults
        public async Task<IActionResult> Index()
        {
            var inspectionDatasContext = _context.InspectResults.Include(i => i.WorkData);
            return View(await inspectionDatasContext.ToListAsync());
        }

        // GET: InspectResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InspectResults == null)
            {
                return NotFound();
            }

            var inspectResult = await _context.InspectResults
                .Include(i => i.WorkData)
                .FirstOrDefaultAsync(m => m.InspectResultId == id);
            if (inspectResult == null)
            {
                return NotFound();
            }

            return View(inspectResult);
        }

        // GET: InspectResults/Create
        public IActionResult Create()
        {
            ViewData["WorkDataId"] = new SelectList(_context.WorkDatas, "WorkDataId", "WorkDataName");
            return View();
        }

        // POST: InspectResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectResultId,WorkDataId,CameraNo,PCNo,Count,IsOK,InspTime")] InspectResult inspectResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspectResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkDataId"] = new SelectList(_context.WorkDatas, "WorkDataId", "WorkDataName", inspectResult.WorkDataId);
            return View(inspectResult);
        }

        // GET: InspectResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InspectResults == null)
            {
                return NotFound();
            }

            var inspectResult = await _context.InspectResults.FindAsync(id);
            if (inspectResult == null)
            {
                return NotFound();
            }
            ViewData["WorkDataId"] = new SelectList(_context.WorkDatas, "WorkDataId", "WorkDataName", inspectResult.WorkDataId);
            return View(inspectResult);
        }

        // POST: InspectResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InspectResultId,WorkDataId,CameraNo,PCNo,Count,IsOK,InspTime")] InspectResult inspectResult)
        {
            if (id != inspectResult.InspectResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspectResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectResultExists(inspectResult.InspectResultId))
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
            ViewData["WorkDataId"] = new SelectList(_context.WorkDatas, "WorkDataId", "WorkDataName", inspectResult.WorkDataId);
            return View(inspectResult);
        }

        // GET: InspectResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InspectResults == null)
            {
                return NotFound();
            }

            var inspectResult = await _context.InspectResults
                .Include(i => i.WorkData)
                .FirstOrDefaultAsync(m => m.InspectResultId == id);
            if (inspectResult == null)
            {
                return NotFound();
            }

            return View(inspectResult);
        }

        // POST: InspectResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InspectResults == null)
            {
                return Problem("Entity set 'InspectionDatasContext.InspectResults'  is null.");
            }
            var inspectResult = await _context.InspectResults.FindAsync(id);
            if (inspectResult != null)
            {
                _context.InspectResults.Remove(inspectResult);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectResultExists(int id)
        {
          return _context.InspectResults.Any(e => e.InspectResultId == id);
        }
    }
}
