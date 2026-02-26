using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Dto.Client
{
    public class ClientResponseDto
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
