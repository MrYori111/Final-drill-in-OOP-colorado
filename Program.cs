
using System;
using System.Collections.Generic;

class Student
{
    public string StudentNumber;
    public string Surname;
    public string FirstName;
    public string Occupation;
    public char Gender;
    public string CountryCode;
    public string AreaCode;
    public string PhoneNumber;

    public Student(string id, string surname, string first,
        string job, char gender, string country,
        string area, string phone)
    {
        StudentNumber = id;
        Surname = surname;
        FirstName = first;
        Occupation = job;
        Gender = gender;
        CountryCode = country;
        AreaCode = area;
        PhoneNumber = phone;
    }

    public void Display()
    {
        Console.WriteLine(Surname + ", " + FirstName +
            ", with student number " + StudentNumber +
            ", is a " + Occupation +
            ". His/Her phone number is " +
            CountryCode + "-" + AreaCode + "-" + PhoneNumber);
    }
}

class Phonebook
{
    List<Student> students = new List<Student>();

    public void AddStudent()
    {
        string again = "Y";

        while (again == "Y")
        {
            Console.WriteLine("\n--- STORE STUDENT ---");

            Console.Write("Enter student number: ");
            string id = Console.ReadLine();

            bool exists = false;

            foreach (Student s in students)
            {
                if (s.StudentNumber == id)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                Console.WriteLine("Student number already exists!");
                Console.Write("Try again? (Y/N): ");
                again = Console.ReadLine().ToUpper();
                continue;
            }

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter first name: ");
            string first = Console.ReadLine();

            Console.Write("Enter occupation: ");
            string job = Console.ReadLine();

            char gender;

            do
            {
                Console.Write("Enter gender (M/F): ");
                char.TryParse(Console.ReadLine(), out gender);
                gender = char.ToUpper(gender);
            }
            while (gender != 'M' && gender != 'F');

            Console.Write("Enter country code: ");
            string country = Console.ReadLine();

            if (country != "60" && country != "62" &&
                country != "63" && country != "65" &&
                country != "66")
            {
                Console.WriteLine("Invalid country code!");
                Console.WriteLine("Please enter the student again.");
                continue;
            }

            Console.Write("Enter area code: ");
            string area = Console.ReadLine();

            Console.Write("Enter number: ");
            string phone = Console.ReadLine();

            Student student = new Student(id, surname, first,
                job, gender, country, area, phone);

            students.Add(student);

            Console.WriteLine("Student successfully added!");

            Console.Write("Do you want another entry (Y/N)? ");
            again = Console.ReadLine().ToUpper();
        }
    }

    public void EditStudent()
    {
        Console.Write("\nEnter student number: ");
        string id = Console.ReadLine();

        Student found = null;

        foreach (Student s in students)
        {
            if (s.StudentNumber == id)
            {
                found = s;
                break;
            }
        }

        if (found == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        int choice = 0;

        while (choice != 8)
        {
            Console.WriteLine("\n--- EDIT STUDENT ---");
            found.Display();

            Console.WriteLine("\nWhich information do you wish to change?");
            Console.WriteLine("[1] Student number");
            Console.WriteLine("[2] Surname");
            Console.WriteLine("[3] Gender");
            Console.WriteLine("[4] Occupation");
            Console.WriteLine("[5] Country code");
            Console.WriteLine("[6] Area code");
            Console.WriteLine("[7] Phone number");
            Console.WriteLine("[8] Back to main menu");

            Console.Write("Enter choice: ");
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new student number: ");
                    string newID = Console.ReadLine();

                    bool duplicate = false;

                    foreach (Student s in students)
                    {
                        if (s.StudentNumber == newID && s != found)
                        {
                            duplicate = true;
                            break;
                        }
                    }

                    if (!duplicate)
                        found.StudentNumber = newID;
                    else
                        Console.WriteLine("Student number already exists!");
                    break;

                case 2:
                    Console.Write("Enter new surname: ");
                    found.Surname = Console.ReadLine();
                    break;

                case 3:
                    char gender;

                    do
                    {
                        Console.Write("Enter new gender (M/F): ");
                        char.TryParse(Console.ReadLine(), out gender);
                        gender = char.ToUpper(gender);
                    }
                    while (gender != 'M' && gender != 'F');

                    found.Gender = gender;
                    break;

                case 4:
                    Console.Write("Enter new occupation: ");
                    found.Occupation = Console.ReadLine();
                    break;

                case 5:
                    Console.Write("Enter new country code: ");
                    string code = Console.ReadLine();

                    if (code == "60" || code == "62" ||
                        code == "63" || code == "65" ||
                        code == "66")
                    {
                        found.CountryCode = code;
                        Console.WriteLine("Country code updated!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid country code!");
                    }
                    break;

                case 6:
                    Console.Write("Enter new area code: ");
                    found.AreaCode = Console.ReadLine();
                    break;

                case 7:
                    Console.Write("Enter new phone number: ");
                    found.PhoneNumber = Console.ReadLine();
                    break;

                case 8:
                    Console.WriteLine("Returning to main menu...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    public void SearchByCountry()
    {
        List<string> selected = new List<string>();
        int choice = -1;
        bool all = false;

        while (choice != 0 && !all)
        {
            Console.WriteLine("\n--- SEARCH BY COUNTRY ---");
            Console.WriteLine("[1] Philippines");
            Console.WriteLine("[2] Thailand");
            Console.WriteLine("[3] Singapore");
            Console.WriteLine("[4] Indonesia");
            Console.WriteLine("[5] Malaysia");
            Console.WriteLine("[6] ALL");
            Console.WriteLine("[0] No More");

            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = -1;

            switch (choice)
            {
                case 1:
                    if (!selected.Contains("63"))
                        selected.Add("63");
                    break;

                case 2:
                    if (!selected.Contains("66"))
                        selected.Add("66");
                    break;

                case 3:
                    if (!selected.Contains("65"))
                        selected.Add("65");
                    break;

                case 4:
                    if (!selected.Contains("62"))
                        selected.Add("62");
                    break;

                case 5:
                    if (!selected.Contains("60"))
                        selected.Add("60");
                    break;

                case 6:
                    all = true;
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        List<Student> results = new List<Student>();

        foreach (Student s in students)
        {
            if (all || selected.Contains(s.CountryCode))
            {
                results.Add(s);
            }
        }

        // Arrange students alphabetically by surname
        for (int i = 0; i < results.Count - 1; i++)
        {
            for (int j = i + 1; j < results.Count; j++)
            {
                if (string.Compare(results[i].Surname,
                    results[j].Surname,
                    StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Student temp = results[i];
                    results[i] = results[j];
                    results[j] = temp;
                }
            }
        }

        Console.WriteLine("\n--- SEARCH RESULTS ---");

        if (results.Count == 0)
        {
            Console.WriteLine("No students found.");
        }

        foreach (Student s in results)
        {
            s.Display();
        }
    }
}

class Program
{
    static void Main()
    {
        Phonebook book = new Phonebook();
        int choice = 0;

        while (choice != 4)
        {
            Console.WriteLine("\n===== ASEAN PHONEBOOK =====");
            Console.WriteLine("[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country");
            Console.WriteLine("[4] Exit");

            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = 0;

            switch (choice)
            {
                case 1:
                    book.AddStudent();
                    break;

                case 2:
                    book.EditStudent();
                    break;

                case 3:
                    book.SearchByCountry();
                    break;

                case 4:
                    Console.WriteLine("Thank you for using ASEAN Phonebook!");
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
