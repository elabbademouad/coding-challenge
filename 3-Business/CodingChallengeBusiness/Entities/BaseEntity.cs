using CodingChallengeBusiness.Interfaces;

namespace CodingChallengeBusiness.Entities
{
    /// <summary>
    /// Base entity contains properties that well be shared with all entities
    /// </summary>
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}