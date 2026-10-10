public class Entry
{
    public string _date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
    public string _prompt;
    public string _response;
    
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
    }
}