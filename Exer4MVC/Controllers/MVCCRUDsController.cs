using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exer4MVC.Data;
using Exer4MVC.Models;

namespace Exer4MVC.Controllers
{
    public class MVCCRUDsController : Controller
    {
        private readonly Exer4MVCContext _context;

        public MVCCRUDsController(Exer4MVCContext context)
        {
            _context = context;
        }

        // GET: MVCCRUDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MVCCRUD.ToListAsync());
        }

        // GET: MVCCRUDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVCCRUD = await _context.MVCCRUD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mVCCRUD == null)
            {
                return NotFound();
            }

            return View(mVCCRUD);
        }

        // GET: MVCCRUDs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVCCRUDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Firstname,Lastname,MI,Emailaddress,Address,Age,Contact")] MVCCRUD mVCCRUD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mVCCRUD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mVCCRUD);
        }

        // GET: MVCCRUDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVCCRUD = await _context.MVCCRUD.FindAsync(id);
            if (mVCCRUD == null)
            {
                return NotFound();
            }
            return View(mVCCRUD);
        }

        // POST: MVCCRUDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Firstname,Lastname,MI,Emailaddress,Address,Age,Contact")] MVCCRUD mVCCRUD)
        {
            if (id != mVCCRUD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mVCCRUD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MVCCRUDExists(mVCCRUD.Id))
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
            return View(mVCCRUD);
        }

        // GET: MVCCRUDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mVCCRUD = await _context.MVCCRUD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mVCCRUD == null)
            {
                return NotFound();
            }

            return View(mVCCRUD);
        }

        // POST: MVCCRUDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mVCCRUD = await _context.MVCCRUD.FindAsync(id);
            _context.MVCCRUD.Remove(mVCCRUD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MVCCRUDExists(int id)
        {
            return _context.MVCCRUD.Any(e => e.Id == id);
        }
    }
}
