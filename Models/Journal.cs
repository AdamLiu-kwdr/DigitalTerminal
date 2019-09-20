using System;
using System.Collections.Generic;

namespace CyberArtDemo.Models
{
    public class Journal
    {
        public string EntryId;
        public string EntryTitle;
        public string Location;
        public string Author;
        public DateTime EntryTime; 
        public List<string> Contents; //Array for different pages
    }
}