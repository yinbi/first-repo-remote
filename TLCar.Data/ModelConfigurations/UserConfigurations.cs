using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.PO;

namespace TLCar.Data.ModelConfigurations
{
    public class UserConfigurations : EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {
            HasKey(u => u.ID);
            Ignore(u => u.testsss);
            Ignore(u => u.guid);
        }
    }
}
