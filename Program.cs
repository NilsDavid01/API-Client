using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        // Setup Dependency Injection
        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
            .BuildServiceProvider();

        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        
        await RunAsync(httpClientFactory);
    }

    static async Task RunAsync(IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient();
        
        // Konfigurera headers för GitHub API
        client.DefaultRequestHeaders.Add("User-Agent", "DotNet-Console-App");
        client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");

        try
        {
            Console.WriteLine("Hämtar information om .NET Foundation repositories...\n");
            
            string url = "https://api.github.com/orgs/dotnet/repos";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            
            // Konfigurera deserialiseringsalternativ
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            
            // Deserialisera JSON till lista av Repository-objekt
            var repositories = JsonSerializer.Deserialize<List<Repository>>(jsonResponse, options);
            
            DisplayRepositories(repositories ?? new List<Repository>());
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP-fel uppstod: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON-deserialiseringsfel: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett oväntat fel uppstod: {ex.Message}");
        }
        
        Console.WriteLine("\nTryck på valfri tangent för att avsluta...");
        Console.ReadKey();
    }

    static void DisplayRepositories(List<Repository> repositories)
    {
        if (repositories == null || repositories.Count == 0)
        {
            Console.WriteLine("Inga repositories hittades.");
            return;
        }

        Console.WriteLine($"Antal repositories: {repositories.Count}\n");
        
        foreach (var repo in repositories)
        {
            Console.WriteLine($"Namn: {repo.Name}");
            Console.WriteLine($"Beskrivning: {repo.Description ?? "Ingen beskrivning"}");
            Console.WriteLine($"GitHub URL: {repo.HtmlUrl}");
            Console.WriteLine($"Homepage: {repo.Homepage ?? "Ingen homepage"}");
            Console.WriteLine($"Watchers: {repo.Watchers}");
            Console.WriteLine($"Senast uppdaterad: {repo.PushedAt:yyyy-MM-dd HH:mm}");
            Console.WriteLine(new string('-', 60));
        }
    }
}
