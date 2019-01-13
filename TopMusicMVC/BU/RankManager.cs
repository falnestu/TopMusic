using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopMusicMVC.BU.Entities;

namespace TopMusicMVC.BU
{
    public class RankManager
    {
        public static List<RankAlbum> GetTop3ByCategoryID(int categoryID)
        {
            using (DAL.Model.TopMusicEntities db = new DAL.Model.TopMusicEntities())
            {
                var query = db.Album
                    .Where(a => a.CategoryID == categoryID && a.User.Any())
                    .Select(g => new RankAlbum()
                    {
                        AlbumDescription = g.Title + " - " + g.ArtistName,
                        NumberVotes = g.User.Count()
                    })
                     .OrderByDescending(x => x.NumberVotes)
                    .Take(3);

                var top3 = query.ToList();

                for (int i = 0; i < top3.Count(); i++)
                {
                    var rankAlbum = top3[i];
                    rankAlbum.Rank = i + 1;
                }

                return top3;
            }
        }
    }
}