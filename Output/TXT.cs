string path = @"C:\Enova\mail.txt";
			
if (!System.IO.File.Exists(path))
{
    using (System.IO.StreamWriter sw = System.IO.File.CreateText(path))
    {
        sw.WriteLine("informacja");
    }	
}
