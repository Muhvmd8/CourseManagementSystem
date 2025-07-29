namespace CMS.PL.Helper;
public static class EmailSettings
{
    public static bool SendEmail(Email email)
    {
		// Mail server : Gmail
		// SMTP 

		try
		{
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ma7007167@gmail.com", "kuebisicmmogfair"); // sender
            client.Send("ma7007167@gmail.com", email.To, email.Subject, email.Body);
            return true;
        }
		catch (Exception)
		{
            return false;
		}
    }
}
