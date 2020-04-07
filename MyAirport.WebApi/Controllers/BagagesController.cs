using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GBO.MyAiport.EF;

namespace GBO.MyAirport.WebApi.Controllers
{
    /// <summary>
    /// Bagage Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BagagesController : ControllerBase
    {
        private readonly MyAirportContext _context;

        /// <summary>
        /// Dependency injection of DatabaseContext
        /// </summary>
        /// <param type="MyAirportContext" name="context">MyAirportContext: DbContext</param>
        public BagagesController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Bagages
        /// <summary>
        /// Get all bagages
        /// </summary>
        /// <returns>List of Bagages></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Bagage>>> GetBagages()
        {
            return await _context.Bagages.Include(b => b.Vol).ToListAsync();
        }

        // GET: api/Bagages/5
        /// <summary>
        /// Get a specific bagage
        /// </summary>
        /// <param type="int" name="id">bagage id</param>
        /// <returns>Bagage</returns>
        /// <response code="404">Bagage not found</response>    
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bagage>> GetBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);

            if (bagage == null)
            {
                return NotFound();
            }

            return bagage;
        }

        // PUT: api/Bagages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Modify a specific Bagage
        /// </summary>
        /// <param type="int" name="id">Bagage Id to change</param>
        /// <param type="Bagage" name="bagage">Bagage modified</param>
        /// <returns>NoContent</returns>
        /// <response code="204">Bagage modified successefully</response>
        /// <response code="400">Bagage is null</response>
        /// <response code="404">Bagage not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBagage(int id, Bagage bagage)
        {
            if (id != bagage.BagageID)
            {
                return BadRequest();
            }

            _context.Entry(bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(id))
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

        // POST: api/Bagages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Create a bagage
        /// </summary>
        /// <param name="bagage">Bagage object</param>
        /// <returns>No Content</returns>
        /// <response code="201">Bagage created successfully</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Bagage>> PostBagage(Bagage bagage)
        {
            _context.Bagages.Add(bagage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagage", new { id = bagage.BagageID }, bagage);
        }

        // DELETE: api/Bagages/5
        /// <summary>
        /// Delete a bagage
        /// </summary>
        /// <param name="id">Bagage Id</param>
        /// <returns>Deleted Bagage</returns>
        /// <response code="200">Bagage deleted successfully</response>
        /// <response code="404">Bagage not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bagage>> DeleteBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);
            if (bagage == null)
            {
                return NotFound();
            }

            _context.Bagages.Remove(bagage);
            await _context.SaveChangesAsync();

            return bagage;
        }

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageID == id);
        }
    }
}
