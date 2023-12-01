// relacja kopiowania FZAL -> FV2
DefRelacjiHandlowej defRelacjiZal = handelModule.DefRelHandlowych.WgDefinicjaNadrzednego[zaliczka.Definicja].Where
(r => r.Typ == TypRelacjiHandlowej.Kopiowania && r.DefinicjaPodrzednego == fv2.Definicja).FirstOrDefault();
var relacjaZal = new RelacjaHandlowa.Wiązania(defRelacjiZal, zaliczka, fv2);
handelModule.RelacjeHandlowe.AddRow(relacjaZal);

// relacja zaliczki FZAL -> FV2
var api = zaliczka.Session.GetRequiredService<IRelacjeService>();
api.DolaczPodrzednyIndywidualny
(
    new[] { zaliczka },
    "Faktura sprzedaży 2",
    handlers: new HandlerSet
    {
        WybierzDokumentyCallback = p => p.DokumentWybrany = p.Dokumenty.Cast<DokumentHandlowy>().First(),
        WybierzDokumentyZaliczkoweCallback = target => target.Context.Set
        (
            new RelacjeHandloweWorker.DokumentyZaliczkoweParams(target.Context)
            {
                Docelowy = target
            }
        )
    }
);
