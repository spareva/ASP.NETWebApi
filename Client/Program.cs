using Music.Data;
using Music.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Music.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace Music.Client
{
    class MusicConsoleClient
    {
        static string baseUrl = "http://localhost:19322/";

        static void Main()
        {
            RequestConsumer consumer = new RequestConsumer(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            //only artist implemented
        }

        private static string EnterArtist(RequestConsumer reqConsumer, string controller)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter country(optional): ");
            string country = Console.ReadLine();
            Console.WriteLine("Enter birth date(optional): ");
            DateTime? date = null;
            try
            {
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
            }

            Artist newArtist = CreateArtistObject(0, name, country, date);

            //choose json or xml
            var sent = reqConsumer.CreateAsJson<Artist>(newArtist, controller);
            return sent;
            //var sent = reqConsumer.CreateAsXML<Artist>(newArtist, controller);
            //return sent;
        }

        private static Artist CreateArtistObject(int id, string name, string country, DateTime? date)
        {
            Artist newArtist = new Artist()
            {
                ArtistId = id,
                Name = name,
                Country = country
            };
            return newArtist;
        }
    }
}