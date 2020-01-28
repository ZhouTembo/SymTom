using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SymTom.Models;
using SymTom.Data;
using Grpc.Core;

namespace SymTom.Controllers
{
    public class CreatePdfController : Controller
    {
        private readonly SymptomDbContext context;

        public CreatePdfController(SymptomDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post()
        {
            List<Symptom> symptoms = context.Symptoms.ToList();
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.Body);
            pdfDoc.Open();
            PdfPTable symptom = new PdfPTable(4); 
            {
                symptom.AddCell("Location"); //col 1 row 1
                symptom.AddCell("Symptom"); //col 2 row 1
                symptom.AddCell("Date"); //col 1 row 2
                symptom.AddCell("Severity"); //col 2 row 2
                
                foreach (var item in symptoms)
                {
                    symptom.AddCell(item.Location);
                    symptom.AddCell(item.Name);                    
                    symptom.AddCell(item.Date);
                    symptom.AddCell(item.Severity.ToString());

                }


            }//declare new table
                 //col 1 row 3
            pdfDoc.Add(symptom);
            pdfDoc.Add(new Paragraph("Remember to speak with your physician about these symptoms at your next appointment."));
            pdfDoc.Close();
            
            

            return View();
        }
        
    }
}