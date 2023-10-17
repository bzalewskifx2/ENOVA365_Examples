// *** aktualna PracHistoria *** //
Pracownik prac = Grid1.GetCurrentRow() as Pracownik;
Date aktualny = aktualny = ((ActualDate) dc.Context[typeof(ActualDate)]).Actual;
PracHistoria ph = prac[aktualny];
