using System;

public class Menu
{
    public static int curArtId;
    public static int curReadId;
    public static int curArtSc;
    public static string curComTx;
    public static void startMenu()
    {
        int articleIncrement = 1;
        foreach (Article s in GetValues.articleList)
        {
            Console.WriteLine($"{articleIncrement} Titel: {s.title} författare {s.name}, score: {s.score}");
            articleIncrement++;
        }
        string inputString;
        while (true)
        {
            Console.WriteLine("Använd nummer för att navigera artiklarna och skriv Comments när du är inne i en artikel för att se kommentarer, för att kommentera behöver du vara inne på rätt artikel eller kommentarerna på rätt artikel och skiva Comment");
            if (Int32.TryParse(Console.ReadLine(), out int j))
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Titel: " + GetValues.articleList[j - 1].title + " Författare: " + GetValues.articleList[j - 1].name);
                    Console.WriteLine("" + GetValues.articleList[j - 1].article_text + " Score: " + GetValues.articleList[j - 1].score);
                    inputString = Console.ReadLine();
                    if (inputString == "Comment")
                    {
                        curArtId = GetValues.articleList[j - 1].article_id;
                        Console.WriteLine("vad är din reader id?");
                        for (int i = 0; i < GetValues.readerList.Count; i++)
                        {
                            Console.WriteLine("namn: " + GetValues.readerList[i].name + " id: " + GetValues.readerList[i].reader_id);
                        }
                        Int32.TryParse(Console.ReadLine(), out int curReadIdTemp);
                        curReadId = curReadIdTemp;
                        Console.WriteLine("vad är din kommentar?");
                        curComTx = Console.ReadLine();
                        Console.WriteLine("vad är ditt score av artikeln?");
                        Int32.TryParse(Console.ReadLine(), out int curArtScTemp);
                        curArtSc = curArtScTemp;
                        InsertValues.InsertComment();
                        GetValues.getValues();
                    }
                    else if (inputString == "Comments")
                    {
                        for (int i = 0; i < GetValues.commentList.Count; i++)
                        {
                            if (GetValues.commentList[i].article_id == (GetValues.articleList[j - 1].article_id))
                            {
                                Console.WriteLine("" + GetValues.commentList[i].name + " Says: " + GetValues.commentList[i].comment_text + " Score: " + GetValues.commentList[i].reader_score);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Var snäll och välj med hjälp av endast nummer.");
            }
            foreach (Article s in GetValues.articleList)
            {
                Console.WriteLine($"Titel: {s.title} författare {s.name}, score: {s.score}");
            }

        }
    }
}
