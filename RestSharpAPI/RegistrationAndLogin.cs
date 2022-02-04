using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public partial class RegistrationAndLogin
    {
        public string email { get; set; }
        public string password { get; set; }
        public long Id { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}
