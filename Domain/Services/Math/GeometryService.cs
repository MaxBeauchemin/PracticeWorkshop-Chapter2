using Domain.DTOs.Common;
using Domain.DTOs.Math;
using Domain.Resources;
using Domain.Services.Common;
using Domain.Types;
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
            var cMethodName = "GeometryService.PolarToCartesian(..)";

            try
            {
                if (request == null)
                {
                    throw new ArgumentException(DomainResource.NullRequest);
                }

                if (request.DistanceFromOrigin == null)
                {
                    throw new ArgumentException(string.Format(DomainResource.XCannotBeNullOrEmpty, "Distance From Origin"));
                }

                if (request.Angle == null)
                {
                    throw new ArgumentException(string.Format(DomainResource.XCannotBeNullOrEmpty, "Angle"));
                }

                if (request.DistanceFromOrigin < 0)
                {
                    throw new ArgumentException(string.Format(DomainResource.XCannotBeNegative, "Distance From Origin"));
                }

                response.Value = new CartesianCoordinates();

                response.Value.XLocation = 0;
                response.Value.YLocation = 0;

                var radians = request.Angle.Value * (Math.PI / 180);

                response.Value.XLocation = request.DistanceFromOrigin * Math.Cos(radians);
                response.Value.YLocation = request.DistanceFromOrigin * Math.Sin(radians);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                var logData = new
                {
                    Request = request,
                    Exception = ex
                };

                var msg = string.Format(DomainResource.ErrorOccuredInXY, cMethodName, ex.Message);

                LoggerService.Log(LogArea.Math, GeneralHelper.ExceptionLogType(ex), msg, logData);
            }

            return response; 
        }
    }
}
