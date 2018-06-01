using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2Tests3.MockServices;

namespace Assignment2.Controllers.Tests
{
    [TestClass()]
    public class LaboratoryControllerTests
    {
        LaboratoryController lController = new LaboratoryController(new LaboratoryServicesMock());
        [TestMethod()]
        public void GetTest()
        {
            var ret = lController.Get(0);
            Assert.AreEqual(ret, null);
        }

        [TestMethod()]
        public void GetTest1()
        {
            string key = "test";
            var ret = lController.Get(key);
            Assert.AreEqual(ret.First().Curricula, key);
        }

        [TestMethod()]
        public void GetTest2()
        {
            var ret = lController.Get();
            Assert.AreEqual(ret.First().ID, 1);
            Assert.AreEqual(ret.Last().ID, 2);
        }

        [TestMethod()]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}