using System.Collections.Generic;

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
    }
}