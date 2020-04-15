using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GBO.MyAiport.EF;

namespace MyAirport.Razor.Pages.Vols
{
    public class IndexModel : PageModel
    {
        private readonly GBO.MyAiport.EF.MyAirportContext _context;

        public IndexModel(GBO.MyAiport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
        }
    }
}
