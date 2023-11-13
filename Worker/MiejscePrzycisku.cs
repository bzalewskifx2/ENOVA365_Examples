// *** tylko na liście *** // 
[assembly: Worker(typeof(BiocontrolKompletacja.KPLWorker), typeof(Dokhandlowe))]

[Action(
    "Sprawdź kompletację",
    Priority = 1010,
    Icon = ActionIcon.Accept,
    Mode = ActionMode.SingleSession,
    Target = ActionTarget.Menu | ActionTarget.ToolbarWithText)]

public object MyAction(){ }

// *** tylko w środku *** // 
[assembly: Worker(typeof(BiocontrolKompletacja.KPLWorker), typeof(DokumentHandlowy))]

[Action(
    "Sprawdź kompletację",
    Priority = 1010,
    Icon = ActionIcon.Accept,
    Mode = ActionMode.SingleSession | ActionMode.OnlyForm,
    Target = ActionTarget.Menu | ActionTarget.ToolbarWithText)]

public object MyAction(){ }

// *** na liście i w środku *** // 
[assembly: Worker(typeof(BiocontrolKompletacja.KPLWorker), typeof(DokumentHandlowy))]

[Action(
    "Sprawdź kompletację",
    Priority = 1010,
    Icon = ActionIcon.Accept,
    Mode = ActionMode.SingleSession,
    Target = ActionTarget.Menu | ActionTarget.ToolbarWithText)]

public object MyAction(){ }
