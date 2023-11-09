// pobranie dokumentu z kontekstu (wydruk możliwy jedynie ze środka dokumentu)
Soneta.Business.Context context = (DataSource as Soneta.Business.UI.DxReports.BusinessDataSource)[0] as Soneta.Business.Context;
DokumentHandlowy dh = (DokumentHandlowy)context[typeof(DokumentHandlowy)];

// pobranie dokumentu z kontenera, który posiada DataSource = "this" (wydruk możliwy z listy i ze środka dokumentu)
DokumentHandlowy dh = (DokumentHandlowy)Dokument.GetCurrentRow();
