using ConferenceManager.Dto;
using ConferenceManager.EntityFrameworkCore;
using ConferenceManager.Tickets;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Xunit;

namespace ConferenceManager.Participants
{
    public class ParticipantAppServiceIntegrationTests : ConferenceManagerEntityFrameworkCoreTestBase
    {
        private readonly IParticipantAppService _service;

        public ParticipantAppServiceIntegrationTests()
        {
            _service = GetRequiredService<IParticipantAppService>();
        }

        [Fact]
        public async Task Should_Create_Participant()
        {
            var input = new CreateParticipantDto
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jKowalski@example.com",
                Phone = "123456789",
                TicketType = TicketType.Normal
            };

            var result = await _service.CreateAsync(input);

            result.ShouldNotBeNull();
            result.Email.ShouldBe(input.Email);
        }

        [Fact]
        public async Task Should_Update_Participant()
        {
            var createInput = new CreateParticipantDto
            {
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "aNowak@example.com",
                Phone = "987654321",
                TicketType = TicketType.Vip
            };

            var created = await _service.CreateAsync(createInput);

            var updateInput = new UpdateParticipantDto
            {
                FirstName = "Anna Maria",
                LastName = "Nowak",
                Email = "aNowak@example.com",
                Phone = "987654321",
                TicketType = TicketType.Vip
            };

            var updated = await _service.UpdateAsync(created.Id, updateInput);

            updated.ShouldNotBeNull();
            updated.Id.ShouldBe(created.Id);
            updated.FirstName.ShouldBe(updateInput.FirstName);
        }

        [Fact]
        public async Task UpdateAsync_NonExistingId_ThrowsEntityNotFoundException()
        {
            var nonExistingId = Guid.NewGuid();

            var updateInput = new UpdateParticipantDto
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@example.com",
                Phone = "123456789",
                TicketType = TicketType.Normal
            };

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.UpdateAsync(nonExistingId, updateInput));
        }

        [Fact]
        public async Task Should_Delete_Participant()
        {
            var createInput = new CreateParticipantDto
            {
                FirstName = "Marek",
                LastName = "Zieliński",
                Email = "marek.zielinski@example.com",
                Phone = "123123123",
                TicketType = TicketType.Normal
            };

            var created = await _service.CreateAsync(createInput);

            await _service.DeleteAsync(created.Id);

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetAsync(created.Id));
        }

        [Fact]
        public async Task DeleteAsync_NonExistingId_Should_Not_Throw()
        {
            var nonExistingId = Guid.NewGuid();

            var exception = await Record.ExceptionAsync(() => _service.DeleteAsync(nonExistingId));

            exception.ShouldBeNull();
        }

        [Fact]
        public async Task Should_Get_Participant_By_Id()
        {
            var input = new CreateParticipantDto
            {
                FirstName = "Karolina",
                LastName = "Maj",
                Email = "karolina.maj@example.com",
                Phone = "555666777",
                TicketType = TicketType.Vip
            };

            var created = await _service.CreateAsync(input);

            var result = await _service.GetAsync(created.Id);

            result.ShouldNotBeNull();
            result.Id.ShouldBe(created.Id);
            result.FirstName.ShouldBe(input.FirstName);
            result.LastName.ShouldBe(input.LastName);
            result.Email.ShouldBe(input.Email);
            result.Phone.ShouldBe(input.Phone);
            result.TicketType.ShouldBe(input.TicketType);
        }

        [Fact]
        public async Task GetAsync_NonExistingId_ThrowsEntityNotFoundException()
        {
            var nonExistingId = Guid.NewGuid();

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetAsync(nonExistingId));
        }

        [Fact]
        public async Task Should_Get_List_Of_Participants()
        {
            var input1 = new CreateParticipantDto
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jKowalski1@example.com",
                Phone = "123456789",
                TicketType = TicketType.Normal
            };
            var input2 = new CreateParticipantDto
            {
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "aNowak2@example.com",
                Phone = "987654321",
                TicketType = TicketType.Vip
            };

            await _service.CreateAsync(input1);
            await _service.CreateAsync(input2);

            var list = await _service.GetListAsync();

            list.ShouldNotBeNull();
            list.Count.ShouldBeGreaterThanOrEqualTo(2);

            list.Any(p => p.Email == input1.Email).ShouldBeTrue();
            list.Any(p => p.Email == input2.Email).ShouldBeTrue();
        }
    }
}