﻿namespace TestRentHouse.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string? Name { get; set; }
       
        public Status() 
        {
           
        }
        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
