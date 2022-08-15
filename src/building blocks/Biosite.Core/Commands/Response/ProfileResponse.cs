using Biosite.Core.Enums;
using Biosite.Core.Library;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biosite.Core.Commands.Response
{
    public class ProfileResponse : ICommandResult
    {
        public ProfileResponse()
        {

        }

        public ProfileResponse(Guid id, string name, string email, double weight, double height, Gender gender, DateTime birthdate, DateTime lastLoginDate, PlanResponse planResponse, bool isPregnant = false)
        {
            Id = id;
            Name = name;
            Email = email;
            Weight = weight;
            Height = height.ToString("n2");
            Gender = gender;
            IsPregnant = isPregnant;
            Birthdate = birthdate;
            LastLoginDate = lastLoginDate;
            PlanResponse = planResponse;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Weight { get; set; }
        [JsonIgnore]
        public DateTime Birthdate { get; set; }
        public string Height { get; set; }
        public bool Fit { get; set; }
        public Gender Gender { get; set; }

        public bool IsPregnant { get; set; }
        public DateTime LastLoginDate { get; set; }
        public PlanResponse PlanResponse { get; set; }

        [NotMapped]
        public string Imc
        {
            get
            {
                return Math.Round(Weight / (Math.Pow(Convert.ToDouble(Height), 2)), 2).ToString("n2");
            }
        }
        [NotMapped]
        public string ImcResult
        {
            get
            {
                return SharedFunctions.GetImc(Convert.ToDecimal(Imc));
            }
        }
        [NotMapped]
        public int Age
        {
            get
            {
                return DateTime.UtcNow.Year - Birthdate.Year;
            }
        }
        [NotMapped]
        public string GenderDescription
        {
            get
            {
                return (Gender == Gender.F ? "Feminino" : "Masculino");
            }
        }
    }
}
