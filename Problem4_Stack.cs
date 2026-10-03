using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Program
{
    static void Main()
    {
        Student[] students = new Student[10];
        int studentCount = 0;

        Stack<Operation> operationHistory =
            new Stack<Operation>();

        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" STUDENT RECORD MANAGEMENT");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. View Operation History");
            Console.WriteLine("5. View Last Operation");
            Console.WriteLine("6. Remove Last Operation");
            Console.WriteLine("7. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (studentCount >= 10)
                {
                    Console.WriteLine("Student records are full.");
                }
                else
                {
                    Console.Write("Enter Student Number: ");
                    string studentNumber = Console.ReadLine();

                    bool duplicate = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == studentNumber)
                        {
                            duplicate = true;
                            break;
                        }
                    }

                    if (duplicate)
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

                        students[studentCount] = student;
                        studentCount++;

                        Operation operation = new Operation();
                        operation.Action = "Added";
                        operation.StudentNumber = student.StudentNumber;
                        operation.StudentName = student.Name;

                        operationHistory.Push(operation);

                        Console.WriteLine("Student added successfully!");
                    }
                }
            }
            else if (choice == "2")
            {
                Console.Write("Enter Student Number to update: ");
                string studentNumber = Console.ReadLine();

                int foundIndex = -1;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == studentNumber)
                    {
                        foundIndex = i;
                        break;
                    }
                }

                if (foundIndex == -1)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    Console.Write("Enter New Name: ");
                    students[foundIndex].Name = Console.ReadLine();

                    Console.Write("Enter New Program: ");
                    students[foundIndex].Program = Console.ReadLine();

                    int yearLevel;

                    while (true)
                    {
                        Console.Write("Enter New Year Level (1-4): ");

                        if (int.TryParse(Console.ReadLine(), out yearLevel) &&
                            yearLevel >= 1 && yearLevel <= 4)
                        {
                            break;
                        }

                        Console.WriteLine("Please enter a valid year level from 1 to 4.");
                    }

                    students[foundIndex].YearLevel = yearLevel;

                    Operation operation = new Operation();
                    operation.Action = "Updated";
                    operation.StudentNumber = students[foundIndex].StudentNumber;
                    operation.StudentName = students[foundIndex].Name;

                    operationHistory.Push(operation);

                    Console.WriteLine("Student updated successfully!");
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter Student Number to delete: ");
                string studentNumber = Console.ReadLine();

                int foundIndex = -1;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == studentNumber)
                    {
                        foundIndex = i;
                        break;
                    }
                }

                if (foundIndex == -1)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    string deletedName = students[foundIndex].Name;

                    for (int i = foundIndex; i < studentCount - 1; i++)
                    {
                        students[i] = students[i + 1];
                    }

                    studentCount--;

                    Operation operation = new Operation();
                    operation.Action = "Deleted";
                    operation.StudentNumber = studentNumber;
                    operation.StudentName = deletedName;

                    operationHistory.Push(operation);

                    Console.WriteLine("Student deleted successfully!");
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" OPERATION HISTORY");
                Console.WriteLine("========================================");

                if (operationHistory.Count == 0)
                {
                    Console.WriteLine("No recorded operations.");
                }
                else
                {
                    int number = 1;

                    foreach (Operation operation in operationHistory)
                    {
                        Console.WriteLine(number + ". " +
                            operation.Action + " " +
                            operation.StudentName);

                        number++;
                    }
                }
            }
            else if (choice == "5")
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine("No recorded operations.");
                }
                else
                {
                    Operation operation = operationHistory.Peek();

                    Console.WriteLine("Last Operation: " +
                        operation.Action + " " +
                        operation.StudentName);
                }
            }
            else if (choice == "6")
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine("No recorded operations.");
                }
                else
                {
                    operationHistory.Pop();

                    Console.WriteLine("Last operation removed successfully!");
                }
            }
            else if (choice == "7")
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