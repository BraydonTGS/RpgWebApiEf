using System;
namespace EFCoreRelationships.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // One User Can Have Many Characters //
        public List<Character> Characters { get; set; }
    }
}

