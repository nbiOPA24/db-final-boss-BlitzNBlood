using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
public class Article
{
    public int id { get; set; }
    public string title { get; set; }
    public string article_text { get; set; }
    public int author_id { get; set; }
    public int game_id { get; set; }
    public int score { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        using IDbConnection connection = new SqlConnection(
                        "Server=gondolin667.org;" +
                        "Database=yhstudent80_database_1;" +
                        "User ID=yhstudent80;" +
                        "Password=mr&6$GFmVJ^&;" +
                        "Encrypt=False;" +
                        "TrustServerCertificate=False;"
                        );
        IEnumerable<Article> result = connection.Query<Article>("SELECT * FROM Article");
        foreach (Article s in result)
        {
            Console.WriteLine($"Id: {s.id}, Titel: {s.title}, Article text: {s.article_text} score: {s.score}");
        }
        Console.ReadLine();
    }
}