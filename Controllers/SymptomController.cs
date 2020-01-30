using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SymTom.Data;
using SymTom.Models;
using SymTom.ViewModels;

namespace SymTom.Controllers
{
    public class SymptomController : Controller
    {
        private readonly SymptomDbContext context;

        public SymptomController(SymptomDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {

            /*var allSymptoms = context.Symptoms.ToList();*/
            return View();
        }

        

        public IActionResult Add()
        {
            AddSymptomViewModel addSymptomViewModel = new AddSymptomViewModel();
            return View(addSymptomViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddSymptomViewModel addSymptomViewModel)
        {
            
                // Add the new symptom to my existing symptoms
                Symptom newSymptom = new Symptom
                {
                    Name = addSymptomViewModel.Name,
                    Date = addSymptomViewModel.Date,
                    Location = addSymptomViewModel.Location,
                    Severity= addSymptomViewModel.Severity,
                };

                context.Symptoms.Add(newSymptom);
                context.SaveChanges();

                return Redirect("/Symptom/List");
            

            
        }
    
        


        public IActionResult List()
        {
            IList<Symptom> symptoms = context.Symptoms.ToList();
           return View(symptoms);
        }
         public IActionResult Remove()
        {
            IList<Symptom> symptoms = context.Symptoms.ToList();
            return View(symptoms);
        }

        [HttpPost]
        public IActionResult Remove(int[] symptomIds)
        {
            foreach (int symptomId in symptomIds)
            {
                Symptom theSymptom = context.Symptoms.Single(c => c.ID == symptomId);
                context.Symptoms.Remove(theSymptom);
            }

            context.SaveChanges();
            IList<Symptom> symptoms = context.Symptoms.ToList();

            return View(symptoms);
        }

        
    }
}