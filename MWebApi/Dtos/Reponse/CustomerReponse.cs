using System;
using System.Collections.Generic;

namespace MWebApi.Dtos.Reponse
{
    public partial class CustomerReponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int AddressId { get; set; }

        public virtual AddressReponse? Address { get; set; }
        public virtual ICollection<OrderReponse>? Orders { get; set; } = default!;
    }
}
