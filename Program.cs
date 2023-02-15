

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            new DandaraBot().InitBotAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}