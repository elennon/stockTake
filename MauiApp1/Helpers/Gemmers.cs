using GemBox.Spreadsheet;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MauiApp1.Helpers
{
    public class Gemmers
    {
        private string AppFolder => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public string GetGemmer(StockTake ixtris)
        {
            try
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

                var fileName = $"feet.xlsx";
                Environment.SetEnvironmentVariable("MONO_URI_DOTNETRELATIVEORABSOLUTE", "true");
                var filePath = Path.Combine(AppFolder, fileName);
                var workbook = new ExcelFile();

                CreateWorkSheet(ixtris, "van stock take", workbook);
                workbook.Save(filePath);
                return filePath;
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void CreateWorkSheet(StockTake ixtris, string sheetName, ExcelFile workbook)
        {

            List<string> headers = new List<string>();
            headers.Add("Barecode scans");
            ixtris.items.ForEach(x => headers.Add(x.ItemName));

            var worksheet = workbook.Worksheets.Add(sheetName);


            // Write title to Excel cell.
            var range = worksheet.Cells.GetSubrange("A1:G1");
            range.Merged = true;

            range.Value = " - Dayworks";
            range.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            //range.Style.Font.Size = 20;
            worksheet.Cells["A1"].Style.FillPattern.SetPattern(FillPatternStyle.Solid, SpreadsheetColor.FromName(ColorName.Accent5Lighter60Pct),
                SpreadsheetColor.FromName(ColorName.Accent5Lighter60Pct));
            worksheet.Rows["1"].Style = workbook.Styles[BuiltInCellStyleName.Heading1];

            //// Set columns width.
            worksheet.Columns["A"].SetWidth(20, LengthUnit.ZeroCharacterWidth);
            worksheet.Columns["B"].SetWidth(20, LengthUnit.ZeroCharacterWidth);
            worksheet.Columns["C"].SetWidth(20, LengthUnit.ZeroCharacterWidth);
            worksheet.Columns["D"].SetWidth(20, LengthUnit.ZeroCharacterWidth);
            worksheet.Columns["E"].SetWidth(20, LengthUnit.ZeroCharacterWidth);
            worksheet.Columns["F"].SetWidth(20, LengthUnit.ZeroCharacterWidth);
            worksheet.Columns["G"].SetWidth(20, LengthUnit.ZeroCharacterWidth);

            // Write header data to Excel cells.
            //for (int col = 0; col < skyscrapers.GetLength(1); col++)
            //    worksheet.Cells[3, col].Value = skyscrapers[0, col];
            for (int col = 0; col < headers.Count(); col++)
                worksheet.Cells[2, col].Value = headers[col];

            // Set header cells formatting.
            var style = new CellStyle();
            style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            style.VerticalAlignment = VerticalAlignmentStyle.Center;
            style.FillPattern.SetPattern(FillPatternStyle.Solid, SpreadsheetColor.FromName(ColorName.Accent2Lighter60Pct),
                SpreadsheetColor.FromName(ColorName.Accent2Lighter60Pct));
            style.Font.Weight = ExcelFont.BoldWeight;
            style.Font.Color = SpreadsheetColor.FromName(ColorName.Black);
            style.WrapText = true;
            style.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);
            worksheet.Cells.GetSubrange("A3:O3").Style = style;
            var row = 3;
            var coll = 0;
            foreach(var bk in ixtris.barecodeNumber)
            {
                var cell = worksheet.Cells[row, coll];
                cell.Value = bk;
                cell.Style.Borders[IndividualBorder.Right].LineStyle = LineStyle.Thin;
                cell.Style.Borders[IndividualBorder.Left].LineStyle = LineStyle.Thin;
                cell.Style.Borders[IndividualBorder.Top].LineStyle = LineStyle.Thin;
                cell.Style.Borders[IndividualBorder.Bottom].LineStyle = LineStyle.Thin;
                cell.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                row++;
            }
            coll ++;
            foreach (var extr in ixtris.items)
            {               
                var cell = worksheet.Cells[3, coll];
                cell.Value = extr.ItemNumber;
                cell.Style.Borders[IndividualBorder.Right].LineStyle = LineStyle.Thin;
                cell.Style.Borders[IndividualBorder.Left].LineStyle = LineStyle.Thin;
                cell.Style.Borders[IndividualBorder.Top].LineStyle = LineStyle.Thin;
                cell.Style.Borders[IndividualBorder.Bottom].LineStyle = LineStyle.Thin;
                cell.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                coll++;
            }
           
            worksheet.PrintOptions.FitWorksheetWidthToPages = 1;
        }

    }
}

