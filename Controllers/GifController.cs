using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GifAPI.Context;
using GifAPI.Models;

namespace GifAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GifController : ControllerBase
    {
        private readonly GifDbContext _context;

        public GifController(GifDbContext context)
        {
            _context = context;
        }

        // GET: api/Gif
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GifModel>>> GetMyGifs()
        {
            return await _context.MyGifs.ToListAsync();
        }

        // GET: api/Gif/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GifModel>> GetGifModel(int id)
        {
            var gifModel = await _context.MyGifs.FindAsync(id);

            if (gifModel == null)
            {
                return NotFound();
            }

            return gifModel;
        }

        // PUT: api/Gif/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGifModel(int id, [FromBody] GifInputModel model)
        {
            var gifModel = await _context.MyGifs.FindAsync(id);
            if (gifModel == null)
            {
                return BadRequest();
            }

            gifModel.Update(model.Name, model.Address);



            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GifModelExists(id))
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

        // POST: api/Gif
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GifModel>> PostGifModel([FromBody]GifInputModel model)
        {
            var gif = new GifModel(model.Name,model.Address);
            _context.MyGifs.Add(gif);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGifModel", new { id = gif.Id }, gif);
        }

        // DELETE: api/Gif/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGifModel(int id)
        {
            var gifModel = await _context.MyGifs.FindAsync(id);
            if (gifModel == null)
            {
                return NotFound();
            }

            _context.MyGifs.Remove(gifModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GifModelExists(int id)
        {
            return _context.MyGifs.Any(e => e.Id == id);
        }
    }
}
