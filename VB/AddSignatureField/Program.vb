Imports DevExpress.Pdf
Imports System.Drawing
Imports System.Runtime.Versioning

Namespace AddSignatureField

    Friend Class Program
        <SupportedOSPlatform("windows")>
        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Create an empty document.
                processor.CreateEmptyDocument("..\..\..\Result.pdf")
                ' Create graphics and draw a signature field.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    DrawSignatureField(graphics)
                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
            Process.Start(New ProcessStartInfo("..\..\..\Result.pdf") With {.UseShellExecute = True})
        End Sub

        <SupportedOSPlatform("windows")>
        Private Shared Sub DrawSignatureField(ByVal graphics As PdfGraphics)
            ' Create a signature field specifying its name and location.
            Dim signature As PdfGraphicsAcroFormSignatureField = New PdfGraphicsAcroFormSignatureField("signature", New RectangleF(0, 20, 120, 130))
            ' Specify a content image for the signature field.
            Dim image As Image = Image.FromFile("..\..\..\Image.png")
            signature.ContentImage = image
            ' Add the field to the document.
            graphics.AddFormField(signature)
        End Sub
    End Class
End Namespace
