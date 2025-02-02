using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
public class Article
{
    public int article_id { get; set; }
    public string title { get; set; }
    public string article_text { get; set; }
    public int author_id { get; set; }
    public string name { get; set; }
    public int game_id { get; set; }
    public int score { get; set; }
}
public class Comment
{
    public int article_id { get; set; }
    public int reader_score { get; set; }
    public string comment_text { get; set; }
    public string name { get; set; }
}
public class Image
{
    public string name { get; set; }
    public int article_id { get; set; }
    public string url { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        List<Article> articleList = new List<Article>();
        List<Comment> commentList = new List<Comment>();
        List<Image> imageList = new List<Image>();
        using IDbConnection connection = new SqlConnection(
                        "Server=gondolin667.org;" +
                        "Database=yhstudent80_database_1;" +
                        "User ID=yhstudent80;" +
                        "Password=mr&6$GFmVJ^&;" +
                        "Encrypt=False;" +
                        "TrustServerCertificate=False;"
                        );
        IEnumerable<Article> articleResult = connection.Query<Article>("SELECT Article.article_id, Article.title, Article.article_text, Article.author_id, Article.game_id, Article.score, Author.name FROM Article INNER JOIN Author ON Article.author_id = Author.author_id");
        foreach (Article s in articleResult)
        {
            Console.WriteLine($"Titel: {s.title} författare {s.name}, score: {s.score}");
            articleList.Add(s);
        }
        IEnumerable<Comment> commentResult = connection.Query<Comment>("SELECT Article.article_id, Comment.comment_text, Reader.name, Comment.reader_score FROM Article INNER JOIN Comment ON Article.article_id = Comment.article_id INNER JOIN Reader ON Comment.reader_id = Reader.reader_id");
        foreach (Comment s in commentResult)
        {
            commentList.Add(s);
        }
        IEnumerable<Image> imageResult = connection.Query<Image>("SELECT Image.name, Image.url, ArToIm.article_id FROM Image JOIN ArToIm ON Image.image_id = ArToIm.image_id");
        foreach (Image s in imageResult)
        {
            //Console.WriteLine($"Namn: {s.name} URL: {s.url}, Artikel: {s.article_id}");
            imageList.Add(s);
        }
        while (true)
        {
            Console.WriteLine("använd nummer för att navigera artiklarna och skriv Comments när du är inne i en artikel för att se kommentarer");
            if (Int32.TryParse(Console.ReadLine(), out int j))
            {
                Console.WriteLine("Titel: " + articleList[j - 1].title + " Författare: " + articleList[j - 1].name);
                Console.WriteLine("" + articleList[j - 1].article_text + " Score: " + articleList[j - 1].score);
                if(Console.ReadLine() == "Comments")
                {
                    for(int i = 0; i < commentList.Count; i++)
                    {
                        if (commentList[i].article_id == (articleList[j - 1].article_id))
                        {
                            Console.WriteLine("" + commentList[i].name + " Says: " + commentList[i].comment_text + " Score: " + commentList[i].reader_score);
                        }
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Var snäll och välj med hjälp av endast nummer.");
            }
            foreach (Article s in articleResult)
            {
                Console.WriteLine($"Titel: {s.title} författare {s.name}, score: {s.score}");
            }

        }
        Console.ReadLine();
    }
}
//Article text: {s.article_text} Id: {s.id}, 