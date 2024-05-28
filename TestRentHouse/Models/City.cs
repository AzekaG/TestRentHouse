﻿namespace TestRentHouse.Models
{
    public class City
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<District>? Districts { get; set; }

        public City()
        {
            Districts = new List<District>();

        }
    }
}
