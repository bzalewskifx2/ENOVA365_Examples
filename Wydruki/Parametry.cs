using Soneta.Business.UI.DxReports;
using System.ComponentModel;
using Soneta.Tools;

namespace Soneta.Handel.Reports
{
    public class soid_umowaSnippet : ReportSnippet
    {
	public class Params : ContextBase//SerializableContextBase - umożliwia zapamiętanie domyślnych wartości parametrów
	{
	    public Params(Context context) : base(context) { }
	
	    private int year = DateTime.Now.Year;
	
	    [Required]
	    [Caption("Rok"), DefaultWidth(4)]
	    public int Year
	    {
		get => year;
	
		set
		{
		    year = value;
		    OnChanged(EventArgs.Empty);
		}
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
