private byte[] StworzExcel(List<string[]> rows)
{
    using (var wb = new XLWorkbook())
    {
        var ws = wb.Worksheets.Add("Zamówienie do dostawcy");
        var bytes = new byte[0];

        using (var ms = new MemoryStream())
        {
            wb.SaveAs(ms);
            bytes = ms.ToArray();
        }

        return bytes;
    }
}
