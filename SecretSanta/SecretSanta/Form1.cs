using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;

namespace SecretSanta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '\u2744';
        }

        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                MessageBox.Show("[" + token + "] Send canceled.");
            }
            if (e.Error != null)
            {
                MessageBox.Show("[" + token + "] { " + e.Error.ToString() + "} ");
            }
            else
            {
                MessageBox.Show("Message sent.");
            }
            mailSent = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DrawingResult result in DrawingResult.PerfrormDrawings(Participant.ParseParticipants(txtParticipants.Text)))
            {
                SendGmail(txtEmail.Text, txtPassword.Text, result.Giver.Email, "Secret Santa 2016", result.Message);
            }
        }

        private void SendGmail(string gmail, string password, string toEmail, string subject, string message)
        {
            MailAddress from = new MailAddress(gmail, "Secret Santa");
            MailAddress to = new MailAddress(toEmail);
            MailMessage messageObj = new MailMessage(from, to)
            {
                Body = message,
                Subject = subject
            };

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(gmail, password),
                EnableSsl = true
            };
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            string userState = toEmail;
            client.SendAsync(messageObj, userState);

            //Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            //string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            //if (answer.StartsWith("c") && mailSent == false)
            //{
            //    client.SendAsyncCancel();
            //}
            // Clean up.
            //message.Dispose();
            //Console.WriteLine("Goodbye.");
        }
    }

    public class Participant
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Wishlist { get; set; }

        public Participant(string Name, string Email, string Wishlist)
        {
            this.Name = Name.Trim();
            this.Email = Email.Trim();
            this.Wishlist = Wishlist.Trim();
        }

        public Participant(string Name, string Email) : this(Name, Email, "") { }

        public Participant(string Entry)
        {
            List<string> info = new List<string>(Entry.Split(",".ToCharArray()));
            this.Name = info[0];
            this.Email = info[1];
            this.Wishlist = info[2];
        }

        public override int GetHashCode()
        {
            return Email.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Participant)) return false;
            else return this.Email.Equals(((Participant)obj).Email);
        }

        public static List<Participant> ParseParticipants(string input)
        {
            List<Participant> retval = new List<Participant>();
            foreach(string line in input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                retval.Add(new Participant(line));
            }
            return retval;
        }
    }

    public class DrawingResult
    {
        public Participant Giver { get; set; }
        public Participant Receiver { get; set; }

        public DrawingResult(Participant Giver, Participant Receiver)
        {
            this.Giver = Giver;
            this.Receiver = Receiver;
        }

        public string Message
        {
            get
            {
                return Giver.Name + ", you drew " + Receiver.Name + "!";
            }
        }

        public static List<DrawingResult> PerfrormDrawings(List<Participant> Participants)
        {
            if (Participants.Count <= 2) throw new ArgumentException("At least 3 participants are needed for a drawing.");

            List<DrawingResult> retval = new List<DrawingResult>(Participants.Count);
            Random rand = new Random();

            bool success = false;
            while (!success)
            {
                retval = new List<DrawingResult>(Participants.Count);
                List<Participant> NameHat = new List<Participant>(Participants);

                foreach(Participant drawer in Participants)
                {
                    if (NameHat.Count == 1 && NameHat[0].Equals(drawer))
                    {
                        break;
                    }
                    else
                    {
                        List<Participant> possibles = NameHat.Where(x => !x.Equals(drawer))
                                                             .Where(possible => retval.Where(alreadyDrawn => alreadyDrawn.Giver.Equals(possible) && alreadyDrawn.Receiver.Equals(drawer)).Count() == 0) //Prevent 2 person cycles.
                                                             .ToList();
                        if (possibles.Count == 0) break;

                        retval.Add(new DrawingResult(drawer, possibles[rand.Next(0, possibles.Count)]));
                        NameHat.Remove(retval[retval.Count - 1].Receiver);
                    }
                }
                if (NameHat.Count <= 0) success = true;
            }


            return retval;
        }
    }
}
