protected internal void WylogujWszystkichZalogowanych(Operacja o, Soneta.Types.Date data, Soneta.Types.TimeSec czas)
    {
      if (o == null)
        return;
      List<int> intList = OperacjaRejestracjaPracWorkerBase.DajListeIdZalogowanychOperatorow(o, -1);
      if (intList.Count == 0)
        return;
      using (ITransaction transaction = o.Session.Logout(true))
      {
        BusinessModule instance = BusinessModule.GetInstance((ISessionable) o.Session);
        TypZdarzenia typ = TypZdarzenia.Opuszczenie;
        StanRealizacji stanRealizacji = o.StanRealizacji;
        Quantity zero = Quantity.Zero;
        foreach (int id in intList)
        {
          Soneta.Business.App.Operator @operator = instance.Operators[id];
          SubTable<ProdOsoba> subTable = o.Session.GetProdukcja().ProdOsobyR.WgOperator[@operator];
          ProdOsoba first = subTable.Count == 1 ? subTable.GetFirst() : (ProdOsoba) null;
          ProdHistoria prodHistoria1 = new ProdHistoria(typ, zero, first, @operator, stanRealizacji, data, czas);
          prodHistoria1.Zapis = (IProdHistoriaZapis) o;
          ProdHistoria prodHistoria2 = prodHistoria1;
          o.ProdHistorie.BaseTable.AddRow((Row) prodHistoria2);
        }
        transaction.CommitUI();
      }
    }
