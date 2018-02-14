using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TestDataCreator
{
    class Program
    {
        const string userpath = "C:\\COMPUTER SCIENCE\\AS-A2\\A2\\NEA\\TestDataCreator\\TestDataCreator\\bin\\Debug\\";
        static SQLiteConnection m_dbConnection;

        // Creates an empty database file
        static void createnewdatabase(string filename)
        {
            SQLiteConnection.CreateFile(userpath + filename);
        }

        // Creates a connection with our database file.
        static void connectToDatabase(string file)
        {
            m_dbConnection = new SQLiteConnection("Data Source=" + userpath + file);
            m_dbConnection.Open();
        }

        static void CreateTablepossibleCars()
        {
            string sql = "create table possibleCars (" +
                                    "CarID INTEGER PRIMARY KEY, " +
                                    "Model Varchar (30)," +
                                    "Make Varchar (15));";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }



        static void fillTableCars()
        {
            string sql = "insert into possibleCars (Model, Make) values ('Fiesta', 'Ford')," +
                                    " ('Focus', 'Ford')," +
                                    " ('Transit', 'Ford')," +
                                    " ('A-Class', 'Mercedes-Benz')," +
                                    " ('C-Class', 'Mercedes-Benz')," +
                                    " ('E-Class', 'Mercedes-Benz')," +
                                    " ('5 Series', 'BMW')," +
                                    " ('7 Series', 'BMW')," +
                                    " ('i8', 'BMW')," +
                                    " ('Clio', 'Renault')," +
                                    " ('Captur', 'Renault')," +
                                    " ('Kadjar', 'Renault')," +
                                    " ('Quashqai', 'Nissan')," +
                                    " ('Juke', 'Nissan')," +
                                    " ('Micra', 'Nissan')," +
                                    " ('C1', 'Citroen')," +
                                    " ('DS3', 'Citroen')," +
                                    " ('DS4', 'Citroen')," +
                                    " ('Golf', 'Volkswagen')," +
                                    " ('Polo', 'Volkswagen')," +
                                    " ('Up!', 'Volkswagen')," +
                                    " ('A4', 'Audi')," +
                                    " ('Q3', 'Audi')," +
                                    " ('R8', 'Audi')," +
                                    " ('500', 'Fiat')," +
                                    " ('Punto', 'Fiat')," +
                                    " ('Panda', 'Fiat')," +
                                    " ('Corsa', 'Vauxhall')," +
                                    " ('Astra', 'Vauxhall')," +
                                    " ('Mokka', 'Vauxhall');";


            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            //m_dbConnection.Close(); //not needed now - second table to be added to the same db
        }

        static void CreateTableCars()
        {
            string sql = "create table Cars (" +
                                    "Registration Varchar(8) PRIMARY KEY, " +
                                    "Make Varchar (15)," +
                                    "Model Varchar (30)," +
                                    "Colour Varchar (10));";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        static string GenerateRandomReg(Random rnd)
        {

            string Registration = "";
            string[] Letter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int[] FirstNum = { 0, 5, 1, 6 };
            int[] ScndNum = { 1, 2, 3, 4, 5, 6, 7 };
            Registration = Registration + (Letter[rnd.Next(0, 25)]) + (Letter[rnd.Next(0, 26)]) + (FirstNum[rnd.Next(0, 4)]) + (ScndNum[rnd.Next(0, 7)]);
            string RandCode = "";
            for (int i = 0; i < 3; i++)
            {
                RandCode = RandCode + (Letter[rnd.Next(0, 26)]);
            }
            Registration = Registration + RandCode;
            Console.WriteLine(Registration);
            return Registration;
        }

        static void FillTable()
        {
            //database and data access classes
            SQLiteCommand command;
            SQLiteDataReader reader;
            //seed the random using code from program backend
            //continually generates new random value instead of only producing one like when using 'new Random()'
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            //arrays declared here
            //data is consistent throughout - so do not need to be updated with every iteration of the loop
            int[] possibleCarIds = getPossibleCarIds().ToArray();
            string[] colours = { "Red", "Black", "Silver", "Blue", "Green", "Grey", "White", "Brown", "Mauve", "Maroon", "Orange", "Rainbow", "Mucky", "Yellow", "Purple" };

            //loop to create and add car records
            for (int i = 0; i < 200; i++)
            {
                //select random id by picking random index from list
                int randId = rand.Next(0, (possibleCarIds.Length - 1));
                //get car details for the car with this id
                string sqlCarData = "Select Make, Model from possibleCars where CarID = " + randId;
                command = new SQLiteCommand(sqlCarData, m_dbConnection);
                reader = command.ExecuteReader(); //execute the command and pass the results to a reader class

                string insertMake = "", insertModel = ""; //variables to hold query results
                while (reader.Read()) //while loop required but query on id should only ever return a single result
                {
                    //Console.WriteLine("id: " + reader["Make"]); //test value with output
                    //Console.WriteLine("id: " + reader["Model"]); //test value with output
                    //assign returned columns to variables
                    insertMake = reader["Make"].ToString();
                    insertModel = reader["Model"].ToString();
                }
                reader.Close(); //results read - close reader

                //pick a colour name at random
                string insertColour = colours[rand.Next(0, colours.Length - 1)];

                //generate random registration plate number
                string insertReg = GenerateRandomReg(rand);

                //write new record to the database with these values
                string sqlInsert = "insert into Cars (Registration, Make, Model, Colour)"
                    + " values ("
                    + "'" + insertReg + "',"
                    + "'" + insertMake + "',"
                    + "'" + insertModel + "',"
                    + "'" + insertColour + "'"
                    + ")";
                command = new SQLiteCommand(sqlInsert, m_dbConnection);
                command.ExecuteNonQuery();
            }
            //loop completed
            Console.WriteLine("complete!");
        }

        static List<int> getPossibleCarIds()
        {
            string sqlPossibleIds = "Select CarID from possibleCars"; //sql query to return ids for all possible cars
            SQLiteCommand command = new SQLiteCommand(sqlPossibleIds, m_dbConnection);

            List<int> possibleIds = new List<int>();
            SQLiteDataReader reader = command.ExecuteReader(); //execute the command and pass the results to a reader class
            while (reader.Read()) //while there is still a row to be read from the query results
            {
                Console.WriteLine("id: " + reader["CarID"]); //test value with output
                possibleIds.Add(int.Parse(reader["CarID"].ToString())); //add id value to list
            }
            reader.Close(); //all rows read and added to list - loop ends

            //return populated list
            return possibleIds;
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            createnewdatabase("TestDataBase.sqlite");
            connectToDatabase("TestDataBase.sqlite;Version=3;");
            CreateTablepossibleCars();
            fillTableCars();
            //createnewdatabase("CarParkDB.sqlite");
            //connectToDatabase("CarParkDB.sqlite;Version=3;");
            CreateTableCars();
            FillTable();
            //Random rnd = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    GenerateRandomReg(rand);
            //}
        }

    }
}



