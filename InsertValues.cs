using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.ComponentModel.Design;
public class InsertValues()
{
    public static void InsertComment()
    {
        using IDbConnection connect = new SqlConnection(
                        "Server=gondolin667.org;" +
                        "Database=yhstudent80_database_1;" +
                        "User ID=yhstudent80;" +
                        "Password=mr&6$GFmVJ^&;" +
                        "Encrypt=False;" +
                        "TrustServerCertificate=False;"
                        ); 
        connect.Open();
        using var transaction = connect.BeginTransaction();

        try
        {
            string sqlInsertComment = "INSERT INTO Comment (article_id, comment_text, reader_score, reader_id) VALUES (@article_id, @comment_text, @reader_score, @reader_id)";
            connect.Execute(sqlInsertComment, new { article_id = Menu.curArtId, comment_text = Menu.curComTx, reader_score = Menu.curArtSc, reader_id = Menu.curReadId }, transaction);
            transaction.Commit();
        }
        catch (Exception exept)
        {
            transaction.Rollback();
            Console.WriteLine($"Error: {exept.Message}.");
        }
    }
}
