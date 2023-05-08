using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Interactive;

FileStream docStream = new FileStream("../../../Data/Input.pdf", FileMode.Open, FileAccess.Read);
//Load the PDF document
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
PdfLoadedPage lpage = loadedDocument.Pages[0] as PdfLoadedPage;
//Creates PDF watermark annotation 
PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(new RectangleF(100, 300, 400, 400));
//Sets properties to the annotation 
watermark.Opacity = 0.5f;
//Create the appearance of watermark 
FileStream imageStream = new FileStream("../../../Data/Image.jpg", FileMode.Open, FileAccess.Read);
PdfImage image = new PdfBitmap(imageStream);
watermark.Appearance.Normal.Graphics.DrawImage(image, new PointF(0, 0));
//Adds the annotation to page 
lpage.Annotations.Add(watermark);

//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);

