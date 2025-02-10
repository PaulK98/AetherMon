using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AetherMon.Services;
using AetherMon.Data;
using AetherMon.Models;

namespace AetherMon.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PokeAPIService _pokeService;
        private readonly AetherDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel( PokeAPIService pokeService, AetherDbContext context, ILogger<IndexModel> logger)
        {
            _pokeService = pokeService;
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public string ScanQuery { get; set; }

        public PokeAPIService.Pokemon ScannedPokemon { get; set; }
        public bool IsScanning { get; set; }

        public async Task<IActionResult> OnPostScanAsync()
        {
            try
            {
                IsScanning = true;
                if (!string.IsNullOrWhiteSpace(ScanQuery))
                {
                    ScannedPokemon = await _pokeService.GetPokemonAsync(ScanQuery);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Aether scan failed");
                ModelState.AddModelError(string.Empty, "Quantum interference detected! Scan failed.");
            }
            finally
            {
                IsScanning = false;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCaptureAsync(int pokemonId, string pokemonName, string apiUrl)
        {
            var capture = new AetherCapture
            {
                Name = pokemonName,
                PokemonId = pokemonId,
                ApiUrl = apiUrl ?? "https://pokeapi.co/api/v2/pokemon/"
            };

            // Add validation
            if (string.IsNullOrEmpty(capture.ApiUrl))
            {
                ModelState.AddModelError("", "Invalid Pokémon API URL");
                return Page();
            }

            // Add new pokemon (capture) to Captures (Db Set)
            _context.Captures.Add(capture);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Favorites");
        }
    }
}