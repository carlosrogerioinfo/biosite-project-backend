using Biosite.Core.Entities;
using Biosite.Core.Enums;
using Biosite.Core.Library;
using FluentValidator;
using System;

namespace Biosite.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(Guid id, string name, string password, string confirmPassword, string email, double weight, double height, Gender gender,
            DateTime birthdate, Guid planId, bool isPregnant = false)
        {
            if (id != Guid.Empty) this.Id = id;
            Name = name;
            Password = SharedFunctions.EncryptPassword(password);
            Email = email;
            Weight = weight;
            Height = height;
            Gender = gender;
            IsPregnant = isPregnant;
            Birthdate = birthdate;
            PlanId = planId;
            Active = false;
            Verified = false;
            LastLoginDate = DateTime.Now;
            VerificationCode = null;
            ActivationCode = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 5).ToUpper();
            LastAuthorizationCodeRequest = DateTime.Now.AddMinutes(5);

            //Validations for notifications events here
            new ValidationContract<User>(this)
                .IsRequired(x => x.Name, "O nome deve ser informado")
                .IsRequired(x => x.Email, "O email deve ser informado")
                .IsRequired(x => x.Name, "O nome deve ser informado")
                .IsGreaterThan(x => x.Height, 1, "A altura deve ser informada")
                .IsGreaterThan(x => x.Weight, 2, "O peso deve ser informado e deve ser maior que 2kg")
                .IsRequired(x => x.Password, "A senha deve ser informada")
                .AreEquals(x => x.Password, SharedFunctions.EncryptPassword(confirmPassword), "As senhas não coincidem");
        }

        //Properties
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public double Weight { get; private set; }
        public double Height { get; private set; }
        public Gender Gender { get; set; }
        public bool IsPregnant { get; private set; }
        public DateTime Birthdate { get; private set; }
        public bool Verified { get; private set; }
        public string VerificationCode { get; private set; }
        public string ActivationCode { get; private set; }
        public DateTime LastLoginDate { get; private set; }
        public DateTime LastAuthorizationCodeRequest { get; private set; }

        //Relationchip 1:N
        public Guid PlanId { get; set; }
        public Plan Plan { get; set; }

        //Methods
        public void Activate() => Active = true;
        public void Verify() => Verified = true;
        public void Deactivate() => Active = false;
        public void UpdateLoginInfo() => LastLoginDate = DateTime.Now;

        public string GenerateAutorizationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
        }

        public bool Authenticate(string email, string password)
        {
            if (Email.Equals(email) && Password.Equals(SharedFunctions.EncryptPassword(password)))
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }
    }
}
