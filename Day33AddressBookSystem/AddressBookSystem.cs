using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Day33AddressBookSystem
{
    internal class AddressBookSystem
    {
        public static string connectionString = @"Server=MSSQLLocalDB;Databse=Address_Book_Service_DB;Trusted_Connection=true";
        //UC1 Retrieve data from table
        public void getData()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            Day33AddressBookSystem.Book book = new Day33AddressBookSystem.Book();
            using (connect)
            {
                connect.Open();
                string query = "Select * from ADDRESS_BOOK_SERVICE";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        book.FName = reader.GetString(0);
                        book.LName = reader.GetString(1);
                        book.Address = reader.GetString(2);
                        book.City = reader.GetString(3);
                        book.State = reader.GetString(4);
                        book.Zip = reader.GetInt32(5);
                        book.Phone = reader.GetString(6);
                        book.Email = reader.GetString(7);
                        book.BookName = reader.GetString(8);
                        book.BookType = reader.GetString(9);
                        book.PersonID = reader.GetInt32(10);
                        Console.WriteLine(book.PersonID + "-->" + book.FName + "-->" + book.LName + "-->" + book.Address + "-->" + book.City + "-->" + book.State + "-->" + book.Zip + "-->" + book.Phone + "-->" + book.Email);
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database.");
                }
                reader.Close();
                connect.Close();
            }
        }
        //UC2 Update record in database
        public void UpdateRecord()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            try
            {
                using (connect)
                {
                    Console.WriteLine("Enter name of Person:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter contact to update:");
                    string phone = Console.ReadLine();
                    connect.Open();
                    string query = "update ADDRESS_BOOK_SERVICE set Phone_Number =" + phone + "where First_Name='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Records updated successfully.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("---------------------------\nError:Records are not updated.\n------------------------------");
            }
        }
        public void DeleteRecord()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                Console.WriteLine("Enter name of person to  delete from records:");
                string name = Console.ReadLine();
                string query = "delete from ADDRESS_BOOK_SERVICE where First_Name='" + name + "'";
                SqlCommand command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                connect.Close();
            }
        }
        //Create Record in Address Book
        public void createRecord()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                Book book = new Book();
                Console.WriteLine("First Name of Person:");
                book.FName = Console.ReadLine();
                Console.WriteLine("Last Name of Person:");
                book.LName = Console.ReadLine();
                Console.WriteLine("Address of Person:");
                book.Address = Console.ReadLine();
                Console.WriteLine("City of Person:");
                book.City = Console.ReadLine();
                Console.WriteLine("State of Person:");
                book.State = Console.ReadLine();
                Console.WriteLine("Zip of Person:");
                book.Zip = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Contact of Person:");
                book.Phone = Console.ReadLine();
                Console.WriteLine("Email of Person:");
                book.Email = Console.ReadLine();
                Console.WriteLine("BookName:");
                book.BookName = Console.ReadLine();
                Console.WriteLine("BookType of Person:");
                book.BookType = Console.ReadLine();
                SqlCommand command = new SqlCommand("SpAddAddressBook", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@First_Name", book.FName);
                command.Parameters.AddWithValue("@Last_Name", book.LName);
                command.Parameters.AddWithValue("@Address", book.Address);
                command.Parameters.AddWithValue("@City", book.City);
                command.Parameters.AddWithValue("@State", book.State);
                command.Parameters.AddWithValue("@Zip", book.Zip);
                command.Parameters.AddWithValue("@Phone_Number", book.Phone);
                command.Parameters.AddWithValue("@Email", book.Email);
                command.Parameters.AddWithValue("@Name", book.BookName);
                command.Parameters.AddWithValue("@Type", book.BookType);
                command.ExecuteNonQuery();
                Console.WriteLine("Record created successfully.");
                connect.Close();
            }
        }
    }
}

