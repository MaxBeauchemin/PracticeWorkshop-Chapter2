using Domain.DTOs.Common;
using Domain.DTOs.Math;
using System;

namespace Domain.Services
{
    public static class GeometryService
    {
        /// <summary>
        /// This method converts Polar Coordinates into Cartesian Coordinates
        /// See the following for explanation: https://en.wikipedia.org/wiki/Polar_coordinate_system#Converting_between_polar_and_Cartesian_coordinates
        /// Tip: User angle is provided in Degrees, but needs to be converted to Radians for math to work
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Response<CartesianCoordinates> PolarToCartesian(PolarCoordinates request)
        {

            //< PUT YOUR CODE HERE >



            return null; // <-- Delete this
        }
    }
}
