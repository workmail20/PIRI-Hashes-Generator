using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace PIRIHashesGenerator.units.pdf_templates
{
    public class PIRIWallet : IDocument
    {
        readonly string date_;
        readonly string balance_;
        readonly string wallet_;
        readonly string secret_;
        readonly string private_;
        readonly string pub_;

        public PIRIWallet(string _balance, string _wallet, string _secret, string _private, string _pub)
        {
            balance_ = _balance;
            wallet_ = _wallet;
            secret_ = _secret;
            private_ = _private;
            pub_ = _pub;
            date_ = "Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }

        public void Compose(IDocumentContainer container)
        {
            string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            if (workFolder != null) FontManager.RegisterFont(File.OpenRead(Path.Combine(workFolder, "fonts\\ShipporiAntique-Regular.ttf")));

            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().ShowOnce().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.DefaultTextStyle(x => x.FontFamily("Shippori Antique"));
                        x.CurrentPageNumber();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            var titleStyle = TextStyle.Default.FontSize(15).NormalWeight().FontColor(Colors.Blue.Medium).FontFamily("Shippori Antique");

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("PIRI Wallet").Style(titleStyle);
                    column.Item().Text(text =>
                    {
                        text.Span(date_).FontSize(12).ExtraBlack().FontFamily("Shippori Antique");
                    });
                });

                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (workFolder != null) row.ConstantItem(150).Height(50).Image(Path.Combine(workFolder, "resources\\piri_PNG.png"));
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(20).Column(column =>
            {
                column.Spacing(1);
                column.Item().Element(ComposeTable);
            });
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(120);
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("PIRI Info").FontFamily("Shippori Antique").ExtraBlack().FontSize(12);
                    header.Cell().Element(CellStyle).Text("Value").FontFamily("Shippori Antique").ExtraBlack().FontSize(12);

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.ExtraBlack()).PaddingVertical(2).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                table.Cell().ShowEntire().BorderRight(1).BorderColor(Colors.Grey.Lighten2).Element(CellStyle).Text("PIRI Wallet ID").FontSize(8).FontFamily("Shippori Antique");
                table.Cell().ShowEntire().Element(CellStyle).Text(wallet_).FontSize(8).FontFamily("Shippori Antique");

                table.Cell().ShowEntire().BorderRight(1).BorderColor(Colors.Grey.Lighten2).Element(CellStyle).Text("Secret words").FontSize(8).FontFamily("Shippori Antique");
                table.Cell().ShowEntire().Element(CellStyle).Text(secret_).FontSize(8).FontFamily("Shippori Antique");

                table.Cell().ShowEntire().BorderRight(1).BorderColor(Colors.Grey.Lighten2).Element(CellStyle).Text("Private key").FontSize(8).FontFamily("Shippori Antique");
                table.Cell().ShowEntire().Element(CellStyle).Text(private_).FontSize(8).FontFamily("Shippori Antique");

                table.Cell().ShowEntire().BorderRight(1).BorderColor(Colors.Grey.Lighten2).Element(CellStyle).Text("Public key").FontSize(8).FontFamily("Shippori Antique");
                table.Cell().ShowEntire().Element(CellStyle).Text(pub_).FontSize(8).FontFamily("Shippori Antique");

                table.Cell().ShowEntire().BorderRight(1).BorderColor(Colors.Grey.Lighten2).Element(CellStyle).Text("Balance").FontSize(8).FontFamily("Shippori Antique");
                table.Cell().ShowEntire().Element(CellStyle).Text(balance_).FontSize(8).FontFamily("Shippori Antique");

                static IContainer CellStyle(IContainer container)
                {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(1).PaddingLeft(5).PaddingRight(5);
                }
            });
        }
    }

}
