﻿using Domain.Models.ListModels;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Commands.SommarHusListCommands.UpdateSommarHusList
{
    public class UpdateSommarHusListByIdCommandHandler : IRequestHandler<UpdateSommarHusListByIdCommand, SommarHusArticleList>
    {
        private readonly ISommarHusListRepository? _sommarHusListRepository;

        public UpdateSommarHusListByIdCommandHandler(ISommarHusListRepository sommarHusListRepository)
        {
            _sommarHusListRepository = sommarHusListRepository ?? throw new ArgumentNullException(nameof(sommarHusListRepository));
        }
        public async Task<SommarHusArticleList> Handle(UpdateSommarHusListByIdCommand request, CancellationToken cancellationToken)
        {
            var sommarHusArticleListToUpdate = await _sommarHusListRepository!.GetSommarHusListByIdAsync(request.Id);
            if (sommarHusArticleListToUpdate != null)
            {
                await _sommarHusListRepository!.UpdateSommarHusListByIdAsync(request.Id);
                return sommarHusArticleListToUpdate;
            }
            return null!;
        }
    }

}