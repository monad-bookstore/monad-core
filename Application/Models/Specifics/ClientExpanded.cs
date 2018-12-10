using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.DTOs;

namespace Application.Models.Specifics
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ClientExpanded
    {
        public int Id { get; set; }
        public byte AccessFlag { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ProfileDTO Profile { get; set; }

        public static ClientExpanded Create(Client client, Profile client_profile)
        {
            if (client == null)
            {
                return null;
            }

            var profile = new ProfileDTO();
            if (client_profile != null)
            {
                profile.Id = client_profile.Id;
                profile.ClientId = 0;
                profile.Name = client_profile.Name;
                profile.Surname = client_profile.Surname;
            }

            return new ClientExpanded
            {
                Id = client.Id,
                AccessFlag = client.AccessFlag,
                Email = client.Email,
                Username = client.Username,
                UpdatedAt = client.UpdatedAt,
                CreatedAt = client.CreatedAt,
                Profile = profile
            };
        }
    }
}
