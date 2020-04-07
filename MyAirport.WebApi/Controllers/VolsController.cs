using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GBO.MyAiport.EF;
using Microsoft.AspNetCore.Http;

namespace GBO.MyAirport.WebApi.Controllers
{
    /// <summary>
    /// Vols Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        /// <summary>
        /// Dependency injection of DatabaseContext
        /// </summary>
        /// <param name="context">MyAirportContext: DbContext</param>
        public VolsController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        /// <summary>
        /// Get all vols
        /// </summary>
        /// <param type="bool" name="bagages">Bring bagages with the response</param>
        /// <returns>List of Vol</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols([FromQuery(Name = "bagages")] bool bagages = false)
        {
            DbSet<Vol> dbSet = _context.Vols;
            if (bagages)
            {
                return await dbSet.Include(vol => vol.Bagages).ToListAsync();
            }

            return await dbSet.ToListAsync();
        }

        // GET: api/Vols/5
        /// <summary>
        /// Get specific vol
        /// </summary>
        /// <param type="int" name="id">Vol ID</param>
        /// <param type="bool" name="bagages">Bring bagages with the response</param>
        /// <returns>Vol</returns>
        /// <response code="404">Vol not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vol>> GetVol(int id, [FromQuery(Name = "bagages")] bool bagages = false)
        {
            DbSet<Vol> dbSet = _context.Vols;
            Vol vol;
            
            if (bagages)
                vol = await dbSet.Include(v => v.Bagages).FirstAsync(v => v.VolID == id);
            else
                vol = await dbSet.FindAsync(id);

            if (vol == null)
            {
                return NotFound();
            }

            return vol;
        }

        // PUT: api/Vols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Modify specified vol
        /// </summary>
        /// <param type="int" name="id">Vol Id to modify</param>
        /// <param type="Vol" name="vol">Modified Vol</param>
        /// <returns>No Content</returns>
        /// <response code="204">Object modified successfully</response>
        /// <response code="400">Vol is null</response>
        /// <response code="404">Vol not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolID)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Create a Vol
        /// </summary>
        /// <param type="Vol" name="vol">Vol to create</param>
        /// <returns>Vol location</returns>
        /// <response code="201">Vol created successfully</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new {id = vol.VolID}, vol);
        }

        // DELETE: api/Vols/5
        /// <summary>
        /// Delete specified vol
        /// </summary>
        /// <param type="int" name="id">Vol Id to delete</param>
        /// <returns>Deleted Vol</returns>
        /// <response code="404">Vol not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolID == id);
        }
    }
}