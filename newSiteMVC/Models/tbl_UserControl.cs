using System.Web.Mvc;

namespace newSiteMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_UserControl
    {
        [Key]
        public int Id { get; set; }

        [AllowHtml]
        public string Title { get; set; }

        [AllowHtml]
        public string Subtitle { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string MainText { get; set; }
        [StringLength(100)]
        public string ButtonText { get; set; }

        public string ImageUrl { get; set; }

        public string UrlLink { get; set; }

        public string PageId { get; set; }

        public string TypeId { get; set; }

        public bool? Active { get; set; }

        public string BackgroundColour { get; set; }

        public string ButtonColour { get; set; }

        public string ButtonTextColour { get; set; }

        public string TitleColour { get; set; }

        public string MainTextColour { get; set; }

        public string SectionBackgroundColour { get; set; }

        public string SectionTextColour { get; set; }

        public string SectionTextUnderlineColour { get; set; }

        public int? Priority { get; set; }

    }
}
