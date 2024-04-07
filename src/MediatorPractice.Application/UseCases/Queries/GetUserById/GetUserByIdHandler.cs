using MediatorPractice.Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPractice.Application.UseCases.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        public readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindUserByIdAsync(request.Id, cancellationToken);

            if (user is null)
            {
                throw new Exception("User not found");
            }

            return new GetUserByIdResponse()
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
