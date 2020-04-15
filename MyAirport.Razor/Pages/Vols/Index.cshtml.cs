using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GBO.MyAiport.EF;

namespace GBO.MyAirport.Razor.Vols
{
    public class IndexModel : PageModel
    {
        private readonly MyAirportContext _context;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        public IndexModel(MyAirportContext context)
        {
            _context = context;
        }
        
        [BindProperty] public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
            FilterVols();
        }

        public void FilterVols()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                Vol = Vol.Where(s => String.Join(' ', new String[]{s.Cie, s.Lig, s.Dhc.HasValue ? s.Dhc.ToString() : string.Empty}).ToLower().Contains(SearchString.ToLower())).ToList();
            }
        }
    }
}
