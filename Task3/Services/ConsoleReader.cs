namespace Task3.Services;

public class ConsoleReader : IReader
{
    public string? Read()
    {
        return Console.ReadLine();
    }
}