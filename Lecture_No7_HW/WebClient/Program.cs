using Application;
using Infrastructure;
using Microsoft.Extensions.Hosting;
using System;
using WebClient.Models;

namespace WebClient
{

    static class Program
    {
        public static IHost Host { get; private set; }
        [MTAThread]
        static void Main(string[] args)
        {
            Host = Configuration(args);


            Console.ReadLine();
        }

        private static CustomerCreateRequest RandomCustomer()
        {
            return new();
        }
        private static IHost Configuration(string[] args) => Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
               

            }).Build();
    }
}

