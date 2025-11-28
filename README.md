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
- SimpleVersion.cs - Enklare version utan Dependency Injection
- Repository.cs - Modellklass för repository data

## Köra projektet

1. Återställ NuGet-paket:
\`\`\`bash
dotnet restore
\`\`\`

2. Bygg projektet:
\`\`\`bash
dotnet build
\`\`\`

3. Kör projektet:
\`\`\`bash
dotnet run
\`\`\`

## API Endpoint

Använder GitHub API: https://api.github.com/orgs/dotnet/repos


## Installation 
```bash
git clone https://github.com/NilsDavid01/API-Client.git
cd API-Client/
dotnet build
dotnet run


