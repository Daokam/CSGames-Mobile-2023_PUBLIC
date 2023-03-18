using System;
namespace CSGames_Mobile.Services
{
    public class TransitItem
    {
        public int Id { get; set; }
        public int Frequency { get; set; }
        public int Line { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }

        public TransitItem(int id, int frequency, int line, string description, string schedule)
        {
            Id = id;
            Frequency = frequency;
            Line = line;
            Description = description;
            Schedule = schedule;
        }
    }
}

