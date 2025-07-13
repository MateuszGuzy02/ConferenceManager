using ConferenceManager.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ConferenceManager.Participants
{
    public interface IParticipantAppService : IApplicationService
    {
        Task<List<ParticipantDto>> GetListAsync();
        Task<ParticipantDto> GetAsync(Guid id);
        Task<ParticipantDto> CreateAsync(CreateParticipantDto input);
        Task<ParticipantDto> UpdateAsync(Guid id, UpdateParticipantDto input);
        Task DeleteAsync(Guid id);
    }
}
