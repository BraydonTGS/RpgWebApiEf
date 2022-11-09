using System;
using System.Text.Json.Serialization;

namespace EFCoreRelationships.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string RpgClass { get; set; } = "Knight";

        // A Character Has One User //
        [JsonIgnore]
        public User User { get; set; }

        public int UserID { get; set; }

        public Weapon Weapon { get; set; }


    }
}

