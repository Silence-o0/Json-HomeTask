
using System;
using System.Text.Json;
using System.Text.Json.Serialization;


public class Book
{
    [JsonIgnore]
    public int? PublishingHouseId { get; init; }
    [JsonPropertyName("Title")]
    public string Name { get; init; }
    public PublishingHouse? PublishingHouse { get; init; }
}

public record class PublishingHouse (int Id, string Name, string Adress);
internal class Program
{
    private static void Main(string[] args)
    {

        const string Path = "./books.json";

        var jsonContent = File.ReadAllText(Path);

        var books = JsonSerializer.Deserialize<List<Book>>(jsonContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        if (books != null)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Код видавництва: {book.PublishingHouseId};    Книга: {book.Name}.");
                Console.WriteLine($"Видавництво: {book.PublishingHouse?.Id}, {book.PublishingHouse.Name}, {book.PublishingHouse.Adress}.");
                Console.WriteLine();
            }
        }

        Console.ReadKey();
    }
}