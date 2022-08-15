using AutoMapper;
using Biosite.Core.Commands.Response;
using Biosite.Core.Library;
using Biosite.Core.Model;
using Biosite.Domain.Entities;
using Biosite.Domain.Repositories;
using Biosite.Infrastructure.Transactions;
using FluentValidator;

namespace Biosite.Authentication.Api.Commands.Handlers
{
    public class UserCommandHandler : Notifiable
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public UserCommandHandler(IUserRepository repository, IMapper mapper, IUow uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        #region GET VERBS

        public async Task<UserResponse> Handle(string email, string password)
        {
            var commandObject = await _repository.LoginUserAsync(email, SharedFunctions.EncryptPassword(password));

            if (commandObject is null)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("Login", "Usuário ou senha inválidos"));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            if (!commandObject.Active || !commandObject.Verified)
            {
                var objectNotification = new Message();
                objectNotification.AddNotification(new Notification("User", "Este e-mail não está ativo, é necessário ativar seu e-mail para logar no sistema."));
                AddNotifications(objectNotification.Notifications);
                return null;
            }

            await UpdateLoginDate(commandObject);

            return _mapper.Map<UserResponse>(commandObject); ;
        }

        private async Task UpdateLoginDate(User user)
        {
            user.UpdateLoginInfo();
            await _repository.UpdateAsync(user, true);

            await _uow.CommitAsync();
        }

        #endregion

    }
}
