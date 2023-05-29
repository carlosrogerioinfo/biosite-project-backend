using AutoMapper;
using Biosite.Core.Commands;
using Biosite.Domain.Commands.Request.Biomarker;
using Biosite.Domain.Commands.Response;
using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Transactions;
using FluentValidator;

namespace Biosite.Biomarkers.Api.Commands.Handlers
{
    public class BiomarkerCommandHandler : Notifiable,
                                            ICommandHandler<RegisterBiomarkerRequest>,
                                            ICommandHandler<UpdateBiomarkerRequest>,
                                            ICommandHandler<DeleteBiomarkerRequest>
    {
        private readonly IBiomarkerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public BiomarkerCommandHandler(IBiomarkerRepository repository, IMapper mapper, IUow uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        #region GET VERBS

        public async Task<IEnumerable<BiomarkerResponse>> Handle()
        {
            var commandObject = await _repository.GetAllAsync();

            return _mapper.Map<List<BiomarkerResponse>>(commandObject);
        }

        public async Task<BiomarkerResponse> Handle(SelectBiomarkerByIdRequest command)
        {
            var commandObject = await _repository.GetByIdAsync(command.Id);

            if (commandObject is null)
                AddNotification ("Biomarcador", "Biomarcador não encontrado");

            if (!IsValid()) return default;

            return _mapper.Map<BiomarkerResponse>(commandObject);
        }

        public async Task<BiomarkerResponse> Handle(SelectBiomarkerByNameRequest command)
        {
            var commandObject = await _repository.GetByNameAsync(command.Name);

            if (commandObject is null)
                AddNotification("Biomarcador", "Biomarcador não encontrado");

            if (!IsValid()) return default;

            return _mapper.Map<BiomarkerResponse>(commandObject);
        }

        #endregion

        #region POST, UPDATE AND DELETE VERBS

        public async Task<ICommandResult> Handle(RegisterBiomarkerRequest command)
        {
            var commandObject = new Biomarker(default, command.Name, command.Description, command.Unity, command.BodyImageType, command.OptimizedValuesMin, command.OptimizedValuesMax, 
                command.AboveImpact, command.BelowImpact);

            AddNotifications(commandObject.Notifications);

            if (!IsValid()) return default;

            await _repository.AddAsync(commandObject);
            await _uow.CommitAsync();

            return new BiomarkerResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Unity, commandObject.BodyImageType, commandObject.AboveImpact, commandObject.BelowImpact);
        }

        public async Task<ICommandResult> Handle(UpdateBiomarkerRequest command)
        {
            var commandObject = new Biomarker(command.Id, command.Name, command.Description, command.Unity, command.BodyImageType, command.OptimizedValuesMin, command.OptimizedValuesMax,
                command.AboveImpact, command.BelowImpact);

            AddNotifications(commandObject.Notifications);

            if (!IsValid()) return default;

            _repository.Update(commandObject);
            await _uow.CommitAsync();

            return new BiomarkerResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Unity, commandObject.BodyImageType, commandObject.AboveImpact, commandObject.BelowImpact);
        }

        public async Task<ICommandResult> Handle(DeleteBiomarkerRequest command)
        {
            var commandObject = await _repository.GetByIdAsync(command.Id);

            if (commandObject is null)
                AddNotification("Biomarcador", "Biomarcador não encontrado");

            if (!IsValid()) return default;

            _repository.Delete(commandObject);
            await _uow.CommitAsync();

            return new BiomarkerResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Unity, commandObject.BodyImageType, commandObject.AboveImpact, commandObject.BelowImpact);
        }

        #endregion
    }
}
