using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundProjectAPI.Data;
using FundProjectAPI.Model;

namespace FundProjectMVC.Controllers
{
    public class ProjectCreatorDemo : Controller
    {
        private readonly FundContext _context;

        public ProjectCreatorDemo(FundContext context)
        {
            _context = context;
        }

        // GET: ProjectCreatorDemo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectCreators.ToListAsync());
        }

        // GET: ProjectCreatorDemo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectCreator = await _context.ProjectCreators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectCreator == null)
            {
                return NotFound();
            }

            return View(projectCreator);
        }

        // GET: ProjectCreatorDemo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectCreatorDemo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber")] ProjectCreator projectCreator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectCreator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectCreator);
        }

        // GET: ProjectCreatorDemo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectCreator = await _context.ProjectCreators.FindAsync(id);
            if (projectCreator == null)
            {
                return NotFound();
            }
            return View(projectCreator);
        }

        // POST: ProjectCreatorDemo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber")] ProjectCreator projectCreator)
        {
            if (id != projectCreator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectCreator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectCreatorExists(projectCreator.Id))
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
            return View(projectCreator);
        }

        // GET: ProjectCreatorDemo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectCreator = await _context.ProjectCreators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectCreator == null)
            {
                return NotFound();
            }

            return View(projectCreator);
        }

        // POST: ProjectCreatorDemo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectCreator = await _context.ProjectCreators.FindAsync(id);
            _context.ProjectCreators.Remove(projectCreator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectCreatorExists(int id)
        {
            return _context.ProjectCreators.Any(e => e.Id == id);
        }
    }
}
