using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace FrbaCrucero.DB
{
    class DBConnection
    {

        private static DBConnection dbConnection;

        public static DBConnection getInstance()
        {
            if (dbConnection == null)
            {
                DBConnection db = new DBConnection();
                db.connect();
                dbConnection = db;
            }

            return dbConnection;           
        }

        string dbHost = ConfigurationManager.AppSettings["dbHost"];
        string dbName = ConfigurationManager.AppSettings["dbName"];
        string username = ConfigurationManager.AppSettings["username"];
        string password = ConfigurationManager.AppSettings["password"];

        private SqlConnection connection;

        private void connect()
        {
            SqlConnectionStringBuilder stringConnectionBuilder = new SqlConnectionStringBuilder();
            stringConnectionBuilder.DataSource = dbHost;
            stringConnectionBuilder.InitialCatalog = dbName;
            stringConnectionBuilder.UserID = username;
            stringConnectionBuilder.Password = password;

            try
            {
                this.connection = new SqlConnection(stringConnectionBuilder.ConnectionString);
            }
            catch (Exception e) //TODO ver si hay que logear...
            {
                DialogResult result;
                result = MessageBox.Show("Error al conectar con la base de datos. La aplicación se cerrará.", "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public DataSet executeQuery(String query)
        {
            try
            {
                connection.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataSet result = new DataSet();
                    adapter.Fill(result);
                    return result;
                }
            }
            catch (SqlException e)
            {
                DialogResult result;
                result = MessageBox.Show("Error al consultar la base de datos." + e.Message, "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }

        public void executeTransaction(List<string> queries)
        {
            
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    foreach (string query in queries)
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("All records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    MessageBox.Show("Hubo un error al realizar la operacion deseada. Intente nuevamente!");

                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
           
        }
    }

}
