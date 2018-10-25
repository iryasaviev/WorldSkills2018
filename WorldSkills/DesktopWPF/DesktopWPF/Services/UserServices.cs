using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public string GetUserEmail()
        //{
        //    return _crud.GetItem();
        //}
    }
}