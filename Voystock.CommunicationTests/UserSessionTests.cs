using Microsoft.VisualStudio.TestTools.UnitTesting;
using Voystock.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voystock.Communication.Tests
{
    [TestClass()]
    public class UserSessionTests
    {
        [TestInitialize()]
        public async void OpenTest()
        {
            await UserSession.Open();
        }

        [TestCleanup()]
        public async void CloseTest()
        {
            await UserSession.Close();
        }

        [TestMethod()]
        public void GetAllScheme()
        {
            Assert.IsTrue(UserSession.AllSchemes.Count > 0);
        }

        [TestMethod()]
        public void DeleteSchemeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrModifySchemeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EvaluateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEvaluationResultTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StopEvaluationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LearnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetLearningResultTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StopLearningTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RecommendTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRecommendationResultTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRecommendationResultOnDateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void StopRecommendationResultTest()
        {
            Assert.Fail();
        }
    }
}