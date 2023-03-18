using System;
namespace CSGames_Mobile.Services
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }

        public NewsItem(int id, string message, string title, int type)
        {
            Id = id;
            Message = message;
            Title = title;
            Type = type;
        }
    }
}

