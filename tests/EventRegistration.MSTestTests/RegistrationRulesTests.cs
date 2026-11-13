using System;
using EventRegistration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace EventRegistration.MSTestTests
{
    [TestClass]
    public class RegistrationRulesTests
    {
        [TestMethod]
        public void RegistretionInSingle()
        {
            var rules = new RegistrationRules();
            bool canJoin = rules.canJoin(25);

            Assert.IsTrue(canJoin);
        }

        [TestMethod]
        [DataRow(17 , false)]
        [DataRow(18 , true)]
        public void CanJoin_BoundaryCases_ReturnExpected(int age, bool expected)
        {
            // Check one age below the limit and one at the limit.
            var rules = new RegistrationRules();
            Assert.AreEqual(expected, rules.canJoin(age));
        }

        [TestMethod]
        public void CanJoin_NegativeAge_Throws()
        {
            // Bad input should give an error.
            var rules = new RegistrationRules();
            Assert.ThrowsExactly<ArgumentException>(() => rules.canJoin(-1));
        }
    }
}
