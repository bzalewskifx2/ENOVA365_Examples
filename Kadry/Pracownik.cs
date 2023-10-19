Pracownik p = null;

// staż pracy poza firmą
StazPracy sp = p.StażPracy(RodzajPodstawyStażuPracy.StazPracy);
// lata,miesiące,dni
throw new Exception(sp.Lata.ToString() + "," + sp.Miesiace.ToString() + "," + sp.Dni.ToString());

KalkulatorPracownika kalk = new KalkulatorPracownika(p);
// dni kalendarzowe
int dniKal = Pars.Okres.To - Pars.Okres.From + 1;
// dni robocze 
int dniRob = kalk.Norma(Pars.Okres).Dni;

