using DAL.Model;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RankingService
    {
        public static List<RankAlbum> GetTop3ByCategoryID(int categoryID)
        {
            using (TopMusicEntities db = new TopMusicEntities())
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
