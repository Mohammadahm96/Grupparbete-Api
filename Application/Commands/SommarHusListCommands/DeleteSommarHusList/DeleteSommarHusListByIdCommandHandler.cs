using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Commands.SommarHusLists.DeleteSommarHusList
{
    public class DeleteSommarHusListByIdCommandHandler : IRequestHandler<DeleteSommarHusListByIdCommand, SommarHusArticleList>
    {
        private readonly ISommarHusListRepository _sommarHusListRepository;
        public DeleteSommarHusListByIdCommandHandler(ISommarHusListRepository sommarHusListRepository)
        {
            _sommarHusListRepository = sommarHusListRepository ?? throw new ArgumentNullException(nameof(sommarHusListRepository));
        }
        public async Task<SommarHusArticleList> Handle(DeleteSommarHusListByIdCommand request, CancellationToken cancellationToken)
        {
            var sommarHusListToDelete = await _sommarHusListRepository!.GetSommarHusListByIdAsync(request.Id);
            if (sommarHusListToDelete != null)
            {
                await _sommarHusListRepository!.DeleteSommarHusListByIdAsync(request.Id);
                return sommarHusListToDelete;
            }
            return null!;
        }
    }
}
