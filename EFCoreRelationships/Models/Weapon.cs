using System;
using System.Text.Json.Serialization;

namespace EFCoreRelationships.Models
{
    public class Weapon
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public int Damage { get; set; } = 10;

        // One to One Relationship //
        [JsonIgnore]
        public Character Character { get; set; }

        public int CharacterId { get; set; }
    }
}

