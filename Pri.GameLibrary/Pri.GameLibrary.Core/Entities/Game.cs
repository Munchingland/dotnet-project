namespace Pri.GameLibrary.Core.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public int DeveloperId { get;set; }
        public Developer Developer { get; set; }
        public ICollection<Platform> Platforms { get; set; }
        public ICollection<GameUser> Users { get; set; }
    }
}
