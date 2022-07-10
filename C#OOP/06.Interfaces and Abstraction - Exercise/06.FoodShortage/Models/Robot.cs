﻿namespace _06.FoodShortage.Models
{         
    using _06.FoodShortage.Interfaces;
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; private set; }
        public string Id { get; private set; }
    }
}