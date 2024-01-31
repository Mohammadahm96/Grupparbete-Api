using Infrastructure.Interfaces;
using MediatR;

namespace Application.Query.SommarHusList.GetAllById
{
    public class GetSommarHusIdAndNamesHandler : IRequestHandler<GetSommarHusIdAndNamesQuery, List<object>>
    {
        private readonly ISommarHusListRepository _sommarHusListRepository;

        public GetSommarHusIdAndNamesHandler(ISommarHusListRepository sommarHusListRepository)
        {
            _sommarHusListRepository = sommarHusListRepository;
        }

        public async Task<List<object>> Handle(GetSommarHusIdAndNamesQuery request, CancellationToken cancellationToken)
        {
            var result = await _sommarHusListRepository.GetIdAndNameAsync();
            return result.Cast<object>().ToList();
        }
    }
}