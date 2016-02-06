using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.WebUI.HTMLHelpers
{
    public class PagingHelpers
    {
        public static MvcHtmlString PageLinks(PageInfo p,Func<int,string> f)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 1; i <= Math.Ceiling((decimal)p.NumProducts/p.PageSize) ; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                
                tag.SetInnerText("Page"+i);
                string strtest = f.Method.ToString();
                tag.Attributes["HREF"] = f(i);
                if (p.CurrentPage==i)
                {
                    tag.AddCssClass("active");
                    tag.AddCssClass("btn btn-primary");    

                }
                tag.AddCssClass("btn btn-default");
                str.Append(tag);
                
            }

            return MvcHtmlString.Create(str.ToString());
        }
        
    }
}
