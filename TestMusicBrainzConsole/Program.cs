using MusicBrainzServiceAgent;
using System;
using System.Collections.Generic;

namespace TestMusicBrainzConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            TestQueryMusicBrainz("Recherche Albums par Artiste :", ServiceAgent.SearchAlbumsByArtistName);

            TestQueryMusicBrainz("Recherche Albums par nom d'album :", ServiceAgent.SearchAlbums);

            Console.ReadKey();
        }

        static private void DisplayList<T>(List<T> list)
        {
            list.ForEach(entry => Console.WriteLine(entry));
        }

        static private void TestQueryMusicBrainz<T>(string title, Func<string, List<T>> action)
        {
            Console.WriteLine(title);
            string entry = Console.ReadLine();
            Console.WriteLine("Résultats:");
            List<T> result = action(entry);
            DisplayList(result);
            Console.WriteLine("\n -------------- \n");
        }

    }
}
