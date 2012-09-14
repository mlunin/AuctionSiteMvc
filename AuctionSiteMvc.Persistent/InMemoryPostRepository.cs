using System;
using System.Collections.Generic;
using AuctionSiteMvc.Domain;

namespace AuctionSiteMvc.Persistent
{
    public class InMemoryPostRepository : IPostRepository

    {
        /// <summary>
        /// List all Posts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> List()
        {
            return  new[] {
                           new Post(0, "Post 1", "asdgdagssdharewywhdffdhafhadfhhafdhafdhfadhafahfdhafd", "Code 1",
                                    DateTime.Now.Date, DateTime.Now.Date.AddDays(1)),                           
                           new Post(0, "Post 2", "4q4y6qyarayyryewaryrrejhuruqeureyqerreqqreqrerqyeyrqeyreqyqer", "Code 2",
                                    DateTime.Now.Date.AddDays(2), DateTime.Now.Date.AddDays(5)),                          
                           new Post(0, "Post 3", "shdfhfdsryhryeyreyreyrewyrewwwwwwwwwwwwwwwwwwwwwwwwwwwwwfgdgasdas", "Code 3",
                                    DateTime.Now.Date.AddDays(3), DateTime.Now.Date.AddDays(6))
                       };
        }
    }
}
