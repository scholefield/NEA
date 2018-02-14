using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace NEA
{
    public partial class Form_Payment_Keypad : Form
    {
        const string userpath = "";
        const string testpath = "C:\\COMPUTER SCIENCE\\AS-A2\\A2\\NEA\\TestDataCreator\\TestDataCreator\\bin\\Debug\\";
        SQLiteConnection m_dbConnection;
        SQLiteConnection m_dbTest;

        public Form_Payment_Keypad()
        {
            InitializeComponent();
            
            //createNewDatabase(testpath, "TestDataBase.sqlite");
            connectToDatabase(ref m_dbTest, testpath, "TestDataBase.sqlite;Version=3;");
            createNewDatabase(userpath, "CarParkDB.sqlite");
            connectToDatabase(ref m_dbConnection, userpath, "CarParkDB.sqlite;Version=3;");

            createTables();
        }

        // Creates an empty database file
        static void createNewDatabase(string path, string filename)
        {
            SQLiteConnection.CreateFile(path + filename);
        }

        // Creates a connection with our database file.
        static void connectToDatabase(ref SQLiteConnection conn, string path, string file)
        {
            conn = new SQLiteConnection("Data Source=" + path + file);
            conn.Open();
        }

        private void createTables()
        {
            CreateTableCars();
            CreateTableCarParks();
            CreateTableSpaces();
            CreateTableBookings();
        }

        private void CreateTableCars()
        {
            string sql = "create table Cars (" +
                                    "Registration Varchar(8) PRIMARY KEY, " +
                                    "Make Varchar (15)," +
                                    "Model Varchar (30)," +
                                    "Colour Varchar (10));";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        private void CreateTableCarParks()
        {
            string sql = "create table CarParks (" +
                                    "CarParkID INTEGER PRIMARY KEY, " +
                                    "Name Varchar (30)," +
                                    "Street Varchar (30)," +
                                    "City Varchar (30)," +
                                    "Rate MONEY (15)," +
                                    "FOREIGN KEY (CarParkID) REFERENCES CarParks(CarParkID))";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        private void CreateTableSpaces()
        {
            string sql = "create table Spaces (" +
                                    "SpaceID INTEGER PRIMARY KEY, " +
                                    "CarParkID INTEGER," +
                                    "FOREIGN KEY (CarParkID) REFERENCES CarParks(CarParkID))";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        private void CreateTableBookings()
        {
            string sql = "create table Bookings (" +
                                    "BookingID INTEGER PRIMARY KEY, " +
                                    "CarParkID INTEGER, " +
                                    "SpaceID INTEGER, " +
                                    "Registration Varchar(8), " +
                                    "TimeIn TEXT, " +
                                    "TimeOut TEXT, " +
                                    "AmountPaid MONEY, " +
                                    "FOREIGN KEY (CarParkID) REFERENCES CarParks(CarParkID), " +
                                    "FOREIGN KEY (SpaceID) REFERENCES Spaces(SpaceID), " +
                                    "FOREIGN KEY (Registration) REFERENCES Cars(Registration))";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtBox_Enter.Text = "";
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string Entered_reg = txtBox_Enter.Text;

            if (!(Entered_reg == null || Entered_reg == ""))
            {
                string sqlSearch = "Select * from Cars where Registration = '" + Entered_reg + "'";
                SQLiteCommand command = new SQLiteCommand(sqlSearch, m_dbTest);
                SQLiteDataReader reader = command.ExecuteReader(); //execute the command and pass the results to a reader class

                while (reader.Read()) //while loop required but query on id should only ever return a single result
                {
                    new Car(
                        reader["Registration"].ToString(),
                        reader["Make"].ToString(),
                        reader["Make"].ToString(),
                        reader["Colour"].ToString()
                        );
                }
                reader.Close(); //results read - close reader
            }
        }
    }
    class Car
    {
        private string Registration;
        private string Make;
        private string Model;
        private string Colour;

        public Car(string Reg, string make, string model, string colour)
        {
            this.Registration = Reg;
            this.Make = make;
            this.Model = model;
            this.Colour = colour;
        }
    }

    class Car_Park
    {
        private int CarParkID;
        private string Name;
        private string Street;
        private string City;
        private int Num_spaces;
        private double Hourly_Rate;

        public Car_Park(int CPid, string name, string street, string city, int NSpaces, double rate)
        {
            this.CarParkID = CPid;
            this.Name = name;
            this.Street = street;
            this.City = city;
            this.Num_spaces = NSpaces;
            this.Hourly_Rate = rate;
        }
    }

    class Space
    {
        private int SpaceID;
        private int CarParkID;

        public Space(int Sid, int CPid)
        {
            this.SpaceID = Sid;
            this.CarParkID = CPid;
        }
    }

    class Booking
    {
        private int BookingID;
        private int CarParkID;
        private int SpaceID;
        private string Registration;
        private DateTime Time_In;
        private DateTime Time_Out;
        private double Amount_Paid;

        public Booking(int Bid, int CPid, int Sid, string reg, DateTime In, DateTime Out, double paid)
        {
            this.BookingID = Bid;
            this.CarParkID = CPid;
            this.SpaceID = Sid;
            this.Registration = reg;
            this.Time_In = In;
            this.Time_Out = Out;
            this.Amount_Paid = paid;
        }
    }

}

