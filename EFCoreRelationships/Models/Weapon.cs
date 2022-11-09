using System;
namespace EFCoreRelationships.Models
{
    public class Weapon
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public int Damage { get; set; }

        // One to One Relationship //
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}

