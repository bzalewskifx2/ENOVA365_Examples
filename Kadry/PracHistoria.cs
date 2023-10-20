// *** aktualna PracHistoria *** //
Pracownik prac = null;
PracHistoria ph = prac[Date.Now];

// *** Enum to String *** //
string wyksztalcenie;

switch (ph.Wyksztalcenie.Kod)
{              
    case KodWyksztalcenia.NiepelnePodstawowe:
        wyksztalcenie = "Niepełne podstawowe";
        break;
    case KodWyksztalcenia.Podstawowe:
        wyksztalcenie = "Podstawowe";
        break;
    case KodWyksztalcenia.Gimnazjalne:
        wyksztalcenie = "Gimnazjalne";
        break;
    case KodWyksztalcenia.ZasadniczeZawodowe:
        wyksztalcenie = "Zasadnicze zawodowe";
        break;
    case KodWyksztalcenia.SrednieZawodowe:
        wyksztalcenie = "Średnie zawodowe";
        break;
    case KodWyksztalcenia.SrednieOgolnoksztalcace:
    case KodWyksztalcenia.Policealne:
        wyksztalcenie = "Średnie ogólnokształcące";
        break;
    case KodWyksztalcenia.Licencjat:
        wyksztalcenie = "Wyższe z tytułem inżyniera, licencjata, dyplomowanego ekonomisty lub równorzędnym";
        break;
    case KodWyksztalcenia.Wyzsze:
        wyksztalcenie = "Wyższe z tytułem magistra, lekarza lub równorzędnym";
        break;
    case KodWyksztalcenia.WyższeZeStopiemNaukowym:
        wyksztalcenie = "Wyższe ze stopniem naukowym co najmniej doktora";
        break;
    case KodWyksztalcenia.NieDotyczy:
    default:
        wyksztalcenie = "Nie dotyczy";
        break;
}

string podstawa;

switch (ph.Etat.Podstawa)
{
    case StosPracyNaPodstawie.Brak:
        podstawa = "";
        break;
    case StosPracyNaPodstawie.Mianowania:
        podstawa = "Mianowanie";
        break;
    case StosPracyNaPodstawie.Oddelegowania:
        podstawa = "Oddelegowanie";
        break;
    case StosPracyNaPodstawie.Powołania:
        podstawa = "Powołanie";
        break;
    case StosPracyNaPodstawie.SpoldzielczejUmowyOPrace:
        podstawa = "Spółdzielcza umowa o pracę";
        break;
    case StosPracyNaPodstawie.UmowyOPrace:
        podstawa = "Umowa o pracę";
        break;
    case StosPracyNaPodstawie.UmowyOPracęNakładczą:
        podstawa = "Umowa o pracę nakładczą";
        break;
    case StosPracyNaPodstawie.Wyboru:
        podstawa = "Wybór";
        break;
    case StosPracyNaPodstawie.StanSpoczynku:
        podstawa = "Stan spoczynku";
        break;
    case StosPracyNaPodstawie.UposażenieRodzinne:
        podstawa = "Uposażenie rodzinne";
        break;
    case StosPracyNaPodstawie.SkierowaniaDoPracy:
        podstawa = "Skierowanie do pracy";
        break;
    default:
        podstawa = "";
        break;
}

string typ;

switch (ph.Etat.TypUmowy)
{
    case TypUmowyOPrace.Brak:
        typ = "";
        break;
    case TypUmowyOPrace.NaOkresZastępstwa:
        typ = "na okres zastępstwa";
        break;
    case TypUmowyOPrace.NaOkresTrwaniaMandatu:
        typ = "na okres trwania mandatu";
        break;
    case TypUmowyOPrace.DoDniaPorodu:
        typ = "do dnia porodu";
        break;
    case TypUmowyOPrace.NaCzasWykonywniaPracy:
        typ = "na czas wykonywania pracy";
        break;
    case TypUmowyOPrace.NaOkresPróbny:
        typ = "na okres próbny";
        break;
    case TypUmowyOPrace.NaCzasNieokreślony:
        typ = "na czas nieokreślony";
        break;
    case TypUmowyOPrace.NaCzasOkreślony:
        typ = "na czas określony";
        break;
    case TypUmowyOPrace.NaCzasOkreślonyDorywczySezonowy:
        typ = "na czas określony dorywczy sezonowy";
        break;
    case TypUmowyOPrace.NaCzasPełnieniaFunkcji:
        typ = "na czas pełnienia funkcji";
        break;
    default:
        typ = "";
        break;
}
