using System;
using System.Net.Mail;
using System.ServiceProcess;
using System.Timers;

namespace HourlyEmailService_Task1
{
    public partial class Service1 : ServiceBase
    {
        Timer timer;
        int count = 1;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = 3600000; /// timer works on milli seconds
            timer.Elapsed += new ElapsedEventHandler(OnTimeIntervalOver);
            timer.Start();
            Sendmail();

        }
        public void OnTimeIntervalOver(object _, ElapsedEventArgs __)
        {
            count++;
            Sendmail();
        }

        public void Sendmail()
        {
            try
            {
                MailAddress from = new MailAddress("");
               
                MailMessage ourmail = new MailMessage("//your mail");
                ourmail.From = from;
                ourmail.To.Add(new MailAddress("// Receiptant mail"));
                ourmail.CC.Add(new MailAddress("// cc Receiptant mail")); 
                ourmail.CC.Add(new MailAddress("// cc Receiptant mail"));
                ourmail.CC.Add(new MailAddress("// cc Receiptant mail"));


                ourmail.Subject = "This is Hourly Mail from Aswin";
                ourmail.Body = $"Hourly Mail Number  {count}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); // smtp.office365.com -> for outlook account
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("your mail", "your app password from gmail");
                smtp.EnableSsl = true;

                smtp.Send(ourmail);
            }
            catch (Exception ex)
            {
               LogToFile($"Sendmail failed: {ex.Message}");
            }


        }
        // chatgpt used for exeception handling
        public void LogToFile(string message)
        {
            string path = @"C:\Users\ASWIN S\Desktop\Log\HourlyEmailService_Task1.txt";  // ✅ You can use .txt or .log

            try
            {
                // Create directory if it doesn't exist
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

                // Append log to the file
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
                }
            }
            catch
            {
                // Don’t throw if logging fails (service must stay alive)
            }
        }



        protected override void OnStop()
        {
            timer.Stop();
        }
    }
}
