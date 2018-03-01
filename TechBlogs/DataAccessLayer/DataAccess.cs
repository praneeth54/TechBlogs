using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class DataAccess
    {
        TechContext tc = new TechContext();

        // Users and Admins
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


        public void DeleteUser(int id)
        {
            Users usr = tc.Users.Where(x => x.UserID == id).FirstOrDefault();
            tc.Users.Remove(usr);
            //return status and use SP
        }

        public void DeleteUsers(int[] ids)
        {
            //return status and use SP
        }

        //** All Posts

        public void AddNewPost(Posts post)
        {
            tc.Posts.Add(post);
        }

        public List<Posts> GetAllPosts(int? id)
        {
                int pageNumber = id ?? 0;
            List<Posts> pst = (from post in tc.Posts
                                      where post.DateTimePost < DateTime.Now
                                      orderby post.DateTimePost descending
                                      select post).ToList();
                //ViewBag.IsPreviousLinkVisible = pageNumber > 0;
                //ViewBag.IsNextLinkVisible = pst.Count() > PostsperPage;
                //ViewBag.PageNumber = pageNumber;
                //ViewBag.IsAdmin = IsAdmin;
               // return View(pst.Take(PostsperPage));
            //List<Posts> posts = tc.Posts.ToList();
            return pst;
        }


        public List<Posts> GetPostsByID(int postId)
        {
            List<Posts> postsbyid = tc.Posts.Where(x => x.PostId == postId).ToList();
            return postsbyid;
        }


        public void UpdatePosts(Posts pst)
        {
          
        }

      


        // posts

         

    }
}
