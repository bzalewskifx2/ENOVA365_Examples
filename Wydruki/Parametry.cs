using Soneta.Business.UI.DxReports;
using System.ComponentModel;
using Soneta.Tools;

namespace Soneta.Handel.Reports
{
    public class soid_umowaSnippet : ReportSnippet
    {
	public class Params : ContextBase//SerializableContextBase - umożliwia zapamiętanie domyślnych wartości parametrów
	{
	    public Params(Context context) : base(context) 
	    { 
		osoba = "";
	    }
	
	    private string osoba;
	
	    [Required]
	    [Caption("Osoba upoważniona"), DefaultWidth(20)]
	    public string Osoba
	    {
		get => osoba;
	
		set
		{
		    osoba = value;
		    OnChanged(EventArgs.Empty);
		}
	    }
		
	    public object GetListOsoba()
	    {
		return new string[]
		{
		    "Marek Nowak",
		    "Jan Kowalski",
		    "Bogusław Linda"
		};
	    }
     	}
  
	[Context]
	public Params BaseParams { get; set; }

        [DxBind]
	private readonly DevExpress.XtraReports.UI.DetailBand DokumentTreść;

        [DxBind]
	private void DokumentTreść_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // akcja
        }
    }
}
