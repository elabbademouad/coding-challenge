namespace CodingChallengeBusiness.Interfaces
{
    public interface IMapUtility
    {
        /// <summary>
        ///  calculate distance between 2 position
        /// </summary>
        /// <param name="origine">represents  latitude,longitude of origine </param>
        /// <param name="destination">represents  latitude,longitude of destination</param>
        /// <returns>-1 : mis calculation</returns>
        decimal CalculateDistance(string origine,string destination);
    }
}