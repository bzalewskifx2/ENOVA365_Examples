// Powiadomienie po odrzuceniu wniosku do wprowadzającego

public void GetSysNotificationContentHandle(Soneta.Business.Db.SysNotificationContentHandleEventArgs args) 
{
		args.Subject = "Odrzucony wniosek o szkolenie " + Row.Numer.NumerPelny;
		args.Body = "Twój wniosek o szkolenie '" + Row.Temat_szkolenia + " został odrzucony.";
}

public void CanCreateSysNotificationHandle(CanCreateSysNotificastionHandleEventArgs args) 
{
		if (Row.Wprowadzający == null)
				args.Cancel = true;
}

public void GetRecipientsExpressionHandle(Soneta.Business.Db.SysNotificationRecipientsExpressionHandleEventArgs args) 
{
		if (Row.Wprowadzający != null)
				args.Recipients = [Row.Wprowadzający as ITaskUser];
}
