namespace inspectorApi.Models
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; } = "prodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelegents { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}