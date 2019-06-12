using DAL.Model;
using Domain.Entities;
using MusicBrainzServiceAgent;
using MusicBrainzServiceAgent.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AlbumService
    {
        public static List<Album> GetAlbumsByCategoryID(int categoryID)
        {
            List<Album> albums = null;
            using (TopMusicEntities db = new TopMusicEntities())
            {
                albums = db.Album.Where(a => a.CategoryID == categoryID).ToList();
            }
            return albums;
        }

        public static List<Album> GetAlbumsVotedByCategoryIDAndUserID(int categoryID,string userID)
        {
            List<Album> albums = null;
            using (TopMusicEntities db = new TopMusicEntities())
            {
                albums = db.Album.Where(a => a.CategoryID == categoryID && a.AspNetUsers.Any(u => u.Id == userID)).ToList();
            }
            return albums;
        }

        public static List<AlbumResult> MBSearch(string searchText, string searchType)
        {
            List<AlbumResult> albums = new List<AlbumResult>();
            List<MBReleaseGroup> MBResult = null;
            switch (searchType)
            {
                case "Artiste":
                    MBResult = ServiceAgent.SearchAlbumsByArtistName(searchText);
                    break;
                default:
                    MBResult = ServiceAgent.SearchAlbums(searchText);
                    break;
            }

            if (MBResult == null) return albums;

            return MBResult.OrderByDescending(x => x.Score)
                .Select(x => new AlbumResult
                {
                    Title = x.Title,
                    MusicBrainzID = x.Id,
                    ArtistName = x.ArtistCredit.Any() ? x.ArtistCredit[0].Artist.Name : "Unknown"
                }).ToList();
        }

        public static bool Delete(int id)
        {
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var album = db.Album.Find(id);
                if (album == null)
                {
                    return false;
                }

                db.Album.Remove(album);
                db.SaveChanges();
                return true;
            }
        }

        public static bool AddAlbumInCategory(int id, string mBID, string title, string artistName)
        {
            if (GetAlbumsByCategoryID(id).Exists(a => a.MusicBrainzID == mBID))
            {
                return false;
            }
            using (TopMusicEntities db = new TopMusicEntities())
            {
                var album = new Album
                {
                    MusicBrainzID = mBID,
                    ArtistName = artistName,
                    Title = title,
                    CategoryID = id
                };
                db.Album.Add(album);
                db.SaveChanges();
            }
            return true;
        }
    }
}
