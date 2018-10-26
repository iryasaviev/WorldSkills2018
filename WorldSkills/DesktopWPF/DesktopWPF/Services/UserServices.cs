using System;
using System.Collections.Generic;
using System.IO;

namespace DesktopWPF.Services
{
    public class UserServices
    {
        CrudServices _crud;
        public UserServices()
        {
            _crud = new CrudServices();
        }

        public void AddUser(List<string> data)
        {
            _crud.Add("User", data);
        }
        
        public Dictionary<string, string> Get(string login)
        {
            return _crud.GetString("User", "Login = " + "'" + login + "'");
        }


        public void SetCookie()
        {
            string path = "D:/GitHub/WorldSkills/DesktopWPF/DesktopWPF/Cookie.txt";
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                string key = Guid.NewGuid().ToString();

                byte[] array = System.Text.Encoding.Default.GetBytes(key);

                stream.Write(array, 0, array.Length);
            }
        }

        public void DelCookie()
        {
            string path = "D:/GitHub/WorldSkills/DesktopWPF/DesktopWPF/Cookie.txt";
            FileInfo file = new FileInfo(path);

            file.Delete();
        }
    }
}