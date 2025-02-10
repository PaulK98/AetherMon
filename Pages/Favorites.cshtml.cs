using AetherMon.Data;
using AetherMon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AetherMon.Pages
{
    public class FavoritesModel : PageModel
    {
        private readonly AetherDbContext _context;

        public List<AetherCapture> CapturedPokemon { get; set; } = new();

        public FavoritesModel(AetherDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            CapturedPokemon = await _context.Captures
                .OrderByDescending(c => c.CaptureTime)
                .ToListAsync();
        }

        // Handler of delete pokemon functionality
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var capture = await _context.Captures.FindAsync(id);

            if (capture != null)
            {
                _context.Captures.Remove(capture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}