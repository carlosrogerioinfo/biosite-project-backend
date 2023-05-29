using AutoMapper;
using Biosite.Core.Commands;
using Biosite.Core.Commands.Response;
using Biosite.Core.Library;
using Biosite.Domain.Commands.Request.Profile;
using Biosite.Domain.Commands.Request.User;
using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Transactions;
using FluentValidator;

namespace Biosite.Profile.Api.Commands.Handlers
{
    public class ProfileCommandHandler : Notifiable,
                                            ICommandHandler<UpdateProfileRequest>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public ProfileCommandHandler(IUserRepository repository, IMapper mapper, IUow uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        #region GET VERBS

        public async Task<ProfileResponse> Handle(Guid id)
        {
            var commandObject = await _repository.GetByIdAsync(id);

            return _mapper.Map<ProfileResponse>(commandObject);
        }

        public async Task<ProfileResponse> Handle(string email, string password)
        {
            var commandObject = await _repository.LoginUserAsync(email, SharedFunctions.EncryptPassword(password));

            if (commandObject is null)
                AddNotification("Login", "Usuário ou senha inválidos");

            if (!commandObject.Active || !commandObject.Verified)
                AddNotification("User", "Este e-mail não está ativo, é necessário ativar seu e-mail para logar no sistema.");

            if (!IsValid()) return default;

            await UpdateLoginDate(commandObject);

            return _mapper.Map<ProfileResponse>(commandObject);
        }

        #endregion

        #region POST, UPDATE AND DELETE VERBS

        public async Task<ICommandResult> Handle(UpdateProfileRequest command)
        {
            var profile = await _repository.GetByIdAsync(command.Id);

            var commandObject = new User(command.Id, command.Username, command.Password, command.ConfirmPassword, command.Email, command.Weight, command.Height,
                command.Gender, command.Birthdate, command.PlanId, command.Pregnant);

            if (profile.Active) commandObject.Activate();
            if (profile.Verified) commandObject.Verify();

            AddNotifications(commandObject.Notifications);

            if (!IsValid()) return default;

            _repository.Update(commandObject);
            await _uow.CommitAsync();

            var plan = _mapper.Map<PlanResponse>(profile.Plan);

            return new ProfileResponse(commandObject.Id, commandObject.Name, commandObject.Email, commandObject.Weight, commandObject.Height, commandObject.Gender, 
                commandObject.Birthdate, commandObject.LastLoginDate, plan, commandObject.IsPregnant);
        }

        #region POST, UPDATE AND DELETE VERBS
        
        #endregion

        private async Task UpdateLoginDate(User user)
        {
            user.UpdateLoginInfo();
            await _repository.UpdateAsync(user, true);

            await _uow.CommitAsync();
        }

        public async Task<ICommandResult> Handle(ProfileUploadImageRequest command)
        {
            byte[] imageBytes = Convert.FromBase64String(command.Base64ImageFile);
            await File.WriteAllBytesAsync(@$"d:\temp\{command.Id}.png", imageBytes);

            return default;
        }

        #endregion
    }
}