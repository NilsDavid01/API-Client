# GitHub API Client

Detta projekt är en konsollapp som kommunicerar med GitHub API för att hämta information om .NET Foundations repositories.

## Funktioner

- Gör HTTP GET-förfrågningar till GitHub API
- Deserialiserar JSON-svar till C#-objekt
- Använder JsonPropertyName attribut för konfigurering
- Visar repository information (namn, beskrivning, watchers, etc.)

## Tekniker

- .NET 9.0
- HttpClient för HTTP requests
- System.Text.Json för JSON deserialisering
- Dependency Injection med HttpClientFactory

## Struktur

- Program.cs - Huvudprogram med HttpClientFactory
- Repository.cs - Modellklass för repository data

## API Endpoint

Använder GitHub API: https://api.github.com/orgs/dotnet/repos

## Installation 
```bash
git clone https://github.com/NilsDavid01/API-Client.git
cd API-Client/
dotnet restore
dotnet build
dotnet run


