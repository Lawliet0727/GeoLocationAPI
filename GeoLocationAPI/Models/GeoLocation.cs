using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GeoLocationAPI.Models
{
    public class GeoLocation
    {
        
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "Location", ItemConverterType = typeof(NetTopologySuite.IO.Converters.GeometryConverter))]
        public Geometry Location { get; set; }

    }
}
