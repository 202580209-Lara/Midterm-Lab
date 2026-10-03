using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Program
{
    static void Main()
    {
        Dictionary<string, Student> studentDictionary =
            new Dictionary<string, Student>();

        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" STUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (studentDictionary.Count >= 10)
                {
                    Console.WriteLine("Student records are full. Cannot add more students.");
                }
                else
                {
                    Console.Write("Enter Student Number: ");
                    string studentNumber = Console.ReadLine();

                    if (studentDictionary.ContainsKey(studentNumber))
                    {
                        Console.WriteLine("Student Number already exists.");
                    }
                    else
                    {
                        Student student = new Student();

                        student.StudentNumber = studentNumber;

                        Console.Write("Enter Name: ");
                        student.Name = Console.ReadLine();

                        Console.Write("Enter Program: ");
                        student.Program = Console.ReadLine();

                        int yearLevel;

                        while (true)
                        {
                            Console.Write("Enter Year Level (1-4): ");

                            if (int.TryParse(Console.ReadLine(), out yearLevel) &&
                                yearLevel >= 1 && yearLevel <= 4)
                            {
                                break;
                            }

                            Console.WriteLine("Please enter a valid year level from 1 to 4.");
                        }

                        student.YearLevel = yearLevel;

                        studentDictionary.Add(studentNumber, student);

                        Console.WriteLine("Student added successfully!");
                    }
                }
            }
            else if (choice == "2")
            {
                Console.Write("Enter Student Number to search: ");
                string studentNumber = Console.ReadLine();

                if (studentDictionary.TryGetValue(studentNumber, out Student student))
                {
                    Console.WriteLine("Student Found!");
                    Console.WriteLine("Student Number: " + student.StudentNumber);
                    Console.WriteLine("Name: " + student.Name);
                    Console.WriteLine("Program: " + student.Program);
                    Console.WriteLine("Year Level: " + student.YearLevel);
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" STUDENT RECORDS");
                Console.WriteLine("========================================");

                if (studentDictionary.Count == 0)
                {
                    Console.WriteLine("No student records found.");
                }
                else
                {
                    foreach (KeyValuePair<string, Student> item in studentDictionary)
                    {
                        Student student = item.Value;

                        Console.WriteLine("Student Number: " + student.StudentNumber);
                        Console.WriteLine("Name: " + student.Name);
                        Console.WriteLine("Program: " + student.Program);
                        Console.WriteLine("Year Level: " + student.YearLevel);
                        Console.WriteLine();
                    }
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("Program exited.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}