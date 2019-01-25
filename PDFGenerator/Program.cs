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
using System.Threading;
using System.Diagnostics;

namespace PDFGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            //Initialization  
            //retrieve input file lines on console input
            string input = Console.ReadLine();
            string[] lines = File.ReadAllLines(input);
            //retrieve input file name
            string file_name = input.Substring(input.LastIndexOf("/")).Split('.')[0];
            //create output pdf file in the same folder with same name
            string output = input.Substring(0, input.LastIndexOf("/")+1) + file_name +".pdf";
            PdfWriter writer = new PdfWriter(new FileStream(output, FileMode.Create));
            //create objects to write in the pdf file
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph par = new Paragraph();
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            Text text = new Text("");

            //Processing 
            //Loop for each input line 
            Boolean firstCommand = true;
            foreach (string line in lines)
            {
                if (line[0] == '.') //if this line is a command 
                {
                    if (firstCommand) //make sure it's not the second command in a row before appending previous text from the previous loop to the file
                    {
                        firstCommand = false;
                        par.Add(text);
                    } //TODO no space after a command - text on one line - fill comes after indent - /eplxain / not \ explain that my fill and unfill command make new paragraphs /that it doesn't handle "no space" scenario
                    switch (line)
                    { //apply changes to paragraph or text according to the command
                        case ".large":
                            text = new Text("");
                            text.SetFontSize(30.0f);
                            break;
                        case ".normal":
                        case ".regular":
                            text = new Text("");
                            break;
                        case ".paragraph":
                            document.Add(par);
                            par = new Paragraph();
                            break;
                        case ".fill":
                            document.Add(par);
                            par = new Paragraph();
                            par.SetTextAlignment(TextAlignment.JUSTIFIED);
                            break;
                        case ".nofill":
                            document.Add(par);
                            par = new Paragraph();
                            par.SetTextAlignment(TextAlignment.LEFT);
                            break;
                        case ".italics":
                            text = new Text("");
                            text.SetItalic();
                            break;
                        case ".bold":
                            text = new Text("");
                            text.SetBold();
                            break;
                        default:
                            if (line.Split(' ')[0].Equals(".indent"))
                            {
                                par.SetMarginLeft(float.Parse(line.Split(' ')[1])*10.0f);
                            }
                            else { 
                            Debug.WriteLine("Met unknown command : " + line);
                            }
                            break; 

                    }
                }
                else { 
                        text.SetText(line); //if not a command, set this line as text 
                        firstCommand = true;
                }
            }
            //Last step : append the previous text and close file
            par.Add(text);
            document.Add(par);
            document.Close();
        }
    }
}
