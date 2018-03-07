using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;


namespace BusinessLayer
{
    public class Business
    {
        DataAccess dc = new DataAccess();

        public int AddorEditUsers(Users _users)
        {
            return 1;
        }


        public void AddBlogs(Posts pst)
        {
            dc.AddNewPost(pst);
        }

      public List<Posts>  GetAllPosts(int? postid)
        {
           List<Posts> pst= dc.GetAllPosts(postid);
            return pst;
        }

        public void LikePost(int postid)
        {
            dc.LikePost(postid);
        }

    }
}
