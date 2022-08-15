using AutoMapper;
using Biosite.Core.Commands;
using Biosite.Core.Model;
using Biosite.Domain.Commands.Request.Organ;
using Biosite.Domain.Commands.Response;
using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Transactions;
using FluentValidator;

namespace Biosite.Organs.Api.Commands.Handlers
{
    public class OrganCommandHandler : Notifiable,
                                            ICommandHandler<RegisterOrganRequest>,
                                            ICommandHandler<UpdateOrganRequest>,
                                            ICommandHandler<DeleteOrganRequest>
    {
        private readonly IOrganRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public OrganCommandHandler(IOrganRepository repository, IMapper mapper, IUow uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        #region GET VERBS

        public async Task<IEnumerable<OrganResponse>> Handle()
        {
            var commandObject = await _repository.GetAllAsync();

            return _mapper.Map<List<OrganResponse>>(commandObject);
        }

        public async Task<OrganResponse> Handle(SelectOrganByIdRequest command)
        {
            var commandObject = await _repository.GetByIdAsync(command.Id);

            if (commandObject is null)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("Órgão", "Órgão não encontrado"));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            return _mapper.Map<OrganResponse>(commandObject);
        }

        public async Task<OrganResponse> Handle(SelectOrganByNameRequest command)
        {
            var commandObject = await _repository.GetByNameAsync(command.Name);

            return _mapper.Map<OrganResponse>(commandObject);
        }

        #endregion


        #region POST, UPDATE AND DELETE VERBS

        public async Task<ICommandResult> Handle(RegisterOrganRequest command)
        {
            var commandObject = new Organ(default, command.Name, command.Description, command.Svg);

            AddNotifications(commandObject.Notifications);

            if (!IsValid()) return default;

            await _repository.AddAsync(commandObject);
            await _uow.CommitAsync();

            return new OrganResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Svg);
        }

        public async Task<ICommandResult> Handle(UpdateOrganRequest command)
        {
            var commandObject = new Organ(command.Id, command.Name, command.Description, command.Svg);

            AddNotifications(commandObject.Notifications);

            if (!IsValid()) return default;

            _repository.Update(commandObject);
            await _uow.CommitAsync();

            return new OrganResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Svg);
        }

        public async Task<ICommandResult> Handle(DeleteOrganRequest command)
        {
            var commandObject = await _repository.GetByIdAsync(command.Id);

            if (commandObject is null)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("Órgão", "Órgão não encontrado"));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            _repository.Delete(commandObject);
            await _uow.CommitAsync();

            return new OrganResponse(commandObject.Id, commandObject.Name, commandObject.Description, commandObject.Svg);
        }

        #endregion
    }
}
