using System;
using System.IO;

class Program
{
    // Customer information
    static string customerName = "";
    static string phoneNumber = "";
    static string emailAddress = "";
    static string location = "";
    static string selectedPhone = "";

    // File used to save customer and sales information
    static string fileName = "CustomerSales.txt";

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("       iPHONE SALES SYSTEM");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Display iPhones");
            Console.WriteLine("3. Display Saved Information");
            Console.WriteLine("4. Exit");
            Console.WriteLine("=================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddCustomers();
                    break;

                case "2":
                    DisplayPhone();
                    break;

                case "3":
                    DisplayFile();
                    break;

                case "4":
                    Exit();
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Method to collect customer information
    static void AddCustomers()
    {
        Console.WriteLine("===== CUSTOMER DETAILS =====");

        Console.Write("Enter customer name: ");
        customerName = Console.ReadLine() ?? "";

        // FormatException handling
        try
        {
            Console.Write("Enter phone number: ");
            long phone = Convert.ToInt64(Console.ReadLine());
            phoneNumber = phone.ToString();
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Phone number must contain numbers only.");
            return;
        }

        Console.Write("Enter email address: ");
        emailAddress = Console.ReadLine() ?? "";

        Console.Write("Enter location: ");
        location = Console.ReadLine() ?? "";

        Console.WriteLine();
        Console.WriteLine("Customer details added successfully.");
    }

    // Method to display available iPhones
    static void DisplayPhone()
    {
        try
        {
            Console.WriteLine("===== AVAILABLE iPHONES =====");
            Console.WriteLine();

            Console.WriteLine("1. iPhone 17");
            Console.WriteLine("   Display: 6.3-inch");
            Console.WriteLine("   Chip: A19");
            Console.WriteLine("   Storage: 256GB, 512GB");
            Console.WriteLine();

            Console.WriteLine("2. iPhone 16");
            Console.WriteLine("   Display: 6.1-inch");
            Console.WriteLine("   Chip: A18");
            Console.WriteLine("   Storage: 128GB, 256GB, 512GB");
            Console.WriteLine();

            Console.WriteLine("3. iPhone 15");
            Console.WriteLine("   Display: 6.1-inch");
            Console.WriteLine("   Chip: A16 Bionic");
            Console.WriteLine("   Camera: 48MP Main");
            Console.WriteLine();

            Console.WriteLine("4. iPhone 14");
            Console.WriteLine("   Display: 6.1-inch");
            Console.WriteLine("   Chip: A15 Bionic");
            Console.WriteLine("   Camera: Dual-camera system");
            Console.WriteLine();

            Console.WriteLine("5. iPhone 13");
            Console.WriteLine("   Display: 6.1-inch");
            Console.WriteLine("   Chip: A15 Bionic");
            Console.WriteLine("   Camera: Dual-camera system");
            Console.WriteLine();

            Console.Write("Select an iPhone: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    selectedPhone = "iPhone 17";
                    break;

                case "2":
                    selectedPhone = "iPhone 16";
                    break;

                case "3":
                    selectedPhone = "iPhone 15";
                    break;

                case "4":
                    selectedPhone = "iPhone 14";
                    break;

                case "5":
                    selectedPhone = "iPhone 13";
                    break;

                default:
                    throw new InvalidOperationException(
                        "The selected iPhone is not available.");
            }

            UpgradeDevice();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Method to save customer and phone information
    static void UpgradeDevice()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine("===== CUSTOMER SALE =====");
                writer.WriteLine("Customer Name: " + customerName);
                writer.WriteLine("Phone Number: " + phoneNumber);
                writer.WriteLine("Email Address: " + emailAddress);
                writer.WriteLine("Location: " + location);
                writer.WriteLine("Selected iPhone: " + selectedPhone);
                writer.WriteLine("Date and Time: " + DateTime.Now);
                writer.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Device selected: " + selectedPhone);
            Console.WriteLine("Customer information saved successfully.");

            DisplayFile();
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(
                "Error: You do not have permission to write to the file.");
        }
    }

    // Method to display information saved in the file
    static void DisplayFile()
    {
        try
        {
            // Throw FileNotFoundException if the file does not exist
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(
                    "Customer sales file was not found.");
            }

            Console.WriteLine(
                "===== SAVED CUSTOMER INFORMATION =====");

            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine(
                "Error: You do not have permission to access the file.");
        }
    }

    // Method to safely exit the program
    static void Exit()
    {
        Console.WriteLine(
            "Thank you for using the iPhone Sales System.");
        Console.WriteLine("Program closed successfully.");
    }
}