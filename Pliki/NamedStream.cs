//*** zapis pliku ***//
[Context]
public Context Context {  get; set; }

[Action(
    "Export do CSV",
    Priority = 1000,
    Icon = ActionIcon.ExcelPrint,
    Mode = ActionMode.Progress,
    Target = ActionTarget.Menu | ActionTarget.ToolbarWithText)]
public NamedStream SaveDataWorker()
{
    string filename = Context.Login.Database.Name + "_" + Date.Today + ".csv";
    var nowyPlik = new StreamWriter(new MemoryStream(), Encoding.UTF8);
    return new NamedStream(filename, ((MemoryStream)nowyPlik.BaseStream).ToArray());
}

//*** odczyt pliku ***//
[Context, Required]
public NamedStream[] NamedStreams { get; set; }

[Context]
public Context Context { get; set; }

[Action(
    "Action",
    Priority = 1000,
    Icon = ActionIcon.Open,
    Mode = ActionMode.Progress,
    Target = ActionTarget.Menu | ActionTarget.ToolbarWithText)]
public void MyAction()
{
    foreach (var namedStream in NamedStreams)
    {
        FileInfo fileInfo = new FileInfo(namedStream.FileName);
    }
}
