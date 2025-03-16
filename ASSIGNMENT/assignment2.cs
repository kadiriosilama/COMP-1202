using System;
using System.Collections.Generic;

// Define a class to represent a Student
class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public List<string> EnrolledClasses { get; set; }

    public Student(int studentID, string name)
    {
        StudentID = studentID;
        Name = name;
        EnrolledClasses = new List<string>();
    }

    // Method to enroll a student in a class
    public void EnrollInClass(string className)
    {
        EnrolledClasses.Add(className);
    }
}

// Define a class to represent a Professor
class Professor
{
    public int ProfessorID { get; set; }
    public string Name { get; set; }
    public List<string> ClassesTaught { get; set; }

    public Professor(int professorID, string name)
    {
        ProfessorID = professorID;
        Name = name;
        ClassesTaught = new List<string>();
    }

    // Method to add a class taught by the professor
    public void AddClassTaught(string className)
    {
        ClassesTaught.Add(className);
    }
}

class Program
{
    static void Main()
    {
        // Initialize lists to store students and professors
        List<Student> students = new List<Student>();
        List<Professor> professors = new List<Professor>();

        // Example usage:
        // Create a new student
        Student student1 = new Student(1, "Alice");
        student1.EnrollInClass("Fantasy 101");
        student1.EnrollInClass("History");
        students.Add(student1);

        Student student2 = new Student(2, "Natalia");
        student1.EnrollInClass("Computer Science");
        student1.EnrollInClass("Spanish");
        students.Add(student3);

        Student student3 = new Student(3, "Holland");
        student1.EnrollInClass("Quantum Physics");
        student1.EnrollInClass("Business Studies");
        students.Add(student3);

        Student student4 = new Student(4, "Idrish");
        student1.EnrollInClass("Math");
        student1.EnrollInClass("Boss 101");
        students.Add(student4);

        Student student5 = new Student(5, "Maaz");
        student1.EnrollInClass("English");
        student1.EnrollInClass("Photography");
        students.Add(student5);

        // Create a new professor
        Professor professor1 = new Professor(101, "Dr. Smith");
        professor1.AddClassTaught("Computer Science");
        professor1.AddClassTaught("Math");
        professors.Add(professor1);

        Professor professor2 = new Professor(102, "Mr. Stark");
        professor1.AddClassTaught("Quantum Physics");
        professor1.AddClassTaught("History");
        professors.Add(professor2);

        Professor professor3 = new Professor(103, "Mr. Rahul");
        professor1.AddClassTaught("Photography");
        professor1.AddClassTaught("Business Studies");
        professors.Add(professor3);

        Professor professor4 = new Professor(104, "Mrs. Zalil");
        professor1.AddClassTaught("English");
        professor1.AddClassTaught("Spanish");
        professors.Add(professor4);

        Professor professor5 = new Professor(105, "Dr. Bianca");
        professor1.AddClassTaught("Fantasy 101");
        professor1.AddClassTaught("Boss 101");
        professors.Add(professor5);



        // Display all students
        Console.WriteLine("All Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"Student ID: {student.StudentID}, Name: {student.Name}");
            Console.WriteLine("Enrolled Classes:");
            foreach (var className in student.EnrolledClasses)
            {
                Console.WriteLine($"- {className}");
            }
        }

        // Display all professors
        Console.WriteLine("\nAll Professors:");
        foreach (var professor in professors)
        {
            Console.WriteLine($"Professor ID: {professor.ProfessorID}, Name: {professor.Name}");
            Console.WriteLine("Classes Taught:");
            foreach (var className in professor.ClassesTaught)
            {
                Console.WriteLine($"- {className}");
            }
        }
    }
}