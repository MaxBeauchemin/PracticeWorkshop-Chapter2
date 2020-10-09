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
            var response = new Response<CartesianCoordinates>();
            
            if(request == null)
            {
                response.Success = false;
                response.Message = "You failed to provide the necessary variables. Goodbye!!";
                return response;
            }

            if (request.DistanceFromOrigin == null)
            {
                response.Success = false;
                response.Message = "The Distance from origin was left empty. Goodbye!!";
                return response;
            }

            if (request.Angle == null)
            {
                response.Success = false;
                response.Message = "The angle provided was left empty. Goodbye!!";
                return response;
            }

            if (request.DistanceFromOrigin < 0)
            {
                response.Success = false;
                response.Message = "Distance from origin cannot be negative. Goodbye!!";
                return response;
            }

            response.Value = new CartesianCoordinates();

            response.Value.XLocation = 0;
            response.Value.YLocation = 0;

            var radians = request.Angle.Value * (Math.PI / 180);

            response.Value.XLocation = request.DistanceFromOrigin * Math.Cos(radians);
            response.Value.YLocation = request.DistanceFromOrigin * Math.Sin(radians);

            return response; 
        }
    }
}
