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
                result = MessageBox.Show("Error al conectar con la base de datos. La aplicación se cerrará." + e.Message, "ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally {
                if (connection.State == ConnectionState.Open) connection.Close();
            }
        }
    }

}
