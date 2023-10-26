FromTo okres = new FromTo(BaseParams.YearMonth.FirstDay, BaseParams.YearMonth.LastDay);
Wyplata[] wyplaty = p.Wyplaty.Where(w => okres == w.ListaPlac.Okres).ToArray();

if (wyplaty.Count() == 0)
    throw new Exception("Nie znaleziono wynagrodzenia za wybrany miesiąc.");

Wyplata wyplata = wyplaty.First();
						
WyplataEtatWorker workerEtat = new WyplataEtatWorker
{
    Wypłata = (WyplataEtat)wyplata
};

double brutto = (double)workerEtat.Brutto;
double netto = (double)wyplata.DoWypłaty.Value;

// *** zaliczka na podatek *** //
double zaliczka = (double)workerEtat.Podatek;

WyplataSkładkiWorker workerSkladki = new WyplataSkładkiWorker
{
    Wypłata = wyplata,
};

WyplataSkładkiWorker.ZestawienieSkładek zestawienie = workerSkladki.Razem;

// *** składki społeczne *** //
double emerytalna = (double)zestawienie.Emerytalna.Prac;
double rentowa = (double)zestawienie.Rentowa.Prac;
double chorobowa = (double)zestawienie.Chorobowa.Prac;
double wypadkowa = (double)zestawienie.Wypadkowa.Prac;

// *** składka zdrowotna *** //
double zdrowotna = (double)zestawienie.Zdrowotna.Prac;

string format = "0.00";

bruttoLbl.Text = brutto.ToString(format);
emerytalnaLbl.Text = emerytalna.ToString(format);
rentowaLbl.Text = rentowa.ToString(format);
chorobowaLbl.Text = chorobowa.ToString(format);
zdrowotnaLbl.Text = zdrowotna.ToString(format);
zaliczkaLbl.Text = zaliczka.ToString(format);
nettoLbl.Text = netto.ToString(format);
