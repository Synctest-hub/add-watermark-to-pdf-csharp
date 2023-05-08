using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

//Load the PDF document
FileStream inputStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputStream);
//Get the page  
PdfLoadedPage lpage = loadedDocument.Pages[0] as PdfLoadedPage;

//Creates PDF watermark annotation  
PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(new RectangleF(100, 300, 400, 400));
//Sets properties to the annotation  
watermark.Opacity = 0.5f;
//Create the appearance of watermark  
watermark.Appearance.Normal.Graphics.DrawString("Imported using Essential PDF", new PdfStandardFont(PdfFontFamily.Helvetica, 20), PdfBrushes.Red, new RectangleF(50, 50, 250, 50), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
//Adds the annotation to page  
lpage.Annotations.Add(watermark);

FileStream stream = new FileStream("../../../Output.pdf", FileMode.Create);
//Save the modified document to file. 
loadedDocument.Save(stream);
//Close the PDF document. 
loadedDocument.Close(true);
stream.Close();