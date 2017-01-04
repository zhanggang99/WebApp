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
        BlogInfo[] bloginfos=new BlogInfo[]
        {
            new BlogInfo {BlogId=1,Title="我的第一个博客",Content="我的第一个博客内容",CreatedTime=System.DateTime.Now},
            new BlogInfo {BlogId=1,Title="我的第二个博客",Content="我的第二个博客内容",CreatedTime=System.DateTime.Now},
            new BlogInfo {BlogId=1,Title="我的第三个博客",Content="我的第三个博客内容",CreatedTime=System.DateTime.Now},
            new BlogInfo {BlogId=1,Title="我的第四个博客",Content="我的第四个博客内容",CreatedTime=System.DateTime.Now}
        }
        public IEnumerable<BlogInfo> GetAllBlogInfos()
        {
            return bloginfos;
        }

        public IHttpActionResult GetBlogInfo(long blogid)
        {
            var bloginfo = bloginfos.FirstOrDefault((p)=>p.BlogId==blogid);
            if (bloginfo == null)
                return NotFound();
            return Ok(bloginfo);
        }
    }
}
