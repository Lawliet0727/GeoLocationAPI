using GeoLocationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace GeoLocationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpPost]
        public IActionResult AddLocation()
        {

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var currentLocation = geometryFactory.CreatePoint(new Coordinate(-122.121512, 47.6739882));

            //GeoLocation geoLocation = new GeoLocation() { Id = 1, Name = "Manila", Location = currentLocation };

            var s = GeoJsonSerializer.Create(new Newtonsoft.Json.JsonSerializerSettings(),
                NtsGeometryServices.Instance.CreateGeometryFactory(31467));

            var sb = new System.Text.StringBuilder();

            s.Serialize(new Newtonsoft.Json.JsonTextWriter(new System.IO.StringWriter(sb)), currentLocation);
            System.Console.WriteLine(sb.ToString());

            var myModelItem2 =
                s.Deserialize<Point>(
                    new Newtonsoft.Json.JsonTextReader(new System.IO.StringReader(sb.ToString())));

            return Ok(myModelItem2);     
        }


    }
}
