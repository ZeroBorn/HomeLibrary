using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Data
{
    class DataBaseContext:DbContext
    {
        public DbSet<Library> Library { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder context)
        {
            context.UseSqlServer(@"data source =12-233\SQLEXPRESS; Initial catalog =HomeLib;User Id =U-19K; Password=19K$YcYO");
        }
    }
}
