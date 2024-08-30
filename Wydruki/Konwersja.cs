[DxBind]
private void pageInfo_Main_BeforePrint(object sender, 
System.Drawing.Printing.PrintEventArgs e) 
=> e.Cancel = footerData != null && !footerData.PageNumbers;
Należy zamienić na:

[DxBind]
private void pageInfo_Main_BeforePrint(object sender,
System.ComponentModel.CancelEventArgs e) 
=> e.Cancel = footerData != null && !footerData.PageNumbers;
