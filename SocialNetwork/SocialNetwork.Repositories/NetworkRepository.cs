﻿using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<FriendRequest> GetFriendRequests(User sessionUser)
        {
            return _context.FriendRequests
                .Include(x => x.FromUser)
                .Where(x => x.ToUserId.Equals(sessionUser.Id))
                .ToList();
        }

        public void SendFriendRequest(FriendRequest request)
        {
            _context.FriendRequests.Add(request);
            _context.SaveChanges();
        }
    }
}
;