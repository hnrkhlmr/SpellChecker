using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Dal.DataTransferObjects
{
    public class UserTestStatDto
    {
        public int UserTestId { get; set; }
        public int Score { get; set; }
        public DateTime TestDate { get; set; }
    }
}
