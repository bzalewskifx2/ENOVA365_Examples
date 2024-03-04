public void Wykonaj()
{
	/*WniosekUrlopowy w = null;

	using (Session session = Session.Login.CreateSession(false, false))
	{
		using (ITransaction trans = session.Logout(true))
		{	
			w = new WniosekUrlopowy(Pracownik, TypUrlopu);
			KadryModule.GetInstance(Pracownik).WnioskiUrlopowe.AddRow(w);
			w.Okres = OkresUrlopu;
			
			if(NaZadanie && TypUrlopu.Nazwa == "Urlop wypoczynkowy")
				w.PrzyczynaUrlopu = PrzyczynaUrlopu.NaŻądanie;
					
			if(PrzyczynaOkolicznosciowego != 0 && TypUrlopu.Nazwa == "Urlop okolicznościowy")
				w.UrlopOkolicznosciowy.PrzyczynaUrlopu = (PrzyczynaUrlopuOkolicznościowego)Fields[15];
					
			if(Dni == 1 && !Time.ZeroOrEmpty(CzasOd))
			{
				w.OdGodziny = CzasOd;
				w.DoGodziny = CzasDo;
			}
					
			w.Stan = StanWnioskuUrlopowego.Zaakceptowany;
					
			//WniosekUrlopowy = w;
			trans.Commit();
		}
		
	session.Save();
	session.Dispose();
	}*/

	//Fields[20, false] = w;
	
	using (Session session = Session.Login.CreateSession(false, false))
	{
		using (ITransaction trans = session.Logout(true))
		{	
			NieobecnośćPracownika np = new NieobecnośćPracownika(Pracownik);
			KalendModule.GetInstance(Pracownik).Nieobecnosci.AddRow(np);
			np.Definicja = TypUrlopu;
			np.Okres = OkresUrlopu;
					
			if(NaZadanie && np.Definicja.Nazwa == "Urlop wypoczynkowy")
				np.Urlop.Przyczyna = PrzyczynaUrlopu.NaŻądanie;
					
			if(PrzyczynaOkolicznosciowego != 0 && np.Definicja.Nazwa == "Urlop okolicznościowy")
				np.Okolicznosciowy.Przyczyna = (PrzyczynaUrlopuOkolicznościowego)Fields[15];
					
			if(Dni == 1 && !Time.ZeroOrEmpty(CzasOd))
			{
				np.OdGodziny = CzasOd;
				np.DoGodziny = CzasDo;
			}
					
			trans.Commit();
		}
		
		session.Save();
	}
}
