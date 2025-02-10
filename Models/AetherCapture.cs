using System;

namespace AetherMon.Models
{
        /// <summary>
        /// Represents a Pokémon captured and stored in the Aether system
        /// </summary>
        public class AetherCapture
        {
            /// <summary>
            /// Unique database identifier
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Pokémon name in lowercase (matches API format)
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Original PokeAPI URL for data retrieval
            /// </summary>
            public string ApiUrl { get; set; }

            /// <summary>
            /// PokeAPI Pokémon ID
            /// </summary>
            public int PokemonId { get; set; }

            /// <summary>
            /// Timestamp of capture in Local Time
            /// </summary>
            public DateTime CaptureTime { get; set; } = DateTime.Now;
        }
}
