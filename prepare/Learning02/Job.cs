public class Job
{
    // attributes
    public String _jobTitle = "";
    public double _pay = 0;

    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle}");
    }
}