using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using nonoCore.Entity;
using nonoCore.Service;

namespace nonoTest
{
    [TestClass]
    public class ScoreServiceTest
    {
        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();
            DateTime started = DateTime.Now;
            DateTime finished = DateTime.Now;

            service.AddScore(new Score { Player = "Tomo", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });

            Assert.AreEqual(1, service.GetTopScores().Count);

            Assert.AreEqual("Tomo", service.GetTopScores()[0].Player);
            Assert.AreEqual(0, service.GetTopScores()[0].Seconds);
        }

        [TestMethod]
        public void AddTest3()
        {
            var service = CreateService();
            DateTime started = DateTime.Now;
            DateTime finished = DateTime.Now;

            service.AddScore(new Score { Player = "Tomo", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Fero", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Jozo", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });

            Assert.AreEqual(3, service.GetTopScores().Count);

            Assert.AreEqual("Tomo", service.GetTopScores()[0].Player);
            Assert.AreEqual(0, service.GetTopScores()[0].Seconds);

            Assert.AreEqual("Fero", service.GetTopScores()[1].Player);
            Assert.AreEqual(0, service.GetTopScores()[1].Seconds);

            Assert.AreEqual("Jozo", service.GetTopScores()[2].Player);
            Assert.AreEqual(0, service.GetTopScores()[2].Seconds);
        }

        [TestMethod]
        public void AddTest5()
        {
            var service = CreateService();
            DateTime started = DateTime.Now;
            DateTime finished = DateTime.Now;

            service.AddScore(new Score { Player = "Tomo", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Fero", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Jozo", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Peter", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Jaro", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });

            Assert.AreEqual(3, service.GetTopScores().Count);

            Assert.AreEqual("Tomo", service.GetTopScores()[0].Player);
            Assert.AreEqual(0, service.GetTopScores()[0].Seconds);

            Assert.AreEqual("Fero", service.GetTopScores()[1].Player);
            Assert.AreEqual(0, service.GetTopScores()[1].Seconds);

            Assert.AreEqual("Jozo", service.GetTopScores()[2].Player);
            Assert.AreEqual(0, service.GetTopScores()[2].Seconds);
        }

        [TestMethod]
        public void ResetTest()
        {
            var service = CreateService();
            DateTime started = DateTime.Now;
            DateTime finished = DateTime.Now;

            service.AddScore(new Score { Player = "Tomo", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Fero", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });
            service.AddScore(new Score { Player = "Jozo", FinishedAt = finished, StartedAt = started, Seconds = finished.Second - started.Second });

            service.ResetScore();
            Assert.AreEqual(0, service.GetTopScores().Count);
        }

        private IScoreService CreateService()
        {
            return new ScoreServiceFile();
        }
    }
}

