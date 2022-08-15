using Biosite.Core.Commands;
using Microsoft.AspNetCore.Http;
using System;

namespace Biosite.Domain.Commands.Request.Profile
{
    public class ProfileUploadImageRequest : ICommand
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Base64ImageFile { get; set; }
    }
}
