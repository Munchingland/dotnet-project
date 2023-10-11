namespace Pri.GameLibrary.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<GameUser> Games { get; set; }
        public string Email { get; set; }
    }
}