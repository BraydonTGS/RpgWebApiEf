using System;
namespace EFCoreRelationships.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        // One User Can Have Many Characters //
        public List<Character> Characters { get; set; }
    }
}

