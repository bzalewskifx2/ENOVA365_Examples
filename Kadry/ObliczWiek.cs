Date today = Date.Today;
Date birth = r.Urodzony.Data;
int age = today.Year - birth.Year;
if (birth > today.AddYears(-age)) age--;
throw new System.Exception(age.ToString());
