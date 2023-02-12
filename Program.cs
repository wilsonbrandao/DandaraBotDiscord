

public class Program
{
    public static void Main(string[] args)
    {
        new DandaraBot().InitBotAsync().GetAwaiter().GetResult();
    }
}