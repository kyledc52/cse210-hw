using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment myMathWork = new MathAssignment("Kyle", "Addition", "7.1", "1-20");
        Console.WriteLine(myMathWork.GetSummary());
        Console.WriteLine(myMathWork.GetHomeworkList());
        Console.WriteLine("");
        WritingAssignment myWritingWork = new WritingAssignment("Kyle", "English", "My English Class");
        Console.WriteLine(myWritingWork.GetSummary());
        Console.WriteLine(myWritingWork.GetWritingInformation());
    }
}