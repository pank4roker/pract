using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Vlaueobj
{
    public class FullName : BaseValueObj
    {
        public FullName(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        /// <summary>
        /// Может быть отчеством
        /// </summary>
        public string? MiddleName { get; set; } = null;
    }
}
