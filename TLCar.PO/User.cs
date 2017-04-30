using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLCar.Core;

namespace TLCar.PO
{
    public class User : IAggregageRoot
    {
        public int ID { get; set; }
        public Guid guid { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public string testsss { get; set; }
    }
}
