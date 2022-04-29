using System;

namespace PersonalProjectClassLibrary.Models
{
    public record AddressModel
    {
        public Guid Id { get; init; }

        public string Street { get; init; }

        public string City { get; init; }

        public Guid EmployeeId { get; init; }

        public override string ToString()
        {
            return $"{City} - {Street}";
        }
    }
}