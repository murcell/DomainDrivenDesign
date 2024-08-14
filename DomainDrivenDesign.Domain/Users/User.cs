using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Users
{
	public sealed class User
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string City { get; set; } = null!;
		public string Street { get; set; } = null!;
		public string FullAddress { get; set; } = null!;
		public string PostalCode { get; set; } = null!;

	}
}
