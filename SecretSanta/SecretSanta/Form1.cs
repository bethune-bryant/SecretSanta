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
using System.IO;

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
            DrawingResult.rand = new Random(seed);
            this.lblStatus.Text += " Seed: " + seed;
            this.txtEmail.Text = gmail;
            this.txtPassword.Text = password;
        }

        public Form1() : this("") { }

        public Form1(int seed) : this("", seed, "", "") { }

        public Form1(string participantFileName) : this(participantFileName, (int)DateTime.Now.TimeOfDay.TotalMilliseconds, "", "") { }

        static int toSend = 0;
        static int sent = 0;
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
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
            if (DialogResult.Yes == MessageBox.Show("Perform a drawing and send the emails?", "Email Confirmation?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                List<DrawingResult> results = DrawingResult.PerfrormDrawings(Participant.ParseParticipants(txtParticipants.Text));
                sent = 0;
                toSend = results.Count;
                foreach (DrawingResult result in results)
                {
                    SendGmail(txtEmail.Text, txtPassword.Text, result.Giver.Email, "Secret Santa " + DateTime.Now.Year.ToString(), result.Message);
                }
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DrawingResult> results = DrawingResult.PerfrormDrawings(Participant.ParseParticipants(txtParticipants.Text));
            StringBuilder test = new StringBuilder();
            foreach (DrawingResult result in results)
            {
                test.Append(result.Giver.Email).Append(" => ").AppendLine(result.Receiver.Email);
            }
            MessageBox.Show(test.ToString(), "Test Results", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
        public static Random rand = new Random();

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
                return
                    "Dear " + Giver.Name + "," + Environment.NewLine +
                    Environment.NewLine +
                    "You drew " + Receiver.Name + " for the Secret Santa Gift Exchange!" + Environment.NewLine +
                    (Receiver.Wishlist.Trim().Length == 0 ? "" : "To get some gift ideas you can check out their wishlist here: " + Receiver.Wishlist + Environment.NewLine) +
                    "The gift limit is $50." + Environment.NewLine +
                    Environment.NewLine +
                    "Merry Christmas!" + Environment.NewLine +
                    "-Secret Santa" + Environment.NewLine +
                    Environment.NewLine +
                    Environment.NewLine +
                    "P.S. If you'd like to see the code that performed this drawing, you can see it here:" + Environment.NewLine +
                    @"https://github.com/bethune-bryant/SecretSanta/blob/master/SecretSanta/SecretSanta/Form1.cs";
            }
        }

        public static List<DrawingResult> PerfrormDrawings(List<Participant> Participants)
        {
            if (Participants.Count <= 2) throw new ArgumentException("At least 3 participants are needed for a drawing.");

            List<DrawingResult> retval = new List<DrawingResult>(Participants.Count);

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
                                                             .Where(possible => drawer.Group.Length == 0 || !drawer.Group.Equals(possible.Group)) //Prevent drawing from the same group.
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
