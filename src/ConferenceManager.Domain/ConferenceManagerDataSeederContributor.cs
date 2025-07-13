using ConferenceManager.Participants;
using ConferenceManager.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ConferenceManager
{
    public class ConferenceManagerDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Participant, Guid> _participantRepository;

        public ConferenceManagerDataSeederContributor(IRepository<Participant, Guid> participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _participantRepository.CountAsync() > 0)
                return;

            await _participantRepository.InsertAsync(new Participant
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalski@example.com",
                Phone = "123456789",
                TicketType = TicketType.Normal
            },
            autoSave: true
            );

            await _participantRepository.InsertAsync(new Participant
            {
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "anna.nowak@example.com",
                Phone = "987654321",
                TicketType = TicketType.Vip
            },
            autoSave: true
            );
        }
    }
}
