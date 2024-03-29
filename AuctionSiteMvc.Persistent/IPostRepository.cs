﻿using System.Collections.Generic;
using AuctionSiteMvc.Domain;

namespace AuctionSiteMvc.Persistent
{
    public interface IPostRepository
    {
        /// <summary>
        /// List all Posts
        /// </summary>
        /// <returns></returns>
        IEnumerable<Post> List();

        Post GetById(int postId);
        Post Save(Post post);
    }
}
