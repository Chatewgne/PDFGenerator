using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Colors;

namespace PDFGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //OUTPUT PDF
            // String dest = Console.ReadLine();
            //    FileInfo file = new FileInfo(DEST);
            //   file.Directory.Create();
            //  new C01E01_HelloWorld().CreatePdf(DEST);
            Boolean firstCommand = true;
            PdfWriter writer = new PdfWriter("D:/Projects/PDFtest/helloworld.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph par = new Paragraph();
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            Text text = new Text("");
            //INPUT TXT
            string[] lines = File.ReadAllLines("D:/Projects/PDFtest/input.txt");
            foreach (string line in lines)
            {
                if (line[0] == '.')
                {
                    if (firstCommand)
                    {
                        firstCommand = false;
                        par.Add(text);
                    } //TODO explain that my fill and unfill command make new paragraphs /that it doesn't handle "no space" scenario
                  //  text.SetText(""); 
                    switch (line) {
                        case ".large":
                            //      par.Add(text);
                            text = new Text("");
                            text.SetFontSize(30.0f);
                            break;
                        case ".normal":
                        case ".regular":
                            //      par.Add(text);
                            text = new Text("");
                            break;
                        case ".paragraph":
                      //      par.Add(text);
                            document.Add(par);
                            par = new Paragraph();
                            break;
                        case ".fill":
                            //        par.Add(text);
                            document.Add(par);
                            par = new Paragraph();
                            par.SetTextAlignment(TextAlignment.JUSTIFIED);
                            break;
                        case ".nofill":
                            //        par.Add(text);
                            document.Add(par);
                            par = new Paragraph();
                            par.SetTextAlignment(TextAlignment.LEFT);
                            break;
                        case ".italics":
                      //      par.Add(text);
                            text = new Text("");
                            text.SetItalic();
                            break;
                        case ".bold":
                       //     par.Add(text);
                            text = new Text("");
                            text.SetBold();
                            break;
                        case (".indent"): //TODO attention celui ci prend un argument

                   //         par.SetBorderLeft(new DoubleBorder(3.0f).SetColor(new Color());
                            break;  //TODO what is the .normal one ??
                        default:
                            Console.WriteLine("Met unknown command : " + line);
                            break; 

                    }
                }
                else {
                    if (text == null) {
                        Console.WriteLine(" !!!! Empty text !!!! ");
                    }
                    else {
                   
                            text.SetText(line);
                       
                        
                        firstCommand = true;
                    }
                }
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }
            par.Add(text);
            document.Add(par);
            document.Close();
        }
    }
}
