using System;
using System.Collections.Generic;
using System.Text;

namespace EventRegistration
{
    public class RegistrationRules
    {
        public bool canJoin(int age)
        {
            if(age <= 0)
                throw new ArgumentException(nameof(age));

            return age >= 18;
        }
    }
}
