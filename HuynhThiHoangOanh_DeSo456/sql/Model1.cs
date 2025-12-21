using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HuynhThiHoangOanh_DeSo456.sql
{
    public partial class Model1 : DbContext
    {
        internal object diaphuong;

        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<DiaPhuong> DiaPhuong { get; set; }
        public virtual DbSet<TrangThai> TrangThai { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.DiaPhuong)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);
        }
    }
}
