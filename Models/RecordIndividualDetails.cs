using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadExcelWebMVC.Models
{
    public class RecordIndividualDetails
    {
        public string Name { get; set; }
        
       [Display(Name = "Payment Amount")]
       [DisplayFormat(DataFormatString = "{0:c}")]
        public double PaymentAmount { get; set; }

        [Display(Name = "Obligation Amount")]
        [DisplayFormat( DataFormatString = "{0:c}")]
        public double ObligationAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public double DiffAmount { get; set; }
        public RecordIndividualDetails()
        {
            PaymentAmount = 0;
            ObligationAmount = 0;
            Name = "";
        }
         
    }
}
