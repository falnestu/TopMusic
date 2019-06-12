using DAL.Model;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RankingService
    {
        public static List<RankAlbum> GetRankingAlbumsByCategoryID(int categoryID)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var query = db.Album
                    .Where(a => a.CategoryID == categoryID && a.AspNetUsers.Any())
                    .Select(g => new RankAlbum()
                    {
                        AlbumID = g.AlbumID,
                        AlbumDescription = g.Title + " - " + g.ArtistName,
                        NumberVotes = g.AspNetUsers.Count()
                    })
                     .OrderByDescending(x => x.NumberVotes);

                var top = query.ToList();

                for (int i = 0; i < top.Count(); i++)
                {
                    var rankAlbum = top[i];
                    rankAlbum.Rank = i + 1;
                }

                return top;
            }
        }

        public static List<RankAlbum> GetTop3ByCategoryID(int categoryID)
        {
            return GetRankingAlbumsByCategoryID(categoryID).Take(3).ToList();
        }

        public static void RemoveVote(int id, string userID)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var album = db.Album.Find(id);
                var user = db.AspNetUsers.Find(userID);
                if (album != null && user != null)
                {
                    album.AspNetUsers.Remove(user);
                    db.SaveChanges();
                }
            }
        }

        public static int GetNumberVotesForUser(int categoryID, string userID)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                return db.Album.Count(a => a.CategoryID == categoryID && a.AspNetUsers.Any(u => u.Id == userID));
            }
        }

        public static bool AddVote(int id, string userID)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var album = db.Album.Find(id);
                var user = db.AspNetUsers.Find(userID);
                if (album != null && user != null)
                {
                    if (album.AspNetUsers.Contains(user))
                    {
                        return false;
                    }
                    album.AspNetUsers.Add(user);
                    db.SaveChanges();
                }
            }
            return true;
        }
    }
}
