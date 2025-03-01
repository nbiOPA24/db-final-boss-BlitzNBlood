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
    public int reader_id { get; set; }
    public string comment_text { get; set; }
    public string name { get; set; }
}
public class Image
{
    public string name { get; set; }
    public int article_id { get; set; }
    public string url { get; set; }
}
public class Reader
{
    public string name { get; set; }
    public int reader_id { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        GetValues.getValues();
        Menu.startMenu();
    }
}