using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Repositories
{
    public class NetworkRepository : INetworkRepository
    {
        private readonly ApplicationDbContext _context;

        public NetworkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFriendConnection(FriendConnection friendConnection)
        {
            _context.FriendConnections.Add(friendConnection);
            _context.SaveChanges();
        }

        public void DeleteFriendRequest(FriendRequest request)
        {
            _context.FriendRequests.Remove(request);
            _context.SaveChanges();
        }

        public IEnumerable<FriendConnection> GetFriendConnectionsForSingleUser(User sessionUser)
        {
            return _context.FriendConnections
                .Where(x => x.FirstUserId.Equals(sessionUser.Id) ||
                x.SecondUserId.Equals(sessionUser.Id));
        }

        public FriendConnection GetFriendConnectionForUsers(int firstUserId, int secondUserId)
        {
            return _context.FriendConnections.
                Include(x => x.FirstUser).
                Include(x => x.SecondUser).
                FirstOrDefault(x =>
                (x.FirstUserId.Equals(firstUserId) && x.SecondUserId.Equals(secondUserId)) ||
                (x.FirstUserId.Equals(secondUserId) && x.SecondUserId.Equals(firstUserId)));

        }

        public IEnumerable<FriendRequest> GetFriendRequests(User sessionUser)
        {
            return _context.FriendRequests
                .Include(x => x.FromUser)
                .Where(x => x.ToUserId.Equals(sessionUser.Id))
                .ToList();
        }

        public FriendRequest GetRequestById(int requestId)
        {
            return _context.FriendRequests.FirstOrDefault(x => 
            x.Id.Equals(requestId));
        }

        public FriendRequest GetRequestForUsers(int sessionUserId, int targetUserId)
        {
            return _context.FriendRequests
                .FirstOrDefault(x=> x.FromUserId.Equals(sessionUserId) 
                && x.ToUserId.Equals(targetUserId) ||
                x.FromUserId.Equals(targetUserId) 
                && x.ToUserId.Equals(sessionUserId));
        }

        public void SendFriendRequest(FriendRequest request)
        {
            _context.FriendRequests.Add(request);
            _context.SaveChanges();
        }
    }
}
;