using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.ExtractEmails
{
    class ExtractEmails
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<user>[0-9a-zA-Z][0-9a-zA-Z.\-_]*[0-9a-zA-Z])@(?<host>[a-zA-Z][a-zA-Z\-]*[a-zA-Z])(\.[a-zA-Z][a-zA-Z\-]*[a-zA-Z])+";
        }
    }
}
