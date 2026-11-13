using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using EventRegistration;

namespace EventRegistration.NUnitTests
{
    [TestFixture]
    public class RegistrationRulesTests
    {
        [Test]
        public void CanJoin_Adult_ReturnsTrue()
        {
            var rules = new RegistrationRules();
            bool canJoin = rules.canJoin(25);
            Assert.That(canJoin, Is.True);
        }

        [TestCase(17, false)]
        [TestCase(18, true)]
        public void Can_audut_MultipleValueReturn(int age, bool expected)
        {
            var rules = new RegistrationRules();
            Assert.That(rules.canJoin(age) , Is.EqualTo(expected));
        }

        [Test]
        public void CanJoin_NegativeAge_Throws()
        {
            // Bad input should give an error.
            var rules = new RegistrationRules();
            Assert.Throws<ArgumentException>(() => rules.canJoin(-1));
        }
    }
}
