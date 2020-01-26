using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SymTom.ViewModels
{
    public class AddSymptomViewModel 
    { 


        public int ID { get; set; }

        [Required]
        [Display(Name = "Symptom")]
        public string Name { get; set; }


        [Required]
        public string Location { get; set; }


        [Required(ErrorMessage = " Give your symptom a severity")]
        public int Severity { get; set; }

        [Display(Name = "Date Noticed")]
        [Required(ErrorMessage = "Please enter a start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string Date { get; set; }



        }
}
