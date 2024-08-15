using DomainDrivenDesign.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.Features.Users.GetAllUser
{
	public sealed record GetAllUsersQuery():IRequest<List<User>>;

	internal sealed record GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
	{
		private readonly IUserRepository _userRepository;

		public GetAllUsersQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
		{
			return await _userRepository.GetAllAsync(cancellationToken);
		}
	}
}
