using System;
using System.Data;
using System.Data.SqlClient;

namespace CompanyDB_opgave
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) CreateDepartment");
            Console.WriteLine("2) UpdateDepartmentName");
            Console.WriteLine("3) UpdateDepartmentManager");
            Console.WriteLine("4) DeleteDepartment");
            Console.WriteLine("5) GetDepartmentByDNumber");
            Console.WriteLine("6) GetAllDepartments");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateDepartment("Production", 12345678);
                    return true;
                case "2":
                    UpdateDepartmentName(1, "HeadQuater");
                    return true;
                case "3":
                    UpdateDepartmentManager(1, 888665555);
                    return true;
                case "4":
                    DeleteDepartment(1);
                    return true;
                case "5":
                    GetDepartmentByDNumber(5);
                    return true;
                case "6":
                    GetAllDepartments();
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }

        }
        private static void GetAllDepartments()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_GetAllDepartments", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }

            // Call Close when done reading.
            reader.Close();
        }

        private static void GetDepartmentByDNumber(int dNum)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_GetDepartment", conn);
            cmd.Parameters.Add("@Dnumber", SqlDbType.Int).Value = dNum;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }
            Console.WriteLine("Checking Company Database");
            // Call Close when done reading.
            reader.Close();
        }

        private static void UpdateDepartmentName(int DNumber, string DName)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateDeparmentName", conn);
            cmd.Parameters.Add("@Dnumber", SqlDbType.Int).Value = DNumber;
            cmd.Parameters.Add("@Dname", SqlDbType.NVarChar).Value = DName;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }
            Console.WriteLine("Checking Company Database");
            // Call Close when done reading.
            reader.Close();
        }

        private static void UpdateDepartmentManager(int DNumber, int MgrSSN)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateDepartmentMng", conn);
            cmd.Parameters.Add("@Dnumber", SqlDbType.Int).Value = DNumber;
            cmd.Parameters.Add("@MgrSSN", SqlDbType.Int).Value = MgrSSN;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }
            Console.WriteLine("Checking Company Database");
            // Call Close when done reading.
            reader.Close();
        }

        private static void CreateDepartment(string DName, int MgrSSN)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_CreateDepartment", conn);
            cmd.Parameters.Add("@DName", SqlDbType.NVarChar).Value = DName;
            cmd.Parameters.Add("@MgrSSN", SqlDbType.Int).Value = MgrSSN;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }
            Console.WriteLine("Checking Company Database");
            // Call Close when done reading.
            reader.Close();
        }

        private static void DeleteDepartment(int DNumber)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_DeleteDepartment", conn);
            cmd.Parameters.Add("@Dnumber", SqlDbType.Int).Value = DNumber;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }
            Console.WriteLine("Checking Company Database");
            // Call Close when done reading.
            reader.Close();
        }

    }
}
