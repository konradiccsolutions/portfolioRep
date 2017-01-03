using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newSiteMVC.Models
{
    public class UpdateSectionModel
    {
        public int Id { get; set; }

        public int? TypeId { get; set; }

        public string BackgroundColour { get; set; }

        public string ButtonColour { get; set; }

        public string ButtonTextColour { get; set; }

        public string TitleColour { get; set; }

        public string MainTextColour { get; set; }

       
    }
}