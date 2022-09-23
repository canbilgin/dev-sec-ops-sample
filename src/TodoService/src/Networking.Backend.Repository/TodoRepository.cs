using System.Data;

using Microsoft.Data.SqlClient;

using Networking.Backend.Client;

namespace Networking.Backend.Repository
{
    public class TodoRepository
    {
        private const string _connectionString =
            "Server=tcp:sql-networking-sample.database.windows.net,1433;Initial Catalog=sql-todo-db;Persist Security Info=False;User ID=sqladmin;Password=Fenerbahce1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public TodoRepository()
        {

        }

        public List<Todo> GetTodos()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            try
            {
                List<Todo> todosList = new List<Todo>();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "dbo.usp_GetTodos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                conn.Open();

                var da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                todosList.AddRange(ds.Tables[0].ToEnumerableDto());

                conn.Close();
                return todosList;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
        }
    }
}