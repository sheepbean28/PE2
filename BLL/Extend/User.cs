using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE2.BLL
{
    public partial class User
    {
        public PE2.Model.User GetModel(string User_no, string Password)
        {
            return dal.GetModel(User_no, Password);
        }
    }
}
