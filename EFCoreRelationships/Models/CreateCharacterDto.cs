using System;
namespace EFCoreRelationships.Models
{
    public class CreateCharacterDto
    {
        // Data Transfer Object // Not mapped to the DB but we use it to transfer data. 
        public string Name { get; set; } = "Character";

        public string RpgClass { get; set; } = "Knight";

        public int UserId { get; set; }
    }
}

