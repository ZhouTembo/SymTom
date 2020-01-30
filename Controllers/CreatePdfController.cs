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
using static iTextSharp.text.Font;

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
                Font hope = new Font(FontFamily.COURIER, 16, Font.BOLD);
                

                Paragraph loc = new Paragraph("Location", hope);
                Paragraph sym = new Paragraph("Symptom", hope);
                Paragraph dat = new Paragraph("Date", hope);
                Paragraph sev = new Paragraph("Severity", hope);

                symptom.AddCell(loc); //col 1 row 1
                
                symptom.AddCell(sym); //col 2 row 1
                symptom.AddCell(dat); //col 1 row 2
                symptom.AddCell(sev); //col 2 row 2
                
                foreach (var item in symptoms)
                {
                    symptom.AddCell(item.Location);
                    symptom.AddCell(item.Name);                    
                    symptom.AddCell(item.Date);
                    symptom.AddCell(item.Severity.ToString());

                }

                symptom.HorizontalAlignment = Element.ALIGN_CENTER;

            }//declare new table
             //col 1 row 3
            string url = "https://doctorfreedompodcast.podbean.com/mf/web/4pmf3k/2-doctors-x-ray.jpg";
            Image img = Image.GetInstance(url);
            img.ScaleToFit(800f, 800f);
            img.HasBorders();
            
            img.ScaleAbsolute(500f, 500f);
            img.Alignment = Element.ALIGN_CENTER;


            Font font = new Font(FontFamily.HELVETICA, 20, Font.BOLD);
            Font stew = new Font(FontFamily.HELVETICA, 16, Font.BOLD, BaseColor.RED);


            Paragraph header = new Paragraph("List of Symptoms",font);
            header.Alignment=Element.ALIGN_CENTER;
            header.SetLeading(18,0);

            Paragraph sent = new Paragraph("Remember to speak with your physician about these symptoms at your next appointment.", stew);
            sent.Alignment = Element.ALIGN_CENTER;


            pdfDoc.Add(header);
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(symptom);
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(sent);
            pdfDoc.Add(img);
            pdfDoc.Close();
            
            

            return View();
        }
        
    }
}