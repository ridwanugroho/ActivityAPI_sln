using System;

namespace ActivityAPI.Models
{
    public class Activity
    {
        public int id{get; set;}
        public string Name{get; set;}
        public string Desc{get; set;}
        public bool Status{get; set;}
        public DateTime CreatedAt{get; set;}
        public DateTime EditedAt{get; set;}
    }
}