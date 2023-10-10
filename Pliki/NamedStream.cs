//*** zapis pliku ***//
[Context]
public Context context {  get; set; }

[Action(
    "Export do CSV",
    Priority = 1000,
    Icon = ActionIcon.ExcelPrint,
    Mode = ActionMode.Progress,
    Target = ActionTarget.Menu | ActionTarget.ToolbarWithText)]
public NamedStream SaveDataWorker()
{
    string filename = context.Login.Database.Name + "_" + Date.Today+".csv";
    var nowyPlik = new StreamWriter(new MemoryStream(), Encoding.UTF8);

    WriteCSV writeCsv = new WriteCSV();
    writeCsv.WriteHeader(nowyPlik);
    writeCsv.GetData(nowyPlik,context);
    nowyPlik.Flush();

    return new NamedStream(filename, ((System.IO.MemoryStream)nowyPlik.BaseStream).ToArray());
}

//*** odczyt pliku ***//
[Context, Required]
public NamedStream[] XMLFileName { get; set; }

[Context]
public Context Context { get; set; }

[Action(
    "Import faktur",
    Priority = 1000,
    Icon = ActionIcon.Open,
    Mode = ActionMode.Progress,
    Target = ActionTarget.Menu | ActionTarget.ToolbarWithText)]
public Object Fun()
{
    foreach (var xmlFName in XMLFileName)
    {
        // akcja
    }
}
