using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.Exceptions
{
    public class InvalidRegistration : Exception
    {
        public InvalidRegistration(string Messsage) : base(Messsage)
        {

        }
    }
}
