using ConferenceManager.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ConferenceManager.Participants
{
    public class ParticipantAppService : ApplicationService, IParticipantAppService
    {
        private readonly IRepository<Participant, Guid> _repository;

        public ParticipantAppService(IRepository<Participant, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<List<ParticipantDto>> GetListAsync()
        {
            var participants = await _repository.GetListAsync();
            return ObjectMapper.Map<List<Participant>, List<ParticipantDto>>(participants);
        }

        public async Task<ParticipantDto> GetAsync(Guid id)
        {
            var participant = await _repository.GetAsync(id);
            return ObjectMapper.Map<Participant, ParticipantDto>(participant);
        }

        public async Task<ParticipantDto> CreateAsync(CreateParticipantDto input)
        {
            var exists = await _repository.AnyAsync(p => p.Email == input.Email);
            if (exists)
                throw new UserFriendlyException($"A participant with email {input.Email} already exists.");

            var participant = ObjectMapper.Map<CreateParticipantDto, Participant>(input);
            await _repository.InsertAsync(participant);
            return ObjectMapper.Map<Participant, ParticipantDto>(participant);
        }

        public async Task<ParticipantDto> UpdateAsync(Guid id, UpdateParticipantDto input)
        {
            var participant = await _repository.GetAsync(id);

            if(participant.Email != input.Email)
            {
                var exists = await _repository.AnyAsync(p => p.Email == input.Email);
                if (exists)
                    throw new UserFriendlyException($"A participant with email {input.Email} already exists.");
            }

            ObjectMapper.Map(input, participant);
            await _repository.UpdateAsync(participant);
            return ObjectMapper.Map<Participant, ParticipantDto>(participant);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
