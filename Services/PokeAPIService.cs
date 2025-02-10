using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AetherMon.Services
{
    /// <summary>
    /// Handles communication with the external PokeAPI
    /// </summary>
    public class PokeAPIService
    {
        private readonly HttpClient _httpClient;

        public PokeAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("https://pokeapi.co/api/v2/");
        }

        /// <summary>
        /// Fetches Pokémon data by name or ID
        /// </summary>
        public async Task<Pokemon> GetPokemonAsync(string identifier)
        {
            try
            {
                var response = await _httpClient.GetAsync($"pokemon/{identifier.ToLower()}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pokemon>(json)
                    ?? new Pokemon { Name = "Unknown Pokémon" };
            }
            catch
            {
                return new Pokemon { Name = "Error Pokémon" };
            }
        }

        /// <summary>
        /// Fetches paginated list of Pokémon
        /// </summary>
        public async Task<PokemonList> GetPokemonBatchAsync(int offset = 0, int limit = 20)
        {
            return await _httpClient.GetFromJsonAsync<PokemonList>($"pokemon?offset={offset}&limit={limit}");
        }

        /// <summary>
        /// API Responses
        /// </summary>

        #region API Response Classes
        public class Pokemon
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Sprites Sprites { get; set; }
            public string Url { get; set; }
            public List<TypeSlot> Types { get; set; } = new();
            public List<Ability> Abilities { get; set; } = new();
            public List<Stat> Stats { get; set; } = new();

            // Additional properties as needed
        }

        public class Sprites
        {
            public string FrontDefault { get; set; }
            public OtherSprites Other { get; set; }
        }

        public class OtherSprites
        {
            [JsonProperty("official-artwork")]
            public OfficialArtwork OfficialArtwork { get; set; }
        }

        public class OfficialArtwork
        {
            public string FrontDefault { get; set; }
        }

        public class PokemonList
        {
            public List<PokemonResult> Results { get; set; }
        }

        public class PokemonResult
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class TypeSlot
        {
            public int Slot { get; set; }
            public Type Type { get; set; }
        }

        public class Type
        {
            public string Name { get; set; }
        }

        public class Ability
        {
            [JsonProperty("is_hidden")]
            public bool IsHidden { get; set; }

            [JsonProperty("ability")]
            public AbilityDetail AbilityInfo { get; set; } = new AbilityDetail();
        }

        public class AbilityDetail
        {
            [JsonProperty("name")]
            public string Name { get; set; } = "Unknown Ability";

            [JsonProperty("url")]
            public string Url { get; set; } = string.Empty;
        }

        public class Stat
        {
            [JsonProperty("base_stat")]
            public int BaseStat { get; set; }

            [JsonProperty("stat")]
            public StatDetail StatInfo { get; set; } = new StatDetail();
        }

        public class StatDetail
        {
            [JsonProperty("name")]
            public string Name { get; set; } = "Unknown Stat";
        }
        #endregion
    }
}
