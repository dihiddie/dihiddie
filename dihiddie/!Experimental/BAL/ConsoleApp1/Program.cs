using dihiddie.BAL.DocxReader.Xceed.Repository;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Application app = new word.Application();
            //// Document doc = app.Documents.(@"C:\Users\User\Desktop\текст\вопросы.docx");
            //object readFromPath = @"C:\Users\User\Desktop\текст\вопросы.docx";

            //object nullobj = System.Reflection.Missing.Value;

            //List<string> data = new List<string>();
            //Application app = new Application();
            //Document doc = app.Documents.OpenNoRepairDialog(ref readFromPath, ref nullobj, ref nullobj,

            //ref nullobj, ref nullobj, ref nullobj,

            //                                      ref nullobj, ref nullobj, ref nullobj,

            //                                      ref nullobj, ref nullobj, ref nullobj);

            //Console.WriteLine((DateTime)doc.BuiltInDocumentProperties[Microsoft.Office.Interop.Word.WdBuiltInProperty.wdPropertyTimeCreated].Value);


            //foreach (Paragraph objParagraph in doc.Paragraphs)
            //    data.Add(objParagraph.Range.Text.Trim());

            //((_Document)doc).Close();
            //((_Application)app).Quit();

            DocxRepository repo = new DocxRepository(@"C:\Users\User\Desktop\текст");
            repo.GetAllFilesInformation();

            Console.ReadKey();
        }
    }
}
