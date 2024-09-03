DictionaryItem[] items = Context.Session.GetBusiness().Dictionary.WgParent.Where(i => i.Category == "F.Typ urządzenia").ToArray();
return new LookupInfo.EnumerableItem("test", items){ ComboBox = false};
