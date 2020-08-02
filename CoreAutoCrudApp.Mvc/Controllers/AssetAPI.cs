using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAutoCrudApp.Data.Contexts;
using CoreAutoCrudApp.Data.Models;
using CoreAutoCrudApp.Data.Repositories;

namespace CoreAutoCrudApp.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetAPI : ControllerBase
    {
        private readonly AssetContext _context;

        public AssetAPI()
        {
            _context = new AssetContext();
        }

        // GET: api/AssetAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            return await _context.Assets.Take(10).ToListAsync();
        }

        // GET: api/AssetAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            return asset;
        }

        // PUT: api/AssetAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(Guid id, Asset asset)
        {
            if (id != asset.AssetId)
            {
                return BadRequest();
            }

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST: api/AssetAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsset", new { id = asset.AssetId }, asset);
        }

        // DELETE: api/AssetAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asset>> DeleteAsset(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();

            return asset;
        }

        private bool AssetExists(Guid id)
        {
            return _context.Assets.Any(e => e.AssetId == id);
        }
    }
}
