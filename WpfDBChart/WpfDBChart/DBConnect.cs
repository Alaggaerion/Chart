using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfDBChart
{
    public class DBConnect
    {        
        private MySqlConnection connection;
        private string serverLocation;
        private string databaseName;
        private string uID;
        private string password;
        private int countResult;
        public int CountResult
        {
            get
            {
                return countResult;
            }

            set
            {
                countResult = value;
            }
        }
        private string message;
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        //MonthDataCollection dataCollection;


        //private string yearQuery = "SELECT Count (idAnimals) FROM t_animals WHERE YEAR(aniDateTime)=@year";
        

        /// <summary>
        /// Constructor, call Initialize() to create connection string
        /// and SetRandomData() to insert random data in DB
        /// </summary>
        /// <param name="anyController">application controller</param>
        public DBConnect()
        {
            Initialize();            
        }

        /// <summary>
        /// Initialize values and create connection string and a MySqlConnection object
        /// </summary>
        private void Initialize()
        {
            serverLocation = "localhost";
            databaseName = "db_animals";
            uID = "root";
            password = "root";
            string connectionString = "SERVER=" + serverLocation + ";" + "DATABASE=" +
            databaseName + ";" + "UID=" + uID + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// open connection to database
        /// </summary>
        /// <returns>is db connected value</returns>
        private bool OpenConnection()
        {
            // Try to connect to DB
            try
            {
                connection.Open();
                message = "Successfully connected to the Data Base.";
                return true;
            }
            // Catch connection error
            catch (MySqlException exception)
            {
                // Error handler, get different message for most common error numbers
                // 0        : Cannot connect to server
                // 1045     : Invalid user name and/or password
                // default  : For all others errors
                switch (exception.Number)
                {
                    case 0:
                        message = "Cannot connect to server, please contact administrator";
                        break;

                    case 1045:
                        message = "Invalid username/password, please try again";
                        break;

                    default:
                        message = exception.Message;
                        break;
                }
                return false;
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        /// <returns>is connection closed value</returns>
        private bool CloseConnection()
        {
            // Try to close connection
            try
            {
                connection.Close();
                return true;
            }
            // Catch error
            catch (MySqlException exception)
            {
                message = exception.Message;
                return false;
            }
        }

        /// <summary>
        /// Count entries number in DB with month corresponding to parameter
        /// </summary>
        /// <param name="month">integer corresponding to the month to count</param>
        public void CountMonth(int month)
        {
            string monthQuery = "SELECT Count(aniDateTime) FROM t_animals WHERE MONTH(aniDateTime)=@month";

            // Open connection
            if (OpenConnection() == true)
            {
                // create command with query and connection
                MySqlCommand cmd = new MySqlCommand(monthQuery, connection);

                // Define parameter and set its value
                cmd.Parameters.AddWithValue("@month", month);

                // Execute command
                countResult = Convert.ToInt32(cmd.ExecuteScalar());

                // if connection closed successfully, message = success
                if (CloseConnection() == true)
                {
                    message = "Connection closed successfully !";
                }
                // else message = error                   
                else
                {
                    message = "Error";
                }
            }
            else
            {
                message = "Failed to connect to data base";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void CountAnAnimal(string name)
        {
            string animalQuery = "SELECT Count(aniName) FROM t_animals WHERE aniName = '@aniName'";

            // Open connection
            if (OpenConnection() == true)
            {
                // create command with query and connection
                MySqlCommand cmd = new MySqlCommand(animalQuery, connection);

                // Define parameter and set its value
                cmd.Parameters.AddWithValue("@aniName", name);

                // Execute command
                countResult = Convert.ToInt32(cmd.ExecuteScalar());

                // if connection closed successfully, message = success
                if (CloseConnection() == true)
                {
                    message = "Connection closed successfully !";
                }
                // else message = error                   
                else
                {
                    message = "Error";
                }
            }
            else
            {
                message = "Failed to connect to data base";
            }
        }
    }
}
