public MessageBoxInformation LogOffOperators() {
    var operators = new ZalogowaniOperatorzy(Session.Login);
    ICollection<InstancjaRow> instantions = operators.Pobrane;

    var worker = new ZalogowaniOperatorzyExtender();

    worker.ZalogowaniOperatorzy = operators;    
    worker.Zaznaczeni = instantions.ToArray();  //podstawione wszystkie instancje ale worker pominie tą, z której wywołana jest funkcjonalność

    var logoutOperators = new StringBuilder();
    foreach (var instantion in instantions) {
        if (instantion.Stanowisko != Session.Login.ClientUniqueID) {
            logoutOperators.AppendLine(instantion.Info);
        }
    }

    using (var t = Session.Logout(true)) {
        if (worker.Wyloguj() is MessageBoxInformation result) {
            result.YesHandler();
        }
        t.Commit();
    }

    string resultInfo = string.Empty;
    if (logoutOperators.Length > 0) {
        resultInfo = $"Wylogowano:\n{logoutOperators}";
    } else {
        resultInfo = "Brak innych zalogowanych operatorów";
}

    return new MessageBoxInformation() {
        Text = resultInfo,
        OKHandler = () => FormAction.SaveAndClose
    };
}
