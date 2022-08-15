using Biosite.Core.Commands;
using Biosite.Core.Enums;
using System;

namespace Biosite.Domain.Commands.Request.User
{
    public class RegisterUserRequest : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public Gender Gender { get; set; }
        public bool Pregnant { get; set; }
        public DateTime Birthdate { get; set; }
        public Guid PlanId { get; set; }
    }
}
