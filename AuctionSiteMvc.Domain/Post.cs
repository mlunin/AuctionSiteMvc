using System;

namespace AuctionSiteMvc.Domain
{
    public class Post
    {

        public Post(int id, string title, string description, string owner,double price, string image, DateTime createdTime, DateTime endTime)
        {
            Id = id;
            Title = title;
            Description = description;
            Owner = owner;
            Price = price;
            Image = image;
            CreatedTime = createdTime;
            EndTime = endTime;
        }

        public int? Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }

        public string Owner { get; private set; }
        public double Price { get; private set; }

        public DateTime CreatedTime { get; private set; }

        public DateTime EndTime { get; private set; }
    }
}
