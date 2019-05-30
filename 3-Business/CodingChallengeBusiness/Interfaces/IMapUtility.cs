using CodingChallengeBusiness.Entities;

namespace CodingChallengeBusiness.Interfaces
{
    /// <summary>
    ///  interface for manage map services
    /// </summary>
    public interface IMapUtility
    {
        /// <summary>
        ///  calculate distance between 2 position
        /// </summary>
        /// <param name="from">represents first position latitude,longitude </param>
        /// <param name="to">position second represents  latitude,longitude</param>
        /// <returns>double</returns>
        double CalculateDistance(Position from, Position to);
    }
}