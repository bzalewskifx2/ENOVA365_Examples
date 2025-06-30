// zakładka kreatora wyświetlająca pole multireference + utworzenie domyślnego rekordu

public override View GetViewForListStep() 
{
		Soneta.Business.View widok = GetRow<Soneta.Core.DbTuples.DbTuple>().Relations.CreateView();
		widok.Condition &= new Soneta.Business.FieldCondition.Equal("Definicja.Name", "MPK");
	
		Soneta.Core.CoreModule cm = Module;
		var ff = Context[typeof(Soneta.Core.DbTuples.DbTupleFieldDefinition), false] as Soneta.Core.DbTuples.DbTupleFieldDefinition;
	
		if(ff == null || ff.Name != "MPK")
		{		
				var defs = cm.TuplesDefs.CreateView();
				
				foreach (Soneta.Core.DbTuples.DbTupleDefinition def in defs)
				{
						if (def.Symbol == "CUI_FZ")
						{
								var fields = def.Fields;
			
						    foreach(Soneta.Core.DbTuples.DbTupleFieldDefinition tfd in fields)
						    {
						        if(tfd.Name == "MPK")
						        {
												Context.Set(tfd);
										}
						    }
						}
				}
		}
		
		using (ITransaction trans = Context.Session.Logout(true))
		{
				var fieldDef = BusinessModule.GetInstance(Context.Session).RuntimeFieldDefs.WgDefinition.Where(d => d.Name == "MPK").FirstOrDefault();	
				var mpk = Row.Relations.Where(r => r.Definicja.Name == "MPK");
				Soneta.Core.DbTuples.DbTupleRel rel = mpk.Count() != 0 ? mpk.First() : null;
			
				if(rel == null)
				{
					  rel = new Soneta.Core.DbTuples.DbTupleRel(Row, (Soneta.Core.DbTuples.DbTupleFieldDefinition)fieldDef);			
						cm.TuplesRelations.AddRow(rel);
						rel.Features["MPK_Opis"] = Row.Fields["OpisKsiegowosc"].ToString();
						rel.Features["MPK_KwotaBrutto"] = (Currency)Row.Fields["Kwota"];
						rel.Features["MPK_Wymiar"] = "KOSZT";
				}
				else
						rel.Features["MPK_Opis"] = Row.Fields["OpisKsiegowosc"].ToString();
			
				trans.Commit();
		}
		
		return widok;
}

// multitask lista operatorów

public override IEnumerable<ITaskUser> GetTaskUsers() 
{
		// zadanie dla kierownika dzp, jeśli nieobecny - dla zastępcy
		List<ITaskUser> list = new List<ITaskUser>();
    Pracownik user = Soneta.Kadry.KadryModule.GetInstance(Session).Pracownicy.WgKodu.ToArray<Soneta.Kadry.Pracownik>().Where(p => p.Features["CUI_FZ_DZP"].Equals(true)).FirstOrDefault();
	
		if (user == null)
				throw new Exception("Brak wskazanego kierownika Działu Zamówień (CUI_FZ_DZP).");
	
    list.Add((ITaskUser)user);
	
    BusinessModule businessModule = BusinessModule.GetInstance(Session); 				
		View operatorzy = businessModule.Operators.CreateView();
			
		bool jestNieobecnosc = user.Nieobecnosci.Where(x => x.Okres.Contains(Date.Today)).Count() != 0;
		bool dzisNiePracuje = false;
		bool naglaNieobecnosc = (bool)user.Features["Nagła nieobecność"];
	
		KalendarzBase kalendarz = (KalendarzBase)user.Kalendarze.FirstOrDefault();
		DzienPlanu dzien = (DzienPlanu)Session.GetKalend().DniKalendarza.WgKalendarz[kalendarz].Where(dk => dk.Data == Date.Today).FirstOrDefault();
	
		if (dzien != null)
		{
				if (!dzien.Definicja.Nazwa.ToLower().StartsWith("prac"))
						dzisNiePracuje = true;
		}
	
		if (jestNieobecnosc || dzisNiePracuje || naglaNieobecnosc)			
		{							
				Soneta.Core.CoreModule cm = Soneta.Core.CoreModule.GetInstance(Session);
				View v = cm.SubstituteUsers.WgReplaced[user].CreateView();
				
				Soneta.Core.Substitute.SubstituteUser su = (Soneta.Core.Substitute.SubstituteUser)v.FirstOrDefault();

				if (su != null)
				{
						user = (Pracownik)su.Replacement;
						list.Add((ITaskUser)user);
				}											  		
				else
						throw new Exception("Operator wybranego zadania jest nieobecny i nie został wskazany zastępca.");
		}
	
		foreach (Operator o in operatorzy)
		{
				if ((Pracownik)o.Features["Pracownik"] == user)
						list.Add((ITaskUser)o);
		}
   
    return list;
}

// multitask kod tranzycji wchodzących do Decyzji - wybór operatora
public override bool IsRealized(Soneta.Business.Db.Task task) 
{
		var dalej =  task.WFWorkflow.SearchTasks(task).Where(x => x.WFTransition != null && x.WFTransition.Name == "Zwrot").Count()>0;
    return dalej;
}

// multitask kod tranzycji wychodzących z Decyzji - bezpośrednie przejście
public override bool IsRealized(Soneta.Business.Db.Task task) 
{
    var dalej = task.WFWorkflow.SearchPreviousTasks(task).All(t => t.Progress == TaskProgress.Realized)
		&& task.WFWorkflow.SearchPreviousTasks(task).Count(t => t.WFTransition != null && t.WFTransition.Name == "Ksiegowosc2") > 0;

    return dalej;   
}
