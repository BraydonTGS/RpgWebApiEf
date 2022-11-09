using System;
namespace EFCoreRelationships.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string RpgClass { get; set; } = null!;

        // A Character Has One User //
        public User User { get; set; }

        public int UserID { get; set; }

    }
}

