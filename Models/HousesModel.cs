namespace WebApplication2.Models
{
    public class HousesModel
    {
        public int Price { get; set; } = 0;
        public DateTime PublicationDate { get; set; } = DateTime.Now;
        public double Geo_Lat { get; set; } = 0;
        public double Geo_Lon { get; set; } = 0;
        public int Region { get; set; } = 0;
        public int Building_Type { get; set; } = 0;
        public int FloorNum { get; set; } = 0;
        public int TotalFloor { get; set; } = 0;
        public int Rooms { get; set; } = 0;
        public double Area { get; set; } = 0;
        public int Object_Type { get; set; } = 0;
        public int Id { get; set; } = 0;
        public int status { get; set; } = 0;
        public byte[] Photopath { get; set; } = {0};
        /*
         * price
         * publicationDate
         * geo_lat
         * geo_lon
         * region
         * building_type
         * floornum
         * totalFloor
         * rooms
         * area
         * object
         * id
         */
    }
}
