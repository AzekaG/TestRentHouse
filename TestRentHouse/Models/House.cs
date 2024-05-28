namespace TestRentHouse.Models
{
    public class House
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Price { get; set; }

        public string? Description { get; set; }

        public int? Area { get; set; }

        public int? CountRoom { get; set; }

        public int? CountFloor { get; set; }

        public int? Subscribe { get; set; }

        public bool Is_Valid { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public List<Images>? Images_Path { get; set; }  //вернуться

        public District? District { get; set; }  //вернуться
        public User? Owner { get; set; }




        public House()
        {
            Images_Path = new List<Images>();
        }









    }
}
