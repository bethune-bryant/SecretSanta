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
                foreach(DrawingResult result in results)
                {
                    Assert.IsTrue(results.Where(x => x.Giver.Equals(result.Receiver) && x.Receiver.Equals(result.Giver)).Count() == 0, "Direct cycle.");
                }
                Assert.IsTrue(results.Where(result => result.Giver.Group.Length > 0 && result.Receiver.Group.Equals(result.Giver.Group)).Count() == 0, "Group exclusion.");
            }
        }
    }
}