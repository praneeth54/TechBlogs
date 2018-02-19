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


        public List<Users> GetAllUsers()
        {
            List<Users> users = tc.Users.ToList();
            return users;
        }

        public List<Users> GetUsersByID(int ID)
        {
            List<Users> users = tc.Users.Where(x=>x.UserID==ID).ToList();
            return users;
        }

        public List<Posts> GetAllPosts()
        {
            List<Posts> posts = tc.Posts.ToList();
            return posts;
        }

        public List<Posts> GetPostsByID(int postId)
        {
            List<Posts> postsbyid = tc.Posts.Where(x => x.PostId == postId).ToList();
            return postsbyid;
        }

        public void DeleteUser(int id)
        {
            Users usr = tc.Users.Where(x=>x.UserID==id).FirstOrDefault();
            tc.Users.Remove(usr);
            //return status and use SP
        }

        public void DeleteUsers(int[] ids)
        {
            //return status and use SP
        }


        // posts

         

    }
}
