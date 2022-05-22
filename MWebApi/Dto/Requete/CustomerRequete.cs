using System;
using System.Collections.Generic;

namespace MWebApi.Dto.Requete
{
    public partial class CustomerRequete
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int AddressId { get; set; }
        public virtual AddressRequete Address { get; set; } = default!;
    }
}
