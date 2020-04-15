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
    public class EditModel : BagagePageModel
    {
        public EditModel(MyAirportContext context) : base(context)
        {
        }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Bagage = await _context.Bagages.Include(b => b.Vol).FirstOrDefaultAsync(m => m.BagageID == id);
            Vols = await GetVolsAsSelectListItem();
            if (Bagage == null)
            {
                return NotFound();
            }

            return Page();
        }
        

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await ValidateVol();

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

            return RedirectToPage("./Details", new { id = Bagage.BagageID });
        }

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageID == id);
        }
    }
}