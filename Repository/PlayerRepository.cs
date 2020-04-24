using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreatePlayer(Player player)
        {
            Create(player);
        }

        public void DeletePlayer(Player player)
        {
            Delete(player);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return FindAll().ToList();
        }

        public Player GetPlayerById(Guid player_Id)
        {
            return FindByCondition(p => p.id == player_Id).FirstOrDefault();
        }

        public IEnumerable<Player> GetPlayerBySession(int session_id)
        {
            return FindByCondition(p => p.session_id == session_id).ToList();
        }

        public void UpdatePlayer(Player player)
        {
            Update(player);
        }
    }
}
