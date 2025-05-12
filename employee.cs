using System;
using System.Data.SqlClient;

class Program
{
    static string connectionString = "Server=ILIAZKHAN\\SQLEXPRESS;Database=employee;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";



    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Employee\n2. View All Employees\n3. Update Employee\n4. Delete Employee\n5. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddEmployee(); break;
                case 2: ViewEmployees(); break;
                case 3: UpdateEmployee(); break;
                case 4: DeleteEmployee(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void AddEmployee()
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Department: ");
        string department = Console.ReadLine();
        Console.Write("Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        string query = "INSERT INTO Employees (FirstName, LastName, Email, Phone, Department, Salary) VALUES (@FirstName, @LastName, @Email, @Phone, @Department, @Salary)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Department", department);
            cmd.Parameters.AddWithValue("@Salary", salary);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Employee added successfully.");
    }

    static void ViewEmployees()
    {
        string query = "SELECT * FROM Employees";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\nEmployee List:");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["EmployeeID"]}: {reader["FirstName"]} {reader["LastName"]}, {reader["Email"]}, {reader["Phone"]}, {reader["Department"]}, Salary: {reader["Salary"]}");
            }
        }
    }

    static void UpdateEmployee()
    {
        Console.Write("Enter Employee ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("New Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("New Email: ");
        string email = Console.ReadLine();
        Console.Write("New Phone: ");
        string phone = Console.ReadLine();
        Console.Write("New Department: ");
        string department = Console.ReadLine();
        Console.Write("New Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        string query = "UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, Department=@Department, Salary=@Salary WHERE EmployeeID=@EmployeeID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@EmployeeID", id);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Department", department);
            cmd.Parameters.AddWithValue("@Salary", salary);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Employee updated successfully.");
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        string query = "DELETE FROM Employees WHERE EmployeeID=@EmployeeID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@EmployeeID", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Employee deleted successfully.");
    }
}
