using System;
using System.Collections.Generic;
using System.Linq;
using AuctionSiteMvc.Domain;

namespace AuctionSiteMvc.Persistent
{
    public class InMemoryPostRepository : IPostRepository

    {
        private IList<Post> _posts = new[] {
                                  new Post(0, "Sennheiser HD449 Over-Ear Headphones", 
                                      "Sennheiser HD 449 Headphones reproduces precise and detailed sound that helps you rediscover you music all over again. "+
                                      "The leatherette ear pads and closed-cup design block out background noise, allowing you to listen at a safer level while allowing you"+
                                      " to appreciate the enhanced detail this headphone provides. The included cable extension adds flexibility on-demand for listening on-the-move, at work or at home.",
                                      "George Chen", 169.00, "product1.jpg",
                                           DateTime.Now.Date, DateTime.Now.Date.AddDays(1)),                           
                                  new Post(1, 
                                      "TomTom VIA 1405M GPS w/ Lifetime Maps", 
                                      "Hit the road street-smart and style-savvy. The new, super-slim TomTom VIA series holds the latest navigation technology, in a fresh, sleek design including an integrated Fold & Go EasyPort Mount. Travel confidently with superior routing and the most accurate, dependable maps in the GPS industry. In fact, TomTom gives you one million more miles of mapped roads in the US**. The VIA range offers a large array of unique features--like Lifetime Traffic and Map Updates, Bluetooth hands-free calling and natural voice recognition with one-shot destination address entry--all at affordable prices.", 
                                      "Monster coder",175.99, "product2.jpg",
                                           DateTime.Now.Date.AddDays(2), DateTime.Now.Date.AddDays(5)),                          
                                  new Post(2, 
                                      "Samsung Galaxy 10.1 \" Tablet (Wi-Fi)",
                                      "Showcasing a 10.1-inch widescreen HD display and a dual-core processor for stunning detail and speed, the Galaxy Tab 10.1 delivers sharper movies, better game graphics, and crystal-clear video chats. Surf the web in its full glory with Adobe Flash compatibility and WiFi and Bluetooth connectivity. The Android 3.1 Honeycomb OS provides open access to over 200,000 Android Market apps, giving you the freedom to customize your Tab however you please. At 1.25 pounds, this sleek, 0.34-inch-thick tablet is designed for premium mobile computing around the house and on the go.", "Micheal", 519.99, "product3.jpg",
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
               var newpost = new Post(_posts.Count, post.Title, post.Description, post.Owner, post.Price, post.Image,post.CreatedTime,
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
