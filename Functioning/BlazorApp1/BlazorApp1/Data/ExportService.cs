using HarfBuzzSharp;
using Microsoft.AspNetCore.Hosting.Server;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Text;
using Font = Syncfusion.Drawing.Font;

namespace BlazorApp1.Data
{
    public class ExportService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ExportService(IWebHostEnvironment host)
        {
            _hostingEnvironment = host;
        }
        public MemoryStream CreateApplicationPDF(string studentName, string studentLastName)
        {
            PdfDocument document = new PdfDocument();
            PdfPage currentPage = document.Pages.Add();



            //SSSVT IKONKA

            FileStream imageStream = new FileStream("C:\\Users\\exter\\Desktop\\Praxátor\\Praxe-Exterernity\\62913981.png",FileMode.Open,FileAccess.Read);
            PdfImage image = new PdfBitmap(imageStream);
            SizeF iconSize = new SizeF(80, 80);
            PointF iconLocation = new PointF(0,15);
            PdfGraphics graphics = currentPage.Graphics;
            graphics.DrawImage(image,iconLocation,iconSize);




            SizeF clientSize = currentPage.GetClientSize();
            string text = @"Žáci druhých a třetích ročníků konají dle vzdělávacího programu povinně souvislou čtrnáctidenní praxi ve firmách, které ke své činnosti využívají prostředky informačních technologií. Firmy, ve kterých budou žáci konat praxi, si zajišťují sami žáci. Firma, ve které bude žák konat praxi, musí splnit následující podmínky. První podmínkou konání praxe je, aby měl žák během praxe takové pracovní zařazení, které mu umožní přímo pracovat s prostředky informačních technologií. A to v jakékoliv formě. Druhou podmínkou je, aby místem konání praxe byla ČR. Praxe dále musí být konána takovým způsobem, aby žák pracoval v reálných podmínkách firmy, s pravidelnou denní docházkou do firmy (osmihodinovou, denní pracovní dobou). Firma tedy musí mít provozovnu. Není možný způsob konání praxe např. formou „práce z domova“ nebo práce na “vlastních projektech ve vlastní firmě”. V případě, že si žáci budou zajišťovat praxi sami, proběhne praxe pro druhé ročníky v termínu 24. 4. do 5. 5. 2023, pro třetí ročníky v termínu 8. 5. do 19. 5. 2023. Ve výjimečném případě je možné zajištění praxe školou. Soukromá střední škola výpočetní techniky je schopna zajistit tuto praxi jednotlivým žákům nebo skupinám žáků ve firmách, se kterými má v tomto smyslu uzavřenu smlouvu. Škola nedostává od těchto firem žádné finanční prostředky a žáci za praxi neobdrží žádnou mzdu. Počet pracovních míst, které může škola takto žákům zajistit je limitován. Proto může nastat situace, že žák, který si nedokázal zajistit praxi sám, vykoná souvislou čtrnáctidenní praxi v době hlavních prázdnin. Formu zajištění praxe oznámí zákonný zástupce žáka pomocí informačního systému praxe.sssvt.cz, kde po přihlášení do systému pomocí přihlašovacích údajů vašeho syna / dcery, vyplníte a následně vytisknete formulář o zajištění praxe. Vytištěný a podepsaný formulář odevzdají žáci druhých a třetích ročníků Ing. Kratochvílovi nejpozději do 9. 1. 2023.";
            string wrappedText = this.TextPadder(text);

            PdfFont fonta = new PdfTrueTypeFont("C:\\Users\\exter\\Desktop\\Praxátor\\Praxe-Exterernity\\Functioning\\arial\\arial.ttf", 30);
            var headerText = new PdfTextElement("Přihláška na praxi", fonta, new PdfSolidBrush(Color.FromArgb(1, 53, 67, 168)));
            PdfLayoutResult result = headerText.Draw(currentPage, new PointF(currentPage.Size.Width / 2 - 175, 2));


            this.Input(12, wrappedText, 20, 80,currentPage);
            this.Input(11, $"V Praze dne 1.9.2022", 20, 500,currentPage);
            this.Input(11, $"Ing.Martin Vodička", 400, 500, currentPage);
            this.Input(15, $"Jméno Studenta/ky: {studentName}", 20, 650, currentPage);
            this.Input(15, $"Příjmení Studenta/ky: {studentLastName}",20, 675,currentPage);
            this.Input(10, $"V".PadRight(40, '.') + "Dne".PadRight(40, '.'), 20, 750, currentPage);
            this.Input(10, $"Podpis zk. zástupce".PadRight(60, '.'), 325, 750, currentPage);
            
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            stream.Position = 0;
            return stream;
        }
        public void Input(int fontSize,string text,int positionX,int positionY,PdfPage currentPage)
        {
            PdfFont fonta = new PdfTrueTypeFont("C:\\Users\\exter\\Desktop\\Praxátor\\Praxe-Exterernity\\Functioning\\arial\\arial.ttf", fontSize);        
            var headerText = new PdfTextElement(text, fonta);
            var result = headerText.Draw(currentPage, new PointF(positionX, positionY));
        }

        public string TextPadder(string text)
        {
            int maxCharactersPerLine = 83;
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
            return sb.ToString();
        }
    }
}
