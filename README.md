# 🌀 AetherMon - Cosmic Pokémon Storage System  
*ASP.NET Core | Razor Pages | SQLite | PokeAPI Integration*  

[![.NET 9](https://img.shields.io/badge/.NET-9.0-purple)](https://dotnet.microsoft.com/) 
[![MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## 🌟 Features
- **Quantum Scanning**  
  Real-time Pokémon lookup via PokeAPI v2
- **Aether Database**  
  SQLite storage with EF Core migrations
- **Cosmic UI**  
  Animated holographic theme with particle effects
- **Advanced Stats**  
  Display types, abilities, and base stats
- **Error Resilience**  
  Fallback sprites for missing Pokémon

## 🛠️ Tech Stack

- **Frontend**: Razor Pages, Bootstrap 5, Custom CSS Animations
    
- **Backend**: ASP.NET Core 9, Entity Framework Core
    
- **Database**: SQLite with ACID compliance
    
- **API**: PokeAPI v2 with rate limiting

## 📜 License
This project uses sprites under PokeAPI's [terms](https://pokeapi.co/docs/graphql#fairuse)
Main codebase licensed under MIT License

## 🚀 Quick Start
```bash
# Clone repository
git clone https://github.com/yourusername/AetherMon.git
cd AetherMon

# Restore packages
dotnet restore

# Database setup
dotnet ef database update
