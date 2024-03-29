﻿namespace CeciMT.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string Locality { get; set; }

        public int Number { get; set; }

        public string Complement { get; set; }

        public string Uf { get; set; }
    }
}
