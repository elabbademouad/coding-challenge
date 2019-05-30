using System.IO;
using System.Net;
using CodingChallengeBusiness.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using GeoCoordinatePortable;
using System.Text;
using CodingChallengeBusiness.Entities;

namespace CodingChallengePersistance.Utilities
{
    /// <summary>
    /// implementation of IMapUtility using GeoCoordinate
    /// </summary>
    public class MapUtility : IMapUtility
    {

        public double CalculateDistance(Position from, Position to)
        {
            var origineCord = new GeoCoordinate(from.Latitude, from.Longitude);
            var destinationCord = new GeoCoordinate(to.Latitude, to.Longitude);
            return origineCord.GetDistanceTo(destinationCord);
        }
    }
}