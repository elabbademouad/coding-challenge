using System;

namespace CodingChallengeBusiness.Entities
{
    /// <summary>
    /// Base entity contains properties that well be shared with all entities
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}