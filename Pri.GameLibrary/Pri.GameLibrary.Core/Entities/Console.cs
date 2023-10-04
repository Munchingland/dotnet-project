namespace Pri.GameLibrary.Core.Entities
{
    public class Console : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
