using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dizi_Film_Uyfulaması;
using MySql.Data.MySqlClient;v
namespace ISTEFLIX
{
    internal class Mysql
    {
        public static string connectionString = "server=localhost;user=root;password=root;database=sys;";
        Mysql()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
            }
        }
        public static void command(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Console.WriteLine("ID: {0}, Name: {1}", id, name);
                        }
                    }
                }
            }
        }
        public static List<Prod> ReadDataFromTable(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            List<Prod> list = new List<Prod>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string photo = reader.GetString(1);
                            string url = reader.GetString(2);
                            Prod temp = new Prod(name,photo,url);
                            list.Add(temp);
                        }
                        return list;
                    }
                }
            }
        }
    }
}
