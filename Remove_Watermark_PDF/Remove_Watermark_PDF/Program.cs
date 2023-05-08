using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Load the PDF document
FileStream docStream = new FileStream("../../../Input.pdf", FileMode.Open, FileAccess.Read);
//Load the PDF document
PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);
for (int i = 0; i < loadedDocument.Pages.Count; i++)
{
    //Get the page 
    PdfLoadedPage lpage = loadedDocument.Pages[i] as PdfLoadedPage;
    //Gets the annotation collection
    PdfLoadedAnnotationCollection annotations = lpage.Annotations;
    for (int j = 0; j < annotations.Count; j++)
    {
        //Gets the annotation
        PdfLoadedAnnotation annotation = lpage.Annotations[j] as PdfLoadedAnnotation;
        if (annotation != null && annotation is PdfLoadedWatermarkAnnotation)
        {
            //Removes the first annotation
            annotations.RemoveAt(j);
        }
    }
}
//Create file stream.
using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"../../../Output.pdf"), FileMode.Create, FileAccess.ReadWrite))
{
    //Save the PDF document to file stream.
    loadedDocument.Save(outputFileStream);
}
//Close the document.
loadedDocument.Close(true);
