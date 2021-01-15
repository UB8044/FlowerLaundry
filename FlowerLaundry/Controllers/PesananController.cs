using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlowerLaundry.Models;

namespace FlowerLaundry.Controllers
{
    public class PesananController : Controller
    {
        private readonly DBFlowerLaundryContext _context;

        public PesananController(DBFlowerLaundryContext context)
        {
            _context = context;
        }

        // GET: Pesanan
        public async Task<IActionResult> Index(string search)
        {
            var menu = from m in _context.Pesanan.Include(p => p.IdCustomerNavigation).Include(p => p.IdKaryawanNavigation) select m;

            if (!string.IsNullOrEmpty(search))
            {
                menu = menu.Where(s => s.IdCustomerNavigation.NamaCustomer.Contains(search) || s.IdKaryawanNavigation.NamaKaryawan.Contains(search));
            }

            return View(await menu.ToListAsync());
        }

        // GET: Pesanan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.IdKaryawanNavigation)
                .FirstOrDefaultAsync(m => m.NoPesanan == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // GET: Pesanan/Create
        public IActionResult Create()
        {
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "NamaCustomer");
            ViewData["IdKaryawan"] = new SelectList(_context.Karyawan, "IdKaryawan", "NamaKaryawan");
            return View();
        }

        // POST: Pesanan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoPesanan,Berat,Pelayanan,HrgTotal,TglOrder,IdKaryawan,IdCustomer")] Pesanan pesanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "NamaCustomer", pesanan.IdCustomer);
            ViewData["IdKaryawan"] = new SelectList(_context.Karyawan, "IdKaryawan", "NamaKaryawan", pesanan.IdKaryawan);
            return View(pesanan);
        }

        // GET: Pesanan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan.FindAsync(id);
            if (pesanan == null)
            {
                return NotFound();
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "NamaCustomer", pesanan.IdCustomer);
            ViewData["IdKaryawan"] = new SelectList(_context.Karyawan, "IdKaryawan", "NamaKaryawan", pesanan.IdKaryawan);
            return View(pesanan);
        }

        // POST: Pesanan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoPesanan,Berat,Pelayanan,HrgTotal,TglOrder,IdKaryawan,IdCustomer")] Pesanan pesanan)
        {
            if (id != pesanan.NoPesanan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesananExists(pesanan.NoPesanan))
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
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "NamaCustomer", pesanan.IdCustomer);
            ViewData["IdKaryawan"] = new SelectList(_context.Karyawan, "IdKaryawan", "NamaKaryawan", pesanan.IdKaryawan);
            return View(pesanan);
        }

        // GET: Pesanan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanan
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.IdKaryawanNavigation)
                .FirstOrDefaultAsync(m => m.NoPesanan == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // POST: Pesanan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pesanan = await _context.Pesanan.FindAsync(id);
            _context.Pesanan.Remove(pesanan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesananExists(int id)
        {
            return _context.Pesanan.Any(e => e.NoPesanan == id);
        }
    }
}
