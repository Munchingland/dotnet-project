namespace Pri.GameLibrary.Core.Entities
{
    public class Developer : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}