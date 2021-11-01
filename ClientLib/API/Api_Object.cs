using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.API
{
    public class Api_Object
    {
        public string success { get; set; }
        public string timestamp { get; set; }
        public string Base { get; set; }
        public string date { get; set; }
        public Rate rates { get; set; }
        public Error error { get; set; }
    }

    public class Rate
    {
        public double RON { get; set; }
        public double EUR { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public string info { get; set; }
    }
}
