using System;
using System.Collections.Generic;

namespace MWebApi.Dtos.Request
{
    public partial class CustomerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int AddressId { get; set; }
        public virtual AddressRequest Address { get; set; } = default!;
    }
}
