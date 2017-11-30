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
    public class DrawingResultTests
    {
        [TestMethod()]
        public void PerfrormDrawingsTest()
        {
            for (int count = 12; count <= 100; count++)
            {
                List<Participant> inputs = new List<Participant>(count);

                for (int i = 0; i < count; i++) inputs.Add(new Participant("Test" + i, "test" + i + "@email.com", (i % (count / 3)).ToString()));

                List<DrawingResult> results = DrawingResult.PerfrormDrawings(inputs);

                Assert.AreEqual(inputs.Count, results.Count, "Result size.");
                Assert.AreEqual(0, results.Where(x => x.Giver.Equals(x.Receiver)).Count(), "Self drawing.");
                Assert.AreEqual(inputs.Count, results.Select(x => x.Giver).Distinct().Count(), "All participants drew.");
                Assert.AreEqual(inputs.Count, results.Select(x => x.Receiver).Distinct().Count(), "All participants were drawn.");
                foreach (DrawingResult result in results)
                {
                    Assert.IsTrue(results.Where(x => x.Giver.Equals(result.Receiver) && x.Receiver.Equals(result.Giver)).Count() == 0, "Direct cycle.");
                }
                Assert.IsTrue(results.Where(result => result.Giver.Group.Length > 0 && result.Receiver.Group.Equals(result.Giver.Group)).Count() == 0, "Group exclusion.");
            }
        }

        [TestMethod()]
        public void PrepareMessageTest()
        {
            Participant test1 = new Participant("Test" + 1, "test" + 1 + "@email.com", "wishlist1", "test1");
            Participant test2 = new Participant("Test" + 2, "test" + 2 + "@email.com", "test2");
            DrawingResult test = new DrawingResult(test1, test2);
            DrawingResult.Seed = 123456789;

            Assert.AreEqual("santa@email.com,Test1,test1@email.com,wishlist1,Test2,test2@email.com,(Test2 has no wishlist),123456789", test.PrepareMessage("${SENDING_EMAIL},${GIVER_NAME},${GIVER_EMAIL},${GIVER_WISHLIST},${RECEIVER_NAME},${RECEIVER_EMAIL},${RECEIVER_WISHLIST},${SEED}", "santa@email.com"), false);

            test = new DrawingResult(test2, test1);

            Assert.AreEqual("santa@email.com,Test2,test2@email.com,(Test2 has no wishlist),Test1,test1@email.com,wishlist1,123456789", test.PrepareMessage("${SENDING_EMAIL},${GIVER_NAME},${GIVER_EMAIL},${GIVER_WISHLIST},${RECEIVER_NAME},${RECEIVER_EMAIL},${RECEIVER_WISHLIST},${SEED}", "santa@email.com"), false);
        }
    }
}