using System;
using Insurance_Company.Data;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Insurance_Company.Models;


namespace Insurance_Company
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new InsuranceCompanyContext();
            DbInitializer.Initialize(context);
            WriteLine("Hello World!");

        }
    }
}
