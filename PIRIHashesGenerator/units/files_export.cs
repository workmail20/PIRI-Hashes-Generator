using ClosedXML.Excel;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using PIRIHashesGenerator.units.pdf_templates;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Globalization;
using System.Text;

namespace PIRIHashesGenerator.units
{
    public static class Files_export
    {
        public static void Piriwallets_saveXLSX(ListView _in, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var workbook = new XLWorkbook(Path.Combine(workFolder, "resources\\template.xlsx"));
                    var worksheet = workbook.Worksheet(1);
                    worksheet.Cell(1, 2).Value = "Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture);

                    string wallet = "";
                    string _private = "";

                    List<ListViewItem> reversed = new();
                    foreach (ListViewItem itemRow in _in.Items)
                    {
                        reversed.Insert(0, itemRow);
                    }


                    foreach (ListViewItem itemRow in reversed)
                    {
                        if (itemRow.Checked == true)
                        {
                            wallet = itemRow.SubItems[1].Text;
                            _private = itemRow.SubItems[2].Text;
                            worksheet.Row(3).InsertRowsBelow(1);
                            worksheet.Row(3).CopyTo(worksheet.Row(4));
                            worksheet.Cell(3, 1).Value = wallet;
                            worksheet.Cell(3, 2).Value = _private;
                            worksheet.Row(3).AdjustToContents();
                            worksheet.Row(3).ClearHeight();
                        }
                    }
                    workbook.SaveAs(_file);
                }
            }
            catch (Exception)
            {

            }
        }
        public static void Piriwallets_saveDOCX(ListView _in, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var file = new FileStream(Path.Combine(workFolder, "resources\\template.docx"), FileMode.Open, FileAccess.Read);
                    XWPFDocument doc = new(file);

                    var t = doc.GetTablesEnumerator();
                    t.MoveNext();

                    XWPFTableCell _c = t.Current.GetRow(0).GetCell(1);

                    XWPFParagraph p1 = _c.Paragraphs[0];
                    p1.Alignment = ParagraphAlignment.RIGHT;
                    XWPFRun r1 = p1.CreateRun();
                    r1.SetText("Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));
                    r1.FontSize = 12;
                    r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                    r1.IsBold = true;

                    t.MoveNext();

                    string wallet = "";
                    string _private = "";

                    List<ListViewItem> reversed = new();
                    foreach (ListViewItem itemRow in _in.Items)
                    {
                        reversed.Insert(0, itemRow);
                    }

                    foreach (ListViewItem itemRow in reversed)
                    {

                        if (itemRow.Checked == true)
                        {
                            wallet = itemRow.SubItems[1].Text;
                            _private = itemRow.SubItems[2].Text;

                            t = doc.GetTablesEnumerator();
                            t.MoveNext();
                            t.MoveNext();

                            var tc = t.Current.GetRow(1).GetCTRow().Copy();

                            XWPFTableRow copiedRow = new(tc, t.Current);
                            t.Current.AddRow(copiedRow, 1);

                            t = doc.GetTablesEnumerator();
                            t.MoveNext();
                            t.MoveNext();

                            _c = t.Current.GetRow(2).GetCell(0);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.LEFT;
                            r1 = p1.CreateRun();
                            r1.SetText(wallet);
                            r1.FontSize = 10;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;

                            _c = t.Current.GetRow(2).GetCell(1);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.LEFT;
                            r1 = p1.CreateRun();
                            r1.SetText(_private);
                            r1.FontSize = 10;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;
                        }

                    }
                    t.Current.RemoveRow(1);

                    using FileStream fs = new(_file, FileMode.Create);
                    doc.Write(fs);
                }
            }
            catch (Exception)
            {

            }
        }


        public static void Piriwallets_savePDF(ListView _in, string _file)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;
                var document = new WalletsDocument(_in);
                document.GeneratePdf(_file);
            }
            catch (Exception)
            {

            }
        }

        public static void Piriwallets_saveCSV(ListView _in, string _file)
        {
            try
            {
                string html = "sep=,\r\nPIRI Wallet,Secret words\r\n";

                string wallet = "";
                string _private = "";

                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {
                    if (itemRow.Checked == true)
                    {
                        off++;
                        wallet = itemRow.SubItems[1].Text;
                        _private = itemRow.SubItems[2].Text;
                        html += wallet + "," + _private + "\r\n";
                    }

                }
                var htmlbytes = Encoding.UTF8.GetBytes(html);
                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void Piriwallets_saveTXT(ListView _in, string _file)
        {
            try
            {
                string html = "";
                string wallet = "";
                string _private = "";

                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {
                    if (itemRow.Checked == true)
                    {
                        off++;
                        wallet = itemRow.SubItems[1].Text;
                        _private = itemRow.SubItems[2].Text;
                        html += wallet + "\t" + _private + "\r\n";
                    }

                }
                var htmlbytes = Encoding.UTF8.GetBytes(html);
                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void Piriwallets_saveHTML(ListView _in, string _file)
        {
            try
            {
                string html = Resources2.gen_piriwallets;
                html = html.Replace("{time}", DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));

                string items = "";

                string wallet = "";
                string _private = "";

                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {
                    if (itemRow.Checked == true)
                    {
                        off++;
                        wallet = itemRow.SubItems[1].Text;
                        _private = itemRow.SubItems[2].Text;
                        items += "<tr class=\"item\">\r\n\t\t\t\t\t<td>" + wallet + "</td>\r\n\r\n\t\t\t\t\t<td>" + _private + "</td>\r\n\t\t\t\t</tr>\r\n";
                    }
                }

                html = html.Replace("{items}", items);
                var htmlbytes = Encoding.UTF8.GetBytes(html);

                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception) { }
        }

        ////wallets
        public static void PiriwalletDATA_saveXLSX(string _balance, string _wallet, string _secret, string _private, string _pub, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var workbook = new XLWorkbook(Path.Combine(workFolder, "resources\\template_walletDATA.xlsx"));
                    var worksheet = workbook.Worksheet(1);
                    worksheet.Cell(1, 2).Value = "Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture);

                    worksheet.Row(3).InsertRowsBelow(1);
                    worksheet.Row(3).CopyTo(worksheet.Row(4));
                    worksheet.Cell(3, 1).Value = "Balance";
                    worksheet.Cell(3, 2).Value = _balance + " PIRI";
                    worksheet.Row(3).AdjustToContents();
                    worksheet.Row(3).ClearHeight();

                    worksheet.Row(3).InsertRowsBelow(1);
                    worksheet.Row(3).CopyTo(worksheet.Row(4));
                    worksheet.Cell(3, 1).Value = "Public key";
                    worksheet.Cell(3, 2).Value = _pub;
                    worksheet.Row(3).AdjustToContents();
                    worksheet.Row(3).ClearHeight();

                    worksheet.Row(3).InsertRowsBelow(1);
                    worksheet.Row(3).CopyTo(worksheet.Row(4));
                    worksheet.Cell(3, 1).Value = "Private key";
                    worksheet.Cell(3, 2).Value = _private;
                    worksheet.Row(3).AdjustToContents();
                    worksheet.Row(3).ClearHeight();

                    worksheet.Row(3).InsertRowsBelow(1);
                    worksheet.Row(3).CopyTo(worksheet.Row(4));
                    worksheet.Cell(3, 1).Value = "Secret words";
                    worksheet.Cell(3, 2).Value = _secret;
                    worksheet.Row(3).AdjustToContents();
                    worksheet.Row(3).ClearHeight();

                    worksheet.Row(3).InsertRowsBelow(1);
                    worksheet.Row(3).CopyTo(worksheet.Row(4));
                    worksheet.Cell(3, 1).Value = "PIRI Wallet ID";
                    worksheet.Cell(3, 2).Value = _wallet;
                    worksheet.Row(3).AdjustToContents();
                    worksheet.Row(3).ClearHeight();

                    workbook.SaveAs(_file);
                }
            }
            catch (Exception)
            {

            }

        }


        public static void PiriwalletDATA_saveDOCX(string _balance, string _wallet, string _secret, string _private, string _pub, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var file = new FileStream(Path.Combine(workFolder, "resources\\template_walletDATA.docx"), FileMode.Open, FileAccess.Read);
                    XWPFDocument doc = new(file);

                    var t = doc.GetTablesEnumerator();
                    t.MoveNext();

                    XWPFTableCell _c = t.Current.GetRow(0).GetCell(1);
                    XWPFParagraph p1 = _c.Paragraphs[0];
                    p1.Alignment = ParagraphAlignment.RIGHT;

                    XWPFRun r1 = p1.CreateRun();
                    r1.SetText("Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));
                    r1.FontSize = 12;
                    r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                    r1.IsBold = true;

                    t.MoveNext();

                    var _w = (string k1, string k2) =>
                    {
                        t.Current.InsertNewTableRow(1);
                        t = doc.GetTablesEnumerator();
                        t.MoveNext();

                        t.MoveNext();

                        t.Current.GetRow(1).CreateCell();
                        t.Current.GetRow(1).CreateCell();

                        _c = t.Current.GetRow(1).GetCell(0);

                        p1 = _c.Paragraphs[0];
                        p1.Alignment = ParagraphAlignment.LEFT;
                        r1 = p1.CreateRun();
                        r1.SetText(k1);
                        r1.FontSize = 10;
                        r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                        r1.IsBold = false;

                        _c = t.Current.GetRow(1).GetCell(1);

                        p1 = _c.Paragraphs[0];
                        p1.Alignment = ParagraphAlignment.LEFT;
                        r1 = p1.CreateRun();
                        r1.SetText(k2);
                        r1.FontSize = 10;
                        r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                        r1.IsBold = false;
                    };

                    _w("Balance", _balance + " PIRI");
                    _w("Public key", _pub);
                    _w("Private key", _private);
                    _w("Secret words", _secret);
                    _w("PIRI ID", _wallet);


                    t = doc.GetTablesEnumerator();
                    t.MoveNext();
                    t.MoveNext();

                    var tblLayout1 = t.Current.GetCTTbl().tblPr.AddNewTblLayout();
                    tblLayout1.type = ST_TblLayoutType.@fixed;

                    using FileStream fs = new(_file, FileMode.Create);
                    doc.Write(fs);
                }
            }
            catch (Exception)
            {

            }
        }


        public static void PiriwalletDATA_savePDF(string _balance, string _wallet, string _secret, string _private, string _pub, string _file)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;
                var document = new PIRIWallet(_balance, _wallet, _secret, _private, _pub);
                document.GeneratePdf(_file);
            }
            catch (Exception)
            {

            }
        }

        public static void PiriwalletDATA_saveCSV(string _balance, string _wallet, string _secret, string _private, string _pub, string _file)
        {
            try
            {
                string html = "sep=,\r\nPIRI Wallet,Secret words,Private key,Public key,Balance\r\n";

                html += _wallet + "," + _secret + "," + _private + "," + _pub + "," + _balance + " PIRI" + "\r\n";

                var htmlbytes = Encoding.UTF8.GetBytes(html);

                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void PiriwalletDATA_saveTXT(string _balance, string _wallet, string _secret, string _private, string _pub, string _file)
        {
            try
            {
                string html = _wallet + "\t" + _secret + "\t" + _private + "\t" + _pub + "\t" + _balance + " PIRI" + "\r\n";

                var htmlbytes = Encoding.UTF8.GetBytes(html);

                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void PiriwalletDATA_saveHTML(string _balance, string _wallet, string _secret, string _private, string _pub, string _file)
        {
            try
            {
                string html = Resources2.piriwallet;

                html = html.Replace("{time}", DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));

                string items = "";

                items += "<tr class=\"item\">\r\n\t\t\t\t\t<td>PIRI Wallet ID</td>\r\n\r\n\t\t\t\t\t<td>" + _wallet + "</td>\r\n\t\t\t\t</tr>\r\n";
                items += "<tr class=\"item\">\r\n\t\t\t\t\t<td>Secret words</td>\r\n\r\n\t\t\t\t\t<td>" + _secret + "</td>\r\n\t\t\t\t</tr>\r\n";
                items += "<tr class=\"item\">\r\n\t\t\t\t\t<td>Private key</td>\r\n\r\n\t\t\t\t\t<td>" + _private + "</td>\r\n\t\t\t\t</tr>\r\n";
                items += "<tr class=\"item\">\r\n\t\t\t\t\t<td>Public key</td>\r\n\r\n\t\t\t\t\t<td style=\"word-wrap: anywhere;\">" + _pub + "</td>\r\n\t\t\t\t</tr>\r\n";
                items += "<tr class=\"item\">\r\n\t\t\t\t\t<td>Balance</td>\r\n\r\n\t\t\t\t\t<td>" + _balance + " PIRI</td>\r\n\t\t\t\t</tr>\r\n";
                html = html.Replace("{items}", items);
                var htmlbytes = Encoding.UTF8.GetBytes(html);


                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception) { }
        }



        public static void PiriTransactions_saveXLSX(ListView _in, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var workbook = new XLWorkbook(Path.Combine(workFolder, "resources\\template_transactions.xlsx"));
                    var worksheet = workbook.Worksheet(1);
                    worksheet.Cell(1, 3).Value = "Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture);

                    List<ListViewItem> reversed = new();
                    foreach (ListViewItem itemRow in _in.Items)
                    {
                        reversed.Insert(0, itemRow);
                    }

                    foreach (ListViewItem itemRow in reversed)
                    {
                        if (itemRow.Checked == true)
                        {
                            worksheet.Row(3).InsertRowsBelow(1);
                            worksheet.Row(3).CopyTo(worksheet.Row(4));

                            worksheet.Cell(3, 1).Value = itemRow.SubItems[1].Text;

                            worksheet.Cell(3, 2).Value = itemRow.SubItems[2].Text;
                            worksheet.Cell(3, 3).Value = itemRow.SubItems[3].Text;
                            worksheet.Cell(3, 4).Value = itemRow.SubItems[4].Text;
                            worksheet.Cell(3, 5).Value = itemRow.SubItems[5].Text;
                            worksheet.Cell(3, 6).Value = itemRow.SubItems[6].Text;
                            worksheet.Row(3).AdjustToContents();
                            worksheet.Row(3).ClearHeight();
                        }

                    }

                    workbook.SaveAs(_file);
                }
            }
            catch (Exception)
            {

            }
        }

        public static void PiriTransactions_saveDOCX(ListView _in, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var file = new FileStream(Path.Combine(workFolder, "resources\\template_transactions.docx"), FileMode.Open, FileAccess.Read);

                    XWPFDocument doc = new(file);
                    var t = doc.GetTablesEnumerator();
                    t.MoveNext();

                    XWPFTableCell _c = t.Current.GetRow(0).GetCell(1);
                    XWPFParagraph p1 = _c.Paragraphs[0];
                    p1.Alignment = ParagraphAlignment.RIGHT;

                    XWPFRun r1 = p1.CreateRun();
                    r1.SetText("Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));
                    r1.FontSize = 12;
                    r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                    r1.IsBold = true;

                    t.MoveNext();

                    List<ListViewItem> reversed = new();
                    foreach (ListViewItem itemRow in _in.Items)
                    {
                        reversed.Insert(0, itemRow);
                    }

                    foreach (ListViewItem itemRow in reversed)
                    {
                        if (itemRow.Checked == true)
                        {
                            t = doc.GetTablesEnumerator();
                            t.MoveNext();
                            t.MoveNext();

                            var tc = t.Current.GetRow(1).GetCTRow().Copy();
                            XWPFTableRow copiedRow = new(tc, t.Current);
                            t.Current.AddRow(copiedRow, 1);

                            t = doc.GetTablesEnumerator();
                            t.MoveNext();
                            t.MoveNext();

                            _c = t.Current.GetRow(2).GetCell(0);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.LEFT;
                            r1 = p1.CreateRun();
                            r1.FontSize = 8;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;
                            r1.SetText("Tx hash: " + itemRow.SubItems[2].Text);


                            p1 = _c.AddParagraph();
                            p1.Alignment = ParagraphAlignment.LEFT;
                            r1 = p1.CreateRun();
                            r1.FontSize = 8;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;
                            r1.SetText("From: " + itemRow.SubItems[3].Text);

                            if (itemRow.SubItems[4].Text.Length > 0)
                            {
                                p1 = _c.AddParagraph();
                                p1.Alignment = ParagraphAlignment.LEFT;
                                r1 = p1.CreateRun();
                                r1.FontSize = 8;
                                r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                                r1.IsBold = false;
                                r1.SetText("To: " + itemRow.SubItems[4].Text);
                            }


                            _c = t.Current.GetRow(2).GetCell(1);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.RIGHT;
                            r1 = p1.CreateRun();
                            r1.SetText(itemRow.SubItems[5].Text);
                            r1.FontSize = 8;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;


                            _c = t.Current.GetRow(2).GetCell(2);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.CENTER;
                            r1 = p1.CreateRun();
                            r1.SetText("[" + itemRow.SubItems[1].Text + "] " + itemRow.SubItems[6].Text);
                            r1.FontSize = 8;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;
                        }

                    }
                    t.Current.RemoveRow(1);

                    using FileStream fs = new(_file, FileMode.Create);
                    doc.Write(fs);
                }
            }
            catch (Exception)
            {

            }
        }


        public static void PiriTransactions_savePDF(ListView _in, string _file)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;
                var document = new TransactionsDocument(_in);

                document.GeneratePdf(_file);
            }
            catch (Exception)
            {

            }
        }

        public static void PiriTransactions_saveCSV(ListView _in, string _file)
        {
            try
            {
                string html = "sep=,\r\nTransactions Hash,From,To,Amount,Type\r\n";

                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {
                    if (itemRow.Checked == true)
                    {
                        off++;
                        html += itemRow.SubItems[2].Text + "," + itemRow.SubItems[3].Text + "," + itemRow.SubItems[4].Text + "," + itemRow.SubItems[5].Text + ",[" + itemRow.SubItems[1].Text + "] " + itemRow.SubItems[6].Text + "\r\n";
                    }

                }
                var htmlbytes = Encoding.UTF8.GetBytes(html);


                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void PiriTransactions_saveTXT(ListView _in, string _file)
        {
            try
            {
                string html = "";
                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {
                    if (itemRow.Checked == true)
                    {
                        off++;
                        html += itemRow.SubItems[1].Text + "\t" + itemRow.SubItems[2].Text + "\t" + itemRow.SubItems[3].Text + "\t" + itemRow.SubItems[4].Text + "\t" + itemRow.SubItems[5].Text + "\t" + itemRow.SubItems[6].Text + "\r\n";
                    }
                }
                var htmlbytes = Encoding.UTF8.GetBytes(html);

                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void PiriTransactions_saveHTML(ListView _in, string _file)
        {
            try
            {
                string html = Resources2.piritransactions;
                html = html.Replace("{time}", DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));

                string items = "";
                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {
                    if (itemRow.Checked == true)
                    {
                        off++;
                        items += "<tr class=\"item\">\r\n\t\t\t\t\t<td class=\"c1\">Tx hash: " + itemRow.SubItems[2].Text + "<br>From: " + itemRow.SubItems[3].Text + "<br>To: " + itemRow.SubItems[4].Text + "</td>\r\n\r\n\t\t\t\t\t<td  class=\"c2\">" + itemRow.SubItems[5].Text + "</td>\r\n\t\t\t\t<td class=\"c3\">[" + itemRow.SubItems[1].Text + "] " + itemRow.SubItems[6].Text + "</td></tr>\r\n";
                    }

                }

                html = html.Replace("{items}", items);
                var htmlbytes = Encoding.UTF8.GetBytes(html);

                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception) { }
        }

        public static void PiriData_saveXLSX(ListView _in, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var workbook = new XLWorkbook(Path.Combine(workFolder, "resources\\template_DATA.xlsx"));
                    var worksheet = workbook.Worksheet(1);
                    worksheet.Cell(1, 2).Value = "Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture);


                    List<ListViewItem> reversed = new();
                    foreach (ListViewItem itemRow in _in.Items)
                    {
                        reversed.Insert(0, itemRow);
                    }

                    foreach (ListViewItem itemRow in reversed)
                    {

                        if (itemRow.Checked == true)
                        {
                            worksheet.Row(3).InsertRowsBelow(1);
                            worksheet.Row(3).CopyTo(worksheet.Row(4));
                            worksheet.Cell(3, 1).Value = itemRow.SubItems[2].Text;

                            worksheet.Cell(3, 2).Value = itemRow.SubItems[4].Text;
                            worksheet.Cell(3, 3).Value = itemRow.SubItems[5].Text;
                            worksheet.Row(3).AdjustToContents();
                            worksheet.Row(3).ClearHeight();
                        }
                    }
                    workbook.SaveAs(_file);
                }
            }
            catch (Exception)
            {

            }

        }

        public static void PiriData_saveDOCX(ListView _in, string _file)
        {
            try
            {
                string? workFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                if (!string.IsNullOrEmpty(workFolder))
                {
                    using var file = new FileStream(Path.Combine(workFolder, "resources\\template_DATA.docx"), FileMode.Open, FileAccess.Read);

                    XWPFDocument doc = new(file);

                    var t = doc.GetTablesEnumerator();
                    t.MoveNext();

                    XWPFTableCell _c = t.Current.GetRow(0).GetCell(1);

                    XWPFParagraph p1 = _c.Paragraphs[0];
                    p1.Alignment = ParagraphAlignment.RIGHT;

                    XWPFRun r1 = p1.CreateRun();
                    r1.SetText("Created: " + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));
                    r1.FontSize = 12;
                    r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                    r1.IsBold = true;

                    t.MoveNext();


                    List<ListViewItem> reversed = new();
                    foreach (ListViewItem itemRow in _in.Items)
                    {
                        reversed.Insert(0, itemRow);
                    }

                    foreach (ListViewItem itemRow in reversed)
                    {

                        if (itemRow.Checked == true)
                        {

                            t = doc.GetTablesEnumerator();
                            t.MoveNext();
                            t.MoveNext();

                            var tc = t.Current.GetRow(1).GetCTRow().Copy();

                            XWPFTableRow copiedRow = new(tc, t.Current);
                            t.Current.AddRow(copiedRow, 1);

                            t = doc.GetTablesEnumerator();
                            t.MoveNext();
                            t.MoveNext();

                            _c = t.Current.GetRow(2).GetCell(0);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.LEFT;
                            r1 = p1.CreateRun();
                            r1.SetText(itemRow.SubItems[2].Text);
                            r1.FontSize = 10;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;

                            _c = t.Current.GetRow(2).GetCell(1);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.LEFT;
                            r1 = p1.CreateRun();
                            r1.SetText(itemRow.SubItems[4].Text);
                            r1.FontSize = 10;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;

                            _c = t.Current.GetRow(2).GetCell(2);

                            p1 = _c.Paragraphs[0];
                            p1.Alignment = ParagraphAlignment.LEFT;
                            r1 = p1.CreateRun();
                            r1.SetText(itemRow.SubItems[5].Text);
                            r1.FontSize = 10;
                            r1.SetFontFamily("Shippori Antique", FontCharRange.None);
                            r1.IsBold = false;
                        }

                    }
                    t.Current.RemoveRow(1);

                    using FileStream fs = new(_file, FileMode.Create);
                    doc.Write(fs);
                }
            }
            catch (Exception)
            {

            }
        }


        public static void PiriData_savePDF(ListView _in, string _file)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;
                var document = new DBDocument(_in);

                document.GeneratePdf(_file);
            }
            catch (Exception)
            {

            }
        }

        public static void PiriData_saveCSV(ListView _in, string _file)
        {
            try
            {
                string html = "sep=,\r\nFrom,Key,Value\r\n";

                int off = 0;

                foreach (ListViewItem itemRow in _in.Items)
                {

                    if (itemRow.Checked == true)
                    {
                        off++;
                        html += itemRow.SubItems[2].Text + "," + itemRow.SubItems[4].Text + "," + itemRow.SubItems[5].Text + "\r\n";
                    }

                }
                var htmlbytes = Encoding.UTF8.GetBytes(html);

                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void PiriData_saveTXT(ListView _in, string _file)
        {
            try
            {
                string html = "";

                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {

                    if (itemRow.Checked == true)
                    {
                        off++;
                        html += itemRow.SubItems[2].Text + "\t" + itemRow.SubItems[4].Text + "\t" + itemRow.SubItems[5].Text + "\r\n";
                    }

                }
                var htmlbytes = Encoding.UTF8.GetBytes(html);
                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void PiriData_saveHTML(ListView _in, string _file)
        {
            try
            {
                string html = Resources2.piriwalletDATA;
                html = html.Replace("{time}", DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss.fff", CultureInfo.InvariantCulture));

                string items = "";

                int off = 0;
                foreach (ListViewItem itemRow in _in.Items)
                {
                    if (itemRow.Checked == true)
                    {
                        off++;
                        items += "<tr class=\"item\">\r\n\t\t\t\t\t<td class=\"c1\">" + itemRow.SubItems[2].Text + "</td>\r\n\r\n\t\t\t\t\t<td  class=\"c2\" >" + itemRow.SubItems[4].Text + "</td>\r\n\t\t\t\t<td  class=\"c3\" >" + itemRow.SubItems[5].Text + "</td></tr>\r\n";

                    }

                }

                html = html.Replace("{items}", items);
                var htmlbytes = Encoding.UTF8.GetBytes(html);

                File.Delete(_file);
                FileStream fs = new(_file, FileMode.CreateNew);
                fs.Write(htmlbytes, 0, htmlbytes.Length);
                fs.Close();
            }
            catch (Exception) { }
        }
    }
}
