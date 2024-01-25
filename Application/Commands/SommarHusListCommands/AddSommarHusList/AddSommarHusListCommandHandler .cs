using Application.Commands.SommarHusLists.AddSommarHusList;
using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Commands.SommarHusListCommands.AddSommarHusList
{
    public class AddSommarHusListCommandHandler : IRequestHandler<AddSommarHusListCommand, SommarHusArticleList>
    {
        private readonly ISommarHusListRepository _sommarHusListRepository;

        public AddSommarHusListCommandHandler(ISommarHusListRepository sommarHusListRepository)
        {
            _sommarHusListRepository = sommarHusListRepository;
        }

        public async Task<SommarHusArticleList> Handle(AddSommarHusListCommand request, CancellationToken cancellationToken)
        {
            SommarHusArticleList sommarHusListToCreate = new SommarHusArticleList
            {
                SommarHusId = Guid.NewGuid(),
                HouseName = request.NewSommarHusList.HouseName,
                ArticleName = " ",
                ArticleQuantity = 2,
                IsAvailable = true,
            };
            await _sommarHusListRepository.CreateSommarHusListAsync(sommarHusListToCreate);
            return sommarHusListToCreate;
        }
    }
}
