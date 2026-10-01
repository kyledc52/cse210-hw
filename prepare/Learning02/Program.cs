using System;

class Program
{
    static void Main(string[] args)
    {
        Job myJob1 = new Job();
        myJob1._jobTitle = "NSM";

        Job myJob2 = new Job();
        myJob2._jobTitle = "Lifeguard";
        // Console.WriteLine(myJob1._jobTitle);
        // Console.WriteLine(myJob2._jobTitle);

        // myJob1.DisplayJobDetails();

        Resume myResume = new Resume();
        myResume._name = "Kyle";
        myResume._jobs.Add(myJob1);
        myResume._jobs.Add(myJob2);
        
        myResume.DisplayResume();
    }
}