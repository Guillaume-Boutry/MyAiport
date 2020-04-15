using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GBO.MyAiport.EF;
using Microsoft.EntityFrameworkCore;

namespace GBO.MyAirport.Razor.Bagages
{
    public class CreateModel : PageModel
    {
        private readonly GBO.MyAiport.EF.MyAirportContext _context;

        public CreateModel(GBO.MyAiport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Vols = await getVolsAsSelectListItem();

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
        
        
        [BindProperty] public Bagage Bagage { get; set; }

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


            _context.Bagages.Add(Bagage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}