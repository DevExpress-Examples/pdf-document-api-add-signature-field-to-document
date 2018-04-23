using DevExpress.Pdf;
using System.Drawing;

namespace AddSignatureField {
    class Program {
        static void Main(string[] args) {

            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Create an empty document. 
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create graphics and draw a signature field.
                using (PdfGraphics graphics = processor.CreateGraphics()) {
                    DrawSignatureField(graphics);

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }
        }

        static void DrawSignatureField(PdfGraphics graphics) {

            // Create a signature field specifying its name and location.
            PdfGraphicsAcroFormSignatureField signature = new PdfGraphicsAcroFormSignatureField("signature", new RectangleF(0, 20, 120, 130));

            // Specify a content image for the signature field.
            Image image = Image.FromFile("..\\..\\Image.png");
            signature.ContentImage = image;            
     
            // Add the field to the document.
            graphics.AddFormField(signature);
        }
    }
}
