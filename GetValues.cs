using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

public class GetValues
{
    public static List<Article> articleList = new List<Article>();
    public static List<Comment> commentList = new List<Comment>();
    public static List<Image> imageList = new List<Image>();
    public static List<Reader> readerList = new List<Reader>();
    public static void getValues()
	{
        using IDbConnection connection = new SqlConnection(
                        "Server=gondolin667.org;" +
                        "Database=yhstudent80_database_1;" +
                        "User ID=yhstudent80;" +
                        "Password=mr&6$GFmVJ^&;" +
                        "Encrypt=False;" +
                        "TrustServerCertificate=False;"
                        );
        articleList.Clear();
        IEnumerable<Article> articleResult = connection.Query<Article>("SELECT Article.article_id, Article.title, Article.article_text, Article.author_id, Article.game_id, Article.score, Author.name FROM Article INNER JOIN Author ON Article.author_id = Author.author_id");
        foreach (Article s in articleResult)
        {
            articleList.Add(s);
        }
        commentList.Clear();
        IEnumerable<Comment> commentResult = connection.Query<Comment>("SELECT Article.article_id, Comment.comment_text, Reader.name, Comment.reader_score FROM Article INNER JOIN Comment ON Article.article_id = Comment.article_id INNER JOIN Reader ON Comment.reader_id = Reader.reader_id");
        foreach (Comment s in commentResult)
        {
            commentList.Add(s);
        }
        imageList.Clear();
        IEnumerable<Image> imageResult = connection.Query<Image>("SELECT Image.name, Image.url, ArToIm.article_id FROM Image JOIN ArToIm ON Image.image_id = ArToIm.image_id");
        foreach (Image s in imageResult)
        {
            imageList.Add(s);
        }
        readerList.Clear();
        IEnumerable<Reader> readerResult = connection.Query<Reader>("SELECT name, reader_id FROM Reader");
        foreach (Reader s in readerResult)
        {
            readerList.Add(s);
        }
    }
}
