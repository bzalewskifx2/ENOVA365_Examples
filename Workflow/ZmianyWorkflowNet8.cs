///2406


//Usunięcie metod oznaczonych jako Obsolete
//Poniższe metody i parametry, oznaczone we wcześniejszych wersjach enova365 jako przestarzałe (Obsolete) zostały usunięte w wersji 2406:

//Klasa WizardStepListSelectionInfo:

public static WizardStepListSelectionInfo Create(object[] selected) została zastąpiona przez Create(Context.Empty, selected, null).
public static WizardStepListSelectionInfo Create(object[] selected, object focused) została zastąpiona przez Create(Context.Empty, selected, focused, "").
public object[] Selected został zastąpiony przez metodę GetSelected(Guid stepGuid, string gridId).
public object Focused został zastąpiony przez metodę GetFocused(Guid stepGuid, string gridId).
