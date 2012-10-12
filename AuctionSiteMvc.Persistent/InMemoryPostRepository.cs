using System;
using System.Collections.Generic;
using System.Linq;
using AuctionSiteMvc.Domain;

namespace AuctionSiteMvc.Persistent
{
    public class InMemoryPostRepository : IPostRepository

    {
        private IList<Post> _posts = new[] {
                                  new Post(0, "Post 1", "asdgdagssdharewywhdffdhafhadfhhafdhafdhfadhafahfdhafd", "Code 1",
                                           DateTime.Now.Date, DateTime.Now.Date.AddDays(1)),                           
                                  new Post(1, "Post 2", "4q4y6qyarayyryewaryrrejhuruqeureyqerreqqreqrerqyeyrqeyreqyqer", "Code 2",
                                           DateTime.Now.Date.AddDays(2), DateTime.Now.Date.AddDays(5)),                          
                                  new Post(2, "Post 3", "shdfhfdsryhryeyreyreyrewyrewwwwwwwwwwwwwwwwwwwwwwwwwwwwwfgdgasdas", "Code 3",
                                           DateTime.Now.Date.AddDays(3), DateTime.Now.Date.AddDays(6))
                              };
        /// <summary>
        /// List all Posts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> List()
        {
            return  _posts;
        }

        public Post GetById(int postId)
        {
            return _posts.FirstOrDefault(p => p.Id == postId);
        }

        public Post Save(Post post)
        {
           if (!post.Id.HasValue)
           {
               var newpost = new Post(_posts.Count, post.Title, post.Description, post.Owner, post.CreatedTime,
                                      post.EndTime);
               _posts.Add(newpost);
               return newpost;
           }

            var existing = _posts.FirstOrDefault(p => p.Id == post.Id);

            if (existing != null)
            {
                _posts.Remove(existing);
                _posts.Add(post);
            }

            return post;
        }
    }
}
