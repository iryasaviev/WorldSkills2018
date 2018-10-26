using System.Collections.Generic;
using System.Data.SqlClient;

namespace DesktopWPF.Services
{
    public class CrudServices
    {
        Database _database;
        public CrudServices()
        {
            _database = new Database();
            _database.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }


        public void Add(string tableName, List<string> data)
        {
            string values = "";

            // Превращает список в строку.
            foreach (string d in data)
            {
                if (values == "")
                {
                    values = "'" + d + "'" + ", ";
                }
                else
                {
                    values = values + "'" + d + "'" + ", ";
                }
            }

            // Удаляет последний символ (",") с троке.
            values = values.Substring(0, values.Length - 2);



            // Открывает и возвращает подключение.
            var connection = _database.ConnectionOpen();
            
            SqlCommand command = new SqlCommand {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO " + '"' + tableName + '"' + " VALUES (" + values + ")"
            };
        }


        public Dictionary<string, string> GetString(string tableName, string condition)
        {
            // Открывает и возвращает подключение.
            SqlConnection connection = _database.ConnectionOpen();


            string request = request = "SELECT TOP 1 * FROM " + '"' + tableName + '"' + " WHERE " + condition;

            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = request
            };


            SqlDataReader reader = command.ExecuteReader();
            
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (reader.HasRows)
            {
                var i = 0;
                while (reader.Read())
                {
                    while (reader.FieldCount > i)
                    {
                        // Добавляет имя столбца и его значение.
                        data.Add(reader.GetName(i), reader.GetValue(i).ToString());
                        
                        i++;
                    }
                }
            }

            return data;
        }
    }
}