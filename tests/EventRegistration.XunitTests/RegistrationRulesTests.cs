using System;
using Xunit;
using EventRegistration;

namespace EventRegistration.XunitTests
{
    public class RegistrationRulesTests
    {
        [Fact]
        public void Canjoin_Adult_ReturnsTrue()
        {
            var rules = new RegistrationRules();
            bool canjoin = rules.canJoin(25);
            Assert.True(canjoin);
        }

        [Theory]
        [InlineData(17 , false)]
        [InlineData(18 , true)]
        public void Canjoin_Full_Retult(int age , bool expected)
        {
            var rules = new RegistrationRules();
            Assert.Equal(expected, rules.canJoin(age));
        }

        [Fact]
        public void CanJoin_NegativeAge_Throws()
        {
            var rules = new RegistrationRules();
            Assert.Throws<ArgumentException>(() => rules.canJoin(-1));
        }
    }
}
