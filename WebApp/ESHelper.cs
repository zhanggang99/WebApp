using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;
using WebApp.Models;

namespace WebApp
{
    public class ESHelper
    {
        public static ElasticClient client;
        static ESHelper()
        {
            var node = new Uri("http://localhost:9200");
            var settings = new ConnectionSettings(node);
            settings.DefaultIndex("myblog");
            client = new ElasticClient(settings);
        }
        public static IEnumerable<BlogInfo> GetBlogsByDate(DateTime createdTime)
        {
            var response = client.Search<BlogInfo>(s=>s.Query(q=>q.Bool(b=>b.Should(sd=>sd.TermRange(tr=>tr.GreaterThan(System.DateTime.Now.AddDays(-30).ToString("yyyyMMddhhmmss")).Field(f=>f.BlogId))))).Sort(ss=>ss.Descending(p=>p.BlogId)));
            IEnumerable<BlogInfo> list = new BlogInfo[] { };
            if (response.Documents.Count>0)
            {
                foreach (BlogInfo document in response.Documents)
                {
                    list.Add<BlogInfo>(document);
                }
            }
            return list ;

        }

        //public static IEnumerable<BlogInfo> GetAllBlogs()
        //{
        //    var response = client.Search<BlogInfo>(s => s.Query(q=>q.MatchAll()).Sort(ss=>ss.Descending(f=>f.BlogId)));
        //    //IEnumerable<BlogInfo> list = new BlogInfo[] { };
        //    IEnumerable<BlogInfo> list = new List<BlogInfo>();
        //    if (response.Documents.Count > 0)
        //    {
        //        foreach (BlogInfo document in response.Documents)
        //        {
        //            list.Add<BlogInfo>(document);
        //        }
        //    }
        //    return list;

        //}
        public static List<BlogInfo> GetAllBlogs()
        {
            var response = client.Search<BlogInfo>(s => s.Query(q => q.MatchAll()).Sort(ss => ss.Descending(f => f.BlogId)));
            //IEnumerable<BlogInfo> list = new BlogInfo[] { };
            List<BlogInfo> list = new List<BlogInfo>();
            if (response.Documents.Count > 0)
            {
                foreach (BlogInfo document in response.Documents)
                {
                    list.Add(document);
                }
            }
            return list;

        }
        public static BlogInfo GetBlogByBlodId(long blogid)
        {
            var response = client.Search<BlogInfo>(s=>s.Query(q=>q.Term(p=>p.BlogId,blogid)));
            return response.Documents.FirstOrDefault();
        }

    }
}