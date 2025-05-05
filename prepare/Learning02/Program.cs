using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();
        job1._jobTitle = "Janitor";
        job1._company = "BYU-Idaho";
        job1._startYear = 2021;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Samsung";
        job2._startYear = 2024;
        job2._endYear = 2026;


        job1.Display();

        Resume resume = new Resume();
        resume._name = "Yuseong Son";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}
    
