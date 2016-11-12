using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Tests
{
    [TestClass()]
    public class ParticipantTests
    {
        [TestMethod()]
        public void ParseParticipantsTest()
        {
            StringBuilder input = new StringBuilder();

            int count = 10;

            for(int i = 1; i<= count; i++)
            {
                string name = "Tester Test" + i;
                string email = ",tester" + i + ".test@email.com";
                string wishlist = i % 2 == 0 ? "" : ",wishlist" + i + ".amazon.com/wishlist";
                string group = i % 2 == 0 ? "" : "," + (i % 5);
                input.AppendLine(name + email + wishlist);
            }

            List<Participant> result = Participant.ParseParticipants(input.ToString());

            Assert.AreEqual(count, result.Count, "Result count.");
        }
    }
}