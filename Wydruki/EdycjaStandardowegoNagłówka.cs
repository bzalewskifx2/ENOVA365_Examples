[DxBind] 
private readonly Soneta.Business.UI.DxReports.Controls.Header SzablonNagłówkaStrony;

[DxBind(Name="GroupHeader1")]
private void naglowek_BeforePrint(object sender, CancelEventArgs e) {
{
    Pracownik pracownik = null;
    PracHistoria historia = pracownik[Date.Today];
    
    string line1 = "Imię i nazwisko: ".Translate() + pracownik.ToString() + "\\b0," + " stanowisko pracy: ".Translate() + GetStanowisko(historia);
    string line2 = "Dział: ".Translate() + historia.Etat.Wydzial.ToString();
    string line3 = "przykładowy wiersz z danymi do nagłówka";
    SzablonNagłówkaStrony.FiltersDescription = new string[] { line1, line2, line3 };
}
