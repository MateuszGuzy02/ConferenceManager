using AutoMapper;
using ConferenceManager.Dto;
using ConferenceManager.Participants;

namespace ConferenceManager;

public class ConferenceManagerApplicationAutoMapperProfile : Profile
{
    public ConferenceManagerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Participant, ParticipantDto>();
        CreateMap<CreateParticipantDto, Participant>();
        CreateMap<UpdateParticipantDto, Participant>();
    }
}
