using System;
using System.Collections.Generic;

namespace MWebApi.Dto.Requete
{
    public partial class AddressRequete
    {
        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
