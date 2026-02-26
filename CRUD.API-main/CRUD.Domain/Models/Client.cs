using System;

namespace CRUD.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }

        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Uf { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
