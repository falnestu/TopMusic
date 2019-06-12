using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDALConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DAL.Model.TopMusicEntities())
            {
                var users = db.AspNetUsers.ToList();
                users.ForEach(user =>
                    Console.WriteLine(user));
            }

            Console.ReadKey();
        }
    }
}
