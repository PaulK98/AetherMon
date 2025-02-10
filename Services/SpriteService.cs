namespace AetherMon.Services
{
    /// <summary>
    /// Provides URLs for Pokémon sprites based on different animation styles
    /// </summary>
    public static class SpriteService
    {
        /// <summary>
        /// Returns animated sprite URL based on Pokémon ID
        /// </summary>
        public static string GetAnimatedSprite(int pokemonId)
        {
            return pokemonId switch
            {
                // Modern sprites for newer Pokémon
                > 890 => $"https://projectpokemon.org/images/sprites-models/sv-sprites/{pokemonId}.gif",
                // Classic animated sprites for original Pokémon
                _ => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/versions/generation-v/black-white/animated/{pokemonId}.gif"
            };
        }

        /// <summary>
        /// Returns high-resolution official artwork
        /// </summary>
        public static string GetOfficialArtwork(int pokemonId)
        {
            return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{pokemonId}.png";
        }
    }
}
