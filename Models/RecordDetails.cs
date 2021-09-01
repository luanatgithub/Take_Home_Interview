using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadExcelWebMVC.Models
{
    public class RecordDetails
    {
        public string TransID { get; set; }
        public string Order { get; set; }
        public string TransType { get; set; }
        public double Amount { get; set; }
        public string TransDate { get; set; }
        public string Name { get; set; }
    }
}
