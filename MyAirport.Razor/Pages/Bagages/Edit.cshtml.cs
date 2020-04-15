using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GBO.MyAiport.EF;

namespace GBO.MyAirport.Razor.Bagages
{
    public class EditModel : PageModel
    {
        private readonly GBO.MyAiport.EF.MyAirportContext _context;

        public EditModel(GBO.MyAiport.EF.MyAirportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Vols = await getVolsAsSelectListItem();
            Bagage = await _context.Bagages.FirstOrDefaultAsync(m => m.BagageID == id);
            if (Bagage == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        private async Task<IEnumerable<SelectListItem>> getVolsAsSelectListItem()
        {
            var vols = await _context.Vols.Select(i => new SelectListItem()
            {
                Text = $"{i.Cie} {i.Lig} {i.Dhc}",
                Value = i.VolID.ToString()
            }).ToListAsync();
            vols.Insert(0, new SelectListItem() { Text = "", Value = "0"});
            return vols;
        }
        
        [BindProperty] public IEnumerable<SelectListItem> Vols { get; set; }

        [BindProperty] public int VolID { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (VolID != 0)
            {
                var vol = await _context.Vols.FirstAsync(v => v.VolID == VolID);
                if (vol == null)
                {
                    ModelState.AddModelError("vols", "Vol invalid");
                }
                else
                {
                    Bagage.Vol = vol;
                }
                
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(Bagage.BagageID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageID == id);
        }
    }
}
