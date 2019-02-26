using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApiMVC_Example1.Models
{
    public class ExampleModelsController : Controller
    {
        private readonly WebApiMVC_Example1Context _context;

        public ExampleModelsController(WebApiMVC_Example1Context context)
        {
            _context = context;
        }

        // GET: ExampleModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExampleModel.ToListAsync());
        }

        // GET: ExampleModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exampleModel = await _context.ExampleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exampleModel == null)
            {
                return NotFound();
            }

            return View(exampleModel);
        }

        // GET: ExampleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExampleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age")] ExampleModel exampleModel)
        {
            if (ModelState.IsValid)
            {
                exampleModel.Id = Guid.NewGuid();
                _context.Add(exampleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exampleModel);
        }

        // GET: ExampleModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exampleModel = await _context.ExampleModel.FindAsync(id);
            if (exampleModel == null)
            {
                return NotFound();
            }
            return View(exampleModel);
        }

        // POST: ExampleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Age")] ExampleModel exampleModel)
        {
            if (id != exampleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exampleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExampleModelExists(exampleModel.Id))
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
            return View(exampleModel);
        }

        // GET: ExampleModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exampleModel = await _context.ExampleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exampleModel == null)
            {
                return NotFound();
            }

            return View(exampleModel);
        }

        // POST: ExampleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exampleModel = await _context.ExampleModel.FindAsync(id);
            _context.ExampleModel.Remove(exampleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExampleModelExists(Guid id)
        {
            return _context.ExampleModel.Any(e => e.Id == id);
        }
    }
}
