using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public partial class AspNetUsers
    {
        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public override string ToString()
        {
            return $"{Id}-{FullName}";
        }
    }
}
