namespace newSiteMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreDB : DbContext
    {
        public StoreDB()
            : base("name=StoreDB")
        {
        }

        public virtual DbSet<tbl_Pages> tbl_Pages { get; set; }
        public virtual DbSet<tbl_UserControl> tbl_UserControl { get; set; }
        public virtual DbSet<UpdateSectionModel> sectionUpdate { get; set; }
        public virtual DbSet<tbl_UserControlType> tbl_UserControlType { get; set; }
        public virtual DbSet<tbl_Users> tbl_Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
