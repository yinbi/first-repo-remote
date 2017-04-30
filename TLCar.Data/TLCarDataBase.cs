using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.Data.ModelConfigurations;

namespace TLCar.Data
{
    public class TLCarDataBase : MyDataBase
    {
        public TLCarDataBase()
            : base("Data Source=127.0.0.1;Initial Catalog=TLCar;User ID=sa;Password=123456;MultipleActiveResultSets=true")
        {
        }
        //public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Article>().Property(u => u.tests).HasColumnName("test_s");
            modelBuilder.Configurations.Add(new UserConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
