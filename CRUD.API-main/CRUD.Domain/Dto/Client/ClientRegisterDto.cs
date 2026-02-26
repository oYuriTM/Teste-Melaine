using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Dto.Client
{
    public class ClientRegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }

        public string? Number { get; set; }
        public string? Complement { get; set; }
    }
}
