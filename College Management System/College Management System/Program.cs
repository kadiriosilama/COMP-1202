﻿
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

// Define CollegeManagementSystem class to manage students and professors
class CollegeManagementSystem
{
    public List<Student> students;
    public List<Professor> professors;

    public CollegeManagementSystem()
    {
        students = new List<Student>();
        professors = new List<Professor>();
    }

    public void AddStudent(int id, string name)
    {
        students.Add(new Student(id, name));
    }

    public void AddProfessor(int id, string name)
    {
        professors.Add(new Professor(id, name));
    }

    public void ViewAllStudents()
    {
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
    }

    public void ViewAllProfessors()
    {
        Console.WriteLine("All Professors:");
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

public class Program {
    

    // Method to enroll a student in a class
    static void EnrollStudentInClass(int studentID, string className, CollegeManagementSystem cms)
    {
        // Find the student by ID
        Student student = cms.students.Find(s => s.StudentID == studentID);
        if (student == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        // Enroll the student in the class
        student.EnrollInClass(className);
        Console.WriteLine($"Student {studentID} ({student.Name}) enrolled in class: {className}");
    }

    // Method to view students in a class
    static void ViewStudentsInClass(string className, CollegeManagementSystem cms)
    {
        Console.WriteLine($"Students enrolled in class {className}: ");
        bool found = false;

        foreach (var student in cms.students)
        {
            if (student.EnrolledClasses.Contains(className))
            {
                Console.WriteLine($"Student ID: {student.StudentID}, Name: {student.Name}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No students enrolled in this class.");
        }
    }

    public static void Main(string[] args)
    {
        CollegeManagementSystem cms = new CollegeManagementSystem();
        
        // Display menu until the user chooses to exit
        while (true)
        {
            Console.WriteLine("========== College Management System ==========");
            Console.WriteLine("1. Add a new student");
            Console.WriteLine("2. Add a new professor");
            Console.WriteLine("3. View all students");
            Console.WriteLine("4. View all professors");
            Console.WriteLine("5. Enroll a student in a class");
            Console.WriteLine("6. View students in a class");
            Console.WriteLine("7. Exit the program");
            Console.WriteLine("===============================================");

            Console.Write("Enter your choice: ");
            int choice;
            if (!

int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter student ID: ");
                    int studentID = int.Parse(Console.ReadLine());
                    Console.Write("Enter student name: ");
                    string studentName = Console.ReadLine();
                    cms.AddStudent(studentID, studentName);
                    break;
                case 2:
                    Console.Write("Enter professor ID: ");
                    int professorID = int.Parse(Console.ReadLine());
                    Console.Write("Enter professor name: ");
                    string professorName = Console.ReadLine();
                    Console.Write("Enter professor's class taught: ");
                    string classTaught = Console.ReadLine();
                    cms.AddProfessor(professorID, professorName);
                    // Add the class taught by the professor
                    cms.professors.Last().AddClassTaught(classTaught);
                    break;

                case 3:
                    cms.ViewAllStudents();
                    break;
                case 4:
                    cms.ViewAllProfessors();
                    break;
                case 5:
                    // Enroll a student in a class
                    Console.Write("Enter student ID to enroll: ");
                    int studentIDToEnroll = int.Parse(Console.ReadLine());
                    Console.Write("Enter the class name to enroll the student: ");
                    string classToEnroll = Console.ReadLine();
                    EnrollStudentInClass(studentIDToEnroll, classToEnroll, cms);
                    break;
                case 6:
                    // View students in a class
                    Console.Write("Enter the class name to view enrolled students: ");
                    string classToView = Console.ReadLine();
                    ViewStudentsInClass(classToView, cms);
                    break;
                case 7:
                    Console.WriteLine("Exiting the program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a valid option.");
                    break;
            }
        }
    }
}

