using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Text;

namespace BlazorApp1.Data
{
    public class ExportService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ExportService(IWebHostEnvironment host)
        {
            _hostingEnvironment = host;
        }
        public MemoryStream CreatePDF()
        {
            PdfDocument document = new PdfDocument();
            PdfPage currentPage = document.Pages.Add();
            Syncfusion.Drawing.SizeF clientSize = currentPage.GetClientSize();


            //string fontPath = @"C:\Users\exter\Downloads\arial.ttf"; // Replace with the actual path to your font file

            //PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(fontPath, 12);
            //PdfFont pdfFont = new PdfTrueTypeFont(trueTypeFont, 12);
            string text = "Žáci druhých a třetích ročníků konají dle vzdělávacího programu povinně souvislou čtrnáctidenní praxi ve firmách, které ke své činnosti využívají prostředky informačních technologií. Firmy, ve kterých budou žáci konat praxi, si zajišťují sami žáci. Firma, ve které bude žák konat praxi, musí splnit následující podmínky. První podmínkou konání praxe je, aby měl žák během praxe takové pracovní zařazení, které mu umožní přímo pracovat s prostředky informačních technologií. A to v jakékoliv formě. Druhou podmínkou je, aby místem konání praxe byla ČR. Praxe dále musí být konána takovým způsobem, aby žák pracoval v reálných podmínkách firmy, s pravidelnou denní docházkou do firmy (osmihodinovou, denní pracovní dobou). Firma tedy musí mít provozovnu. Není možný způsob konání praxe např. formou „práce z domova“ nebo práce na “vlastních projektech ve vlastní firmě”. V případě, že si žáci budou zajišťovat praxi sami, proběhne praxe pro druhé ročníky v termínu 24. 4. do 5. 5. 2023, pro třetí ročníky v termínu 8. 5. do 19. 5. 2023. Ve výjimečném případě je možné zajištění praxe školou. Soukromá střední škola výpočetní techniky je schopna zajistit tuto praxi jednotlivým žákům nebo skupinám žáků ve firmách, se kterými má v tomto smyslu uzavřenu smlouvu. Škola nedostává od těchto firem žádné finanční prostředky a žáci za praxi neobdrží žádnou mzdu. Počet pracovních míst, které může škola takto žákům zajistit je limitován. Proto může nastat situace, že žák, který si nedokázal zajistit praxi sám, vykoná souvislou čtrnáctidenní praxi v době hlavních prázdnin. Formu zajištění praxe oznámí zákonný zástupce žáka pomocí informačního systému praxe.sssvt.cz, kde po přihlášení do systému pomocí přihlašovacích údajů vašeho syna / dcery, vyplníte a následně vytisknete formulář o zajištění praxe. Vytištěný a podepsaný formulář odevzdají žáci druhých a třetích ročníků Ing. Kratochvílovi nejpozději do 9. 1. 2023.";
            int maxCharactersPerLine = 89; // Maximum number of characters per line

            StringBuilder sb = new StringBuilder();
            int currentIndex = 0;

            while (currentIndex < text.Length)
            {
                int charactersRemaining = text.Length - currentIndex;
                int charactersToWrite = Math.Min(maxCharactersPerLine, charactersRemaining);

                string line = text.Substring(currentIndex, charactersToWrite);
                sb.AppendLine(line);

                currentIndex += charactersToWrite;
            }
            string wrappedText = sb.ToString();

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 30, PdfFontStyle.Bold);
            var headerText = new PdfTextElement("Přihláška na praxi", font, new PdfSolidBrush(Color.FromArgb(1, 53, 67, 168)));
            //headerText.StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            PdfLayoutResult result = headerText.Draw(currentPage, new PointF(currentPage.Size.Width /2 - 150,2));

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            headerText = new PdfTextElement(wrappedText, font);
            result = headerText.Draw(currentPage, new PointF(20,50));


            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            stream.Position = 0;

            return stream;
        }
    }
}
