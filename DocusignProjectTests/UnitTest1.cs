using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocusignProject;
using System;

namespace DocusignProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidateData_WithValidCold_ReturnsCorrectStr()
        {
            string expected = "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house";
            Person p = new Person("COLD 8, 6, 3, 4, 2, 5, 1, 7");
            string actual = p.ValidateData();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateData_WithValidHot_ReturnsCorrectStr()
        {
            string expected = "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house";
            Person p = new Person("HOT 8, 6, 4, 2, 1, 7");
            string actual = p.ValidateData();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateData_WithDuplicates_ReturnsCorrectStr()
        {
            string expected = "Removing PJs, shorts, fail";
            Person p = new Person("HOT 8, 6, 6");
            string actual = p.ValidateData();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateData_WithShortInputHot_ReturnsCorrectStr()
        {
            string expected = "Removing PJs, shorts, fail";
            Person p = new Person("HOT 8, 6, 3");
            string actual = p.ValidateData();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateData_WithShortInputCold_ReturnsCorrectStr()
        {
            string expected = "fail";
            Person p = new Person("COLD 6");
            string actual = p.ValidateData();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestValidateData_WithWrongOrder_ReturnsCorrectStr()
        {
            string expected = "Removing PJs, pants, socks, shirt, hat, jacket, fail";
            Person p = new Person("COLD 8, 6, 3, 4, 2, 5, 7");
            string actual = p.ValidateData();

            Assert.AreEqual(expected, actual);
        }

        



    }
}
