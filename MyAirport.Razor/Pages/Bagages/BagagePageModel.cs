using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBO.MyAirport.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GBO.MyAirport.Razor.Bagages
{
    public abstract class BagagePageModel : PageModel
    {
        protected readonly MyAirportContext _context;
        [BindProperty] public IEnumerable<SelectListItem> Vols { get; set; }

        [BindProperty] public int? VolID { get; set; }
        [BindProperty] public Bagage Bagage { get; set; }


        protected BagagePageModel(MyAirportContext context)
        {
            _context = context;
            Bagage = new Bagage()
            {
                Vol =  null
            };
        }

        protected async Task<IEnumerable<SelectListItem>> GetVolsAsSelectListItem()
        {
            var vols = await _context.Vols.Select(i => new SelectListItem()
            {
                Text = $"{i.Cie} {i.Lig} {i.Dhc}",
                Value = i.VolID.ToString()
            }).ToListAsync();
            if (Bagage.Vol != null)
            {
                vols.ForEach(item => { item.Selected = item.Value == Bagage.Vol.VolID.ToString(); });
            }
            vols.Insert(0, new SelectListItem() {Text = "", Value = null, Selected = false});
            return vols;
        }

        protected async Task ValidateVol()
        {
            if (VolID != null)
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
            else
            {
                Bagage.Vol = null;
                _context.Entry(Bagage).Reference(b => b.Vol).IsModified = true;
            }
        }
    }
}