using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace PIRIHashesGenerator.units.pdf_templates
{
    public class WalletsDocument : IDocument
    {
        readonly string _date;
        readonly ListView _lw;
        public WalletsDocument(ListView _lw_)
        {
            _date = "Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture);
            _lw = _lw_;
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
                    column.Item().Text("PIRI Wallets").Style(titleStyle);
                    column.Item().Text(text =>
                    {
                        text.Span(_date).FontSize(12).ExtraBlack().FontFamily("Shippori Antique");
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
                    columns.ConstantColumn(270);
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("PIRI Wallets").FontFamily("Shippori Antique").ExtraBlack().FontSize(12);
                    header.Cell().Element(CellStyle).Text("Secret words").FontFamily("Shippori Antique").ExtraBlack().FontSize(12);

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.ExtraBlack()).PaddingVertical(2).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                foreach (ListViewItem item in _lw.Items)
                {
                    if (item.Checked)
                    {
                        table.Cell().ShowEntire().BorderRight(1).BorderColor(Colors.Grey.Lighten2).Element(CellStyle).Text(item.SubItems[1].Text).FontSize(8).FontFamily("Shippori Antique");
                        table.Cell().ShowEntire().Element(CellStyle).Text(item.SubItems[2].Text).FontSize(8).FontFamily("Shippori Antique");

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(1).PaddingLeft(5).PaddingRight(5);
                        }
                    }
                }
            });
        }
    }

}
