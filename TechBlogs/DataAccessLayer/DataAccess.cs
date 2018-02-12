using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using TechBlogs.Models;

namespace DataAccessLayer
{
    public class DataAccess
    {
        TechContext tc = new TechContext();
        public void AddOrEditUser(Users _users)
        {
            if (_users.UserID == 0)
            {
                //_users.FirstName=
                //_users.CreatedDate = System.DateTime.Now;
                //_users.Deleted = false;
                //_users.CreatedBy = "Alekhya";
                //_users.LatestLoginDate = System.DateTime.Now;
                //_users.Status = 1;
                tc.Users.Add(_users);
            }
            else
            {
                //_users.ModifiedDate = System.DateTime.Now;
                //_users.ModifiedBy = "Shilpa";
                //_users.Deleted = false;
                //_users.LatestLoginDate = System.DateTime.Now;
            }


        }
    }
}
