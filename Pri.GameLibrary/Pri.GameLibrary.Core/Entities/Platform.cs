namespace Pri.GameLibrary.Core.Entities
{
    public class Platform : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
