using System;

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
        Student[] students = new Student[10];
        int studentCount = 0;

        while (true)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" STUDENT RECORD MANAGEMENT");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (studentCount >= 10)
                {
                    Console.WriteLine("Student records are full. Cannot add more students.");
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
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Program: ");
                        string program = Console.ReadLine();

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

                        students[studentCount].StudentNumber = studentNumber;
                        students[studentCount].Name = name;
                        students[studentCount].Program = program;
                        students[studentCount].YearLevel = yearLevel;

                        studentCount++;

                        Console.WriteLine("Student added successfully!");
                    }
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("========================================");
                Console.WriteLine(" STUDENT RECORDS");
                Console.WriteLine("========================================");

                if (studentCount == 0)
                {
                    Console.WriteLine("No student records found.");
                }
                else
                {
                    for (int i = 0; i < studentCount; i++)
                    {
                        Console.WriteLine("Student Number: " + students[i].StudentNumber);
                        Console.WriteLine("Name: " + students[i].Name);
                        Console.WriteLine("Program: " + students[i].Program);
                        Console.WriteLine("Year Level: " + students[i].YearLevel);
                        Console.WriteLine();
                    }
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter Student Number to search: ");
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
                    Console.WriteLine("Student Found!");
                    Console.WriteLine("Student Number: " + students[foundIndex].StudentNumber);
                    Console.WriteLine("Name: " + students[foundIndex].Name);
                    Console.WriteLine("Program: " + students[foundIndex].Program);
                    Console.WriteLine("Year Level: " + students[foundIndex].YearLevel);
                }
            }
            else if (choice == "4")
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

                    Console.WriteLine("Student updated successfully!");
                }
            }
            else if (choice == "5")
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
                    for (int i = foundIndex; i < studentCount - 1; i++)
                    {
                        students[i] = students[i + 1];
                    }

                    studentCount--;

                    Console.WriteLine("Student deleted successfully!");
                }
            }
            else if (choice == "6")
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