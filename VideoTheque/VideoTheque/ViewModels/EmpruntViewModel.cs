using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace VideoTheque.ViewModels
{
    public class EmpruntViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("director")]
        public string Director { get; set; }
        [JsonProperty("scenarist")]
        public string Scenarist { get; set; }
        [JsonProperty("duration")]
        public long Duration { get; set; }
        [JsonProperty("support")]
        public string Support { get; set; }
        [JsonProperty("age_rating")]
        public string AgeRating { get; set; }
        [JsonProperty("genre")]
        public string Genre { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("first_actor")]
        public string FirstActor { get; set; }
    }
}