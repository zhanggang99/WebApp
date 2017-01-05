using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BlogInfosController : ApiController
    {
        BlogInfo[] bloginfos = new BlogInfo[]
        {
            new BlogInfo {BlogId=1,Title="我的第一个博客",Content="我的第一个博客内容",CreatedTime=System.DateTime.Now},
            new BlogInfo {BlogId=2,Title="我的第二个博客",Content="我的第二个博客内容",CreatedTime=System.DateTime.Now},
            new BlogInfo {BlogId=3,Title="我的第三个博客",Content="我的第三个博客内容",CreatedTime=System.DateTime.Now},
            new BlogInfo {BlogId=5,Title="我的第四个博客",Content="我的第四个博客内容",CreatedTime=System.DateTime.Now}
        };

        public List<BlogInfo> GetAllBlogInfos()
        {
            // return bloginfos;
            return ESHelper.GetAllBlogs();

        }
        //public IEnumerable<BlogInfo> GetAllBlogInfos()
        //{
        //    // return bloginfos;
        //    return ESHelper.GetAllBlogs();
            
        //}
        public IEnumerable<BlogInfo> GetAllBlogInfos(DateTime createdTime)
        {
            return ESHelper.GetBlogsByDate(createdTime);
        }
        public IHttpActionResult GetBlogInfo(long id)
        {
            //var bloginfo = bloginfos.FirstOrDefault((p)=>p.BlogId==id);
            var bloginfo = ESHelper.GetBlogByBlodId(id);
            if (bloginfo == null)
                return NotFound();
            return Ok(bloginfo);
        }


        //public IEnumerable<Product> GetProductsByCategory(string category)
        //{
        //    return products.Where(
        //        (p) => string.Equals(p.Category, category,
        //            StringComparison.OrdinalIgnoreCase));
        //}

    }
}
