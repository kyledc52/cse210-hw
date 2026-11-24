using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Grade:");
        String userGrade = Console.ReadLine();
        int grade = int.Parse(userGrade);
        String gradeAchieved;
        if (grade >= 90)
        {
            gradeAchieved = "A";
        }
        else if (grade >= 80)
        {
            gradeAchieved = "B";
        }
        else if (grade >= 70)
        {
            gradeAchieved = "C";
        }
        else if (grade >= 60)
        {
            gradeAchieved = "D";
        }
        else
        {
            gradeAchieved = "F";
        }
        Console.WriteLine($"Grade: {gradeAchieved}");
    }
}