using System.Collections.Generic;
using System.Threading.Tasks;
using GBO.MyAiport.EF;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GBO.MyAirport.Razor
{
    public class IndexVol : PageModel
    {
        private readonly MyAirportContext _context;

        public IndexVol(GBO.MyAiport.EF.MyAirportContext context)
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
