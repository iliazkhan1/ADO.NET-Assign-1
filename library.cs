using System;
using System.Data;
using System.Data.SqlClient;

class LibraryManagement
{
    static string connectionString = "Server=ILIAZKHAN\\SQLEXPRESS;Database=library;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: AddBook(); break;
                case 2: ViewBooks(); break;
                case 3: UpdateBook(); break;
                case 4: DeleteBook(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter AuthorID: ");
        int authorId = int.Parse(Console.ReadLine());
        Console.Write("Enter Published Year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Is Available (1/0): ");
        int isAvailable = int.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("AddBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@AuthorID", authorId);
            cmd.Parameters.AddWithValue("@PublishedYear", year);
            cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Book added successfully.");
        }
    }

    static void ViewBooks()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("GetAllBooks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\nBookID\tTitle\t\tAuthor\t\tYear\tAvailable");

            while (reader.Read())
            {
                Console.WriteLine($"{reader["BookID"]}\t{reader["Title"]}\t{reader["Author"]}\t{reader["PublishedYear"]}\t{(bool)reader["IsAvailable"]}");
            }

            reader.Close();
        }
    }

    static void UpdateBook()
    {
        Console.Write("Enter BookID to update: ");
        int bookId = int.Parse(Console.ReadLine());
        Console.Write("Enter New Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter New AuthorID: ");
        int authorId = int.Parse(Console.ReadLine());
        Console.Write("Enter New Published Year: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Is Available (1/0): ");
        int isAvailable = int.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", bookId);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@AuthorID", authorId);
            cmd.Parameters.AddWithValue("@PublishedYear", year);
            cmd.Parameters.AddWithValue("@IsAvailable", isAvailable);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Book updated successfully.");
        }
    }

    static void DeleteBook()
    {
        Console.Write("Enter BookID to delete: ");
        int bookId = int.Parse(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", bookId);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Book deleted successfully.");
        }
    }
}
