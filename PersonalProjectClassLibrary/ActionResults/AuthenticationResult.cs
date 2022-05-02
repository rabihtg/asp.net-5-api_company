using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.ActionResults
{
    public class AuthenticationResult
    {
        public int StatusCode { get; set; }

        public TokenModel Token { get; set; }

        public string Error { get; set; }
    }
}
