using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using CoreAutoCrudApp.Data.Contexts;
using CoreAutoCrudApp.Data.Models;
using CoreAutoCrudApp.Data.Pagination;
using CoreAutoCrudApp.Data.Repositories;

namespace CoreAutoCrudApp.React.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetAPIController : ControllerBase
    {
        private readonly AssetContext _context;
        private readonly AssetRepository _repo;

        private readonly ILogger<AssetAPIController> _logger;

        public AssetAPIController(ILogger<AssetAPIController> logger)
        {
            _logger = logger;
            _repo = new AssetRepository();
            _context = new AssetContext();
        }

       // GET: api/AssetAPI
        [HttpGet]
        public async Task<PagedResult<Asset>> Get(int page = 1, int pageSize = 10)
        {
            _logger.LogDebug($"Getting {pageSize} assets - page {page}.");
            var result = await _repo.GetPagedAssetsOverview(page, pageSize);
            return result;
        }

        // GET: api/AssetAPI/5
        [HttpGet("{id}")]
        public async Task<Asset> GetAsset(Guid id)
        {
            var asset = await _repo.GetById(id);

            if (asset == null)
            {
                _logger.LogDebug($"Asset with ID {id} not found.");
                return null;
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
                _logger.LogDebug($"Invalid asset {id} provided.");
                return BadRequest();
            }

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!AssetExists(id))
                {
                    _logger.LogError($"Asset with ID {id} does not exist. Details: {ex.Message}");
                    return NotFound();
                }
                else
                {
                    _logger.LogError($"Details: {ex.Message}");
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsset", new { id = asset.AssetId }, asset);
        }

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