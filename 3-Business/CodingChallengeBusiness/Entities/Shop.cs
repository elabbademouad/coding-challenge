namespace CodingChallengeBusiness.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public Position Position { get; set; }

    }
}