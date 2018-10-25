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

        //public string GetItem(string tableName)
        //{
        //    // Открывает и возвращает подключение.
        //    var connection = _database.ConnectionOpen();

        //    return reader.GetName(0);
        //}
    }
}