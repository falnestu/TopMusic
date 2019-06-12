using Application.ViewModels;
using Common.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VoteControllerService
    {
        public VoteViewModel GetVoteViewModel(int categoryID, string userID)
        {
            var viewModel = new VoteViewModel()
            {
                Category = CategoryService.Get(categoryID)
            };
            viewModel.Albums = GetAlbumsList(categoryID, userID);
            return viewModel;
        }

        private List<VoteAlbumViewModel> GetAlbumsList(int categoryID, string userID)
        {
            var rankingAlbums = RankingService.GetRankingAlbumsByCategoryID(categoryID);
            var votedAlbumsIDs = AlbumService.GetAlbumsVotedByCategoryIDAndUserID(categoryID, userID).Select(a => a.AlbumID);

            var votedAlbums = rankingAlbums.Where(ra => votedAlbumsIDs.Contains(ra.AlbumID)).Select(ra => new VoteAlbumViewModel
            {
                Album = ra,
                IsUserVote = true
            }).ToList();

            var notVotedAlbums = rankingAlbums.Where(ra => !votedAlbumsIDs.Contains(ra.AlbumID)).Select(ra => new VoteAlbumViewModel
            {
                Album = ra,
                IsUserVote = false
            }).ToList();


            votedAlbums.AddRange(notVotedAlbums);

            return votedAlbums;
        }

        public bool ToggleVote(int id, int categoryID, string userID, bool actual, out string message)
        {
            message = string.Empty;
            var category = CategoryService.Get(categoryID);
            if (category.Statut != (int)Common.Entities.CategoryStatus.Opened)
            {
                message = "La catégorie est fermée aux votes";
                return false;
            }
            if (actual)
            {
                RankingService.RemoveVote(id, userID);
                message = "Votre vote a bien été annulé !";
                return true;
            }

            int nbVotes = RankingService.GetNumberVotesForUser(categoryID, userID);
            if (nbVotes >= Constants.MAX_VOTES)
            {
                message = "Désolé, vous avez atteint le maximum de votes";
                return false;
            }
            if (RankingService.AddVote(id, userID))
            {
                message = "Merci pour votre vote !";
                return true;
            }
            else
            {
                message = "Vous avez déjà voté pour cet album";
                return false;
            }

        }
    }
}
