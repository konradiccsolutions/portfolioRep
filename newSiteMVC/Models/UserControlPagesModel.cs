using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSiteMVC.Models
{
    public class UserControlPagesModel
    {
        public IEnumerable<tbl_UserControl> tbl_UserControlObject { get; set; }
        public IEnumerable<tbl_Pages> tbl_PagesObject { get; set; }

    }
}