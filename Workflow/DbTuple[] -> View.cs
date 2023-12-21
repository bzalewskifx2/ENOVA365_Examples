public object GetListWniosekDoAnulowania() 
{
      CoreModule cm = Session.GetCore();
      DbTupleDefinition def = cm.TuplesDefs[179];
      SubTable subtable = (SubTable)cm.Tuples.WgDefinicja[def];
      
      List<DbTuple> tuplelist = new List<DbTuple>();
      
      foreach (DbTuple t in subtable)
      {
          if ((Pracownik)t.Fields["Pracownik"] == Pracownik)
              tuplelist.Add(t);
      }
      
      View v = new View(cm.Tuples.WgDefinicja.Key, tuplelist);
      return v;
}
