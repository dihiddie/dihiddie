using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;

namespace dihiddie.BAL.DocxReader.InteropWord
{
    using word = Microsoft.Office.Interop.Word;

    public class Class1
    {
        public Class1()
        {
            // Application app = new word.Application();
            // Document doc = app.Documents.(@"C:\Users\User\Desktop\текст\вопросы.docx");
            object readFromPath = @"C:\Users\User\Desktop\текст\вопросы.docx";

            List<string> data = new List<string>();
            Application app = new Application();
            Document doc = app.Documents.OpenNoRepairDialog(ref readFromPath);

            foreach (Paragraph objParagraph in doc.Words)
                data.Add(objParagraph.Range.Text.Trim());

            ((_Document)doc).Close();
            ((_Application)app).Quit();

            Console.ReadKey();

        }
    }
}
