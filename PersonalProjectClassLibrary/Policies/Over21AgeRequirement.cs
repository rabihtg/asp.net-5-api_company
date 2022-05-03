using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Policies
{
    public class Over21AgeRequirement : IAuthorizationRequirement
    {
        
        public int RequiredAge { get; }

        public Over21AgeRequirement(int age)
        {
            RequiredAge = age;
        }


    }
}
