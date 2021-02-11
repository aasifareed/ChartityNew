using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class PageModel
{
    public int PageId { get; set; }
    public string PageName { get; set; }
    [AllowHtml]
    public string Content_Eng { get; set; }
    [AllowHtml]
    public string Content_Tr { get; set; }
    [AllowHtml]
    public string Content_Ar { get; set; }
}
