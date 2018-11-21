using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SecretSanta
{
    public partial class Form1 : Form
    {
        public Form1(string participantFileName, int seed, string gmail, string password)
        {
            InitializeComponent();
            this.lblStatus.Text = "";
            if (File.Exists(participantFileName))
            {
                this.txtParticipants.Text = File.ReadAllText(participantFileName);

                this.lblStatus.Text = participantFileName + " loaded.";
            }
            DrawingResult.Seed = seed;
            this.lblStatus.Text += " Seed: " + seed;
            this.txtEmail.Text = gmail;
            this.txtPassword.Text = password;
            this.txtMessage.Text = DrawingResult.DefaultMessage;
        }

        public Form1() : this("") { }

        public Form1(int seed) : this("", seed, "", "") { }

        public Form1(string participantFileName) : this(participantFileName, (int)DateTime.Now.TimeOfDay.TotalMilliseconds, "", "") { }

        static int toSend = 0;
        static int sent = 0;
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            String token = (string)e.UserState;
            sent++;
            progressStatus.Value = (int)((((double)sent) / toSend) * 100);

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
                lblStatus.Text = "Sent to " + token;
            }
            if (sent == toSend) lblStatus.Text = "Sending completed!";
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

            lblStatus.Text = "Sending to " + toEmail;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Perform a drawing and send the emails?", "Email Confirmation?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    List<DrawingResult> results = DrawingResult.PerfrormDrawings(Participant.ParseParticipants(txtParticipants.Text));
                    sent = 0;
                    toSend = results.Count;
                    foreach (DrawingResult result in results)
                    {
                        SendGmail(txtEmail.Text, txtPassword.Text, result.Giver.Email, "Secret Santa " + DateTime.Now.Year.ToString(), result.PrepareMessage(txtMessage.Text, txtEmail.Text));
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<DrawingResult> results = DrawingResult.PerfrormDrawings(Participant.ParseParticipants(txtParticipants.Text));
                StringBuilder test = new StringBuilder();
                foreach (DrawingResult result in results)
                {
                    test.Append(result.Giver.Email).Append(" => ").AppendLine(result.Receiver.Email);
                }
                MessageBox.Show(test.ToString(), "Test Results", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }

    public class Participant
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Wishlist { get; set; }
        public string Group { get; set; }

        public Participant(string Name, string Email, string Wishlist, string Group)
        {
            this.Name = Name.Trim();
            this.Email = Email.Trim();
            this.Wishlist = Wishlist.Trim();
            this.Group = Group.Trim();
        }

        public Participant(string Name, string Email) : this(Name, Email, "", "") { }

        public Participant(string Name, string Email, string Group) : this(Name, Email, "", Group) { }

        public Participant(string Entry)
        {
            List<string> info = new List<string>(Entry.Split(",".ToCharArray()));
            this.Name = info[0];
            this.Email = info[1];
            this.Wishlist = info.Count > 2 ? info[2] : "";
            this.Group = info.Count > 3 ? info[3] : "";
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
        public static int Seed { get; set; }

        public Participant Giver { get; set; }
        public Participant Receiver { get; set; }

        public DrawingResult(Participant Giver, Participant Receiver)
        {
            this.Giver = Giver;
            this.Receiver = Receiver;
        }

        public static List<DrawingResult> PerfrormDrawings(List<Participant> Participants)
        {
            if (Participants.Count <= 2) throw new ArgumentException("At least 3 participants are needed for a drawing.");

            Random rand = new Random(Seed);

            List<DrawingResult> retval = new List<DrawingResult>(Participants.Count);

            bool success = false;
            int count = 0;
            while (!success)
            {
                count++;
                Participants.Shuffle(rand);
                retval = Participants.Where((x, i) => i < Participants.Count - 1)
                                     .Select((giver, i) => new DrawingResult(giver, Participants[i + 1]))
                                     .ToList();
                retval.Add(new DrawingResult(Participants[Participants.Count - 1], Participants[0]));

                success = retval.Where(drawing => drawing.Giver.Group == drawing.Receiver.Group).Count() == 0;

                if (count > 10000) throw new Exception("After 10000 tries, no valid drawing was found.");
            }


            return retval;
        }

        public static string DefaultMessage
        {
            get
            {
                return
@"Dear ${GIVER_NAME},

You drew ${RECEIVER_NAME} for the Secret Santa Gift Exchange!
To get some gift ideas you can check out their wishlist here: ${RECEIVER_WISHLIST}
The gift limit is $50.
Remember to keep who you're buying a gift for secret!

Merry Christmas!
-Secret Santa

P.S. Check the following to make sure they're right, if there are any errors contact ${SENDING_EMAIL}:
Your email: ${GIVER_EMAIL}
Your Wishlist: ${GIVER_WISHLIST}

P.P.S. If you'd like to see the code that performed this drawing, you can see it here:
https://github.com/bethune-bryant/SecretSanta/blob/master/SecretSanta/SecretSanta/Form1.cs

Drawing Seed: ${SEED}";
            }
        }

        public string PrepareMessage(string template, string sendingEmail)
        {
            string retval = template;

            retval = retval.Replace("${GIVER_NAME}", Giver.Name);
            retval = retval.Replace("${GIVER_EMAIL}", Giver.Email);
            retval = retval.Replace("${GIVER_WISHLIST}", Giver.Wishlist.Trim().Length > 0 ? Giver.Wishlist : "(" + Giver.Name + " has no wishlist)");

            retval = retval.Replace("${RECEIVER_NAME}", Receiver.Name);
            retval = retval.Replace("${RECEIVER_EMAIL}", Receiver.Email);
            retval = retval.Replace("${RECEIVER_WISHLIST}", Receiver.Wishlist.Trim().Length > 0 ? Receiver.Wishlist : "(" + Receiver.Name + " has no wishlist)");

            retval = retval.Replace("${SEED}", Seed.ToString());

            retval = retval.Replace("${SENDING_EMAIL}", sendingEmail);

            return retval;
        }
    }

    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list, Random rng)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
