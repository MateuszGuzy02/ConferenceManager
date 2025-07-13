using ConferenceManager.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Xunit;
using Moq;
using ConferenceManager.Tickets;
using System.Linq.Expressions;
using NSubstitute;
using Volo.Abp.ObjectMapping;
using Shouldly;
using NSubstitute.ExceptionExtensions;
using System.Threading;
using Volo.Abp.Domain.Entities;

namespace ConferenceManager.Participants
{
    public class ParticipantAppServiceTests
    {
        private readonly IRepository<Participant, Guid> _repository;
        private readonly IObjectMapper _objectMapper;
        private readonly ParticipantAppService _service;

        public ParticipantAppServiceTests()
        {
            _repository = Substitute.For<IRepository<Participant, Guid>>();
            _objectMapper = Substitute.For<IObjectMapper>();
            _service = new ParticipantAppService(_repository, _objectMapper);
        }

        [Fact]
        public async Task GetListAsync_ReturnsMappedList()
        {
            var participants = new List<Participant> { new Participant(Guid.NewGuid()) };
            var dtos = new List<ParticipantDto> { new ParticipantDto() };

            _repository.GetListAsync().Returns(participants);
            _objectMapper.Map<List<Participant>, List<ParticipantDto>>(participants).Returns(dtos);

            var result = await _service.GetListAsync();

            result.ShouldBe(dtos);
        }

        [Fact]
        public async Task GetAsync_ReturnsMappedParticipant()
        {
            var id = Guid.NewGuid();
            var participant = new Participant(id);
            var dto = new ParticipantDto();

            _repository.GetAsync(id).Returns(participant);
            _objectMapper.Map<Participant, ParticipantDto>(participant).Returns(dto);

            var result = await _service.GetAsync(id);

            result.ShouldBe(dto);
        }

        [Fact]
        public async Task GetAsync_WhenParticipantNotFound_ThrowsException()
        {
            var id = Guid.NewGuid();
            _repository.GetAsync(id).Throws(new EntityNotFoundException(typeof(Participant), id));

            await Should.ThrowAsync<EntityNotFoundException>(() => _service.GetAsync(id));
        }

        [Fact]
        public async Task CreateAsync_WhenEmailExists_ThrowsException()
        {
            var input = new CreateParticipantDto
            {
                Email = "test@test.com",
                FirstName = "Jan",
                LastName = "Kowalski",
                Phone = "123456789",
                TicketType = TicketType.Normal
            };
            _repository.AnyAsync(Arg.Any<Expression<Func<Participant, bool>>>()).Returns(true);

            await Should.ThrowAsync<UserFriendlyException>(() => _service.CreateAsync(input));
        }

        [Fact]
        public async Task CreateAsync_WhenEmailNotExists_CreatesAndReturnsDto()
        {
            var input = new CreateParticipantDto { Email = "test@test.com" };
            var participant = new Participant(Guid.NewGuid());
            var dto = new ParticipantDto();

            _repository.AnyAsync(p => p.Email == input.Email).Returns(false);
            _objectMapper.Map<CreateParticipantDto, Participant>(input).Returns(participant);
            _objectMapper.Map<Participant, ParticipantDto>(participant).Returns(dto);

            var result = await _service.CreateAsync(input);

            await _repository.Received().InsertAsync(participant);
            result.ShouldBe(dto);
        }

        [Fact]
        public async Task UpdateAsync_WhenEmailChangedAndExists_ThrowsException()
        {
            var id = Guid.NewGuid();
            var participant = new Participant(id) { Email = "old@test.com" };
            var input = new UpdateParticipantDto { Email = "new@test.com" };

            _repository.GetAsync(id).Returns(participant);
            _repository.AnyAsync(Arg.Any<Expression<Func<Participant, bool>>>()).Returns(true);

            await Should.ThrowAsync<UserFriendlyException>(() => _service.UpdateAsync(id, input));
        }

        [Fact]
        public async Task UpdateAsync_WhenEmailNotChanged_UpdatesAndReturnsDto()
        {
            var id = Guid.NewGuid();
            var participant = new Participant(id) { Email = "same@test.com" };
            var input = new UpdateParticipantDto { Email = "same@test.com" };
            var dto = new ParticipantDto();

            _repository.GetAsync(id).Returns(participant);
            _objectMapper.Map(input, participant);
            _objectMapper.Map<Participant, ParticipantDto>(participant).Returns(dto);

            var result = await _service.UpdateAsync(id, input);

            await _repository.Received().UpdateAsync(participant);
            result.ShouldBe(dto);
        }

        [Fact]
        public async Task UpdateAsync_WhenParticipantNotFound_ThrowsException()
        {
            var id = Guid.NewGuid();
            var input = new UpdateParticipantDto { Email = "new@test.com" };

            _repository.GetAsync(id).Throws(new EntityNotFoundException(typeof(Participant), id));

            await Should.ThrowAsync<EntityNotFoundException>(() => _service.UpdateAsync(id, input));
        }

        [Fact]
        public async Task UpdateAsync_WhenEmailDiffersOnlyByCaseAndExists_ThrowsException()
        {
            var id = Guid.NewGuid();
            var existingEmail = "email@test.com";
            var newEmail = "EMAIL@test.com";

            var participant = new Participant(id) { Email = existingEmail };
            var input = new UpdateParticipantDto { Email = newEmail };

            _repository.GetAsync(id).Returns(participant);
            _repository.AnyAsync(Arg.Any<Expression<Func<Participant, bool>>>()).Returns(true);

            await Should.ThrowAsync<UserFriendlyException>(() => _service.UpdateAsync(id, input));
        }

        [Fact]
        public async Task DeleteAsync_DeletesParticipant()
        {
            var id = Guid.NewGuid();

            await _service.DeleteAsync(id);

            await _repository.Received().DeleteAsync(id);
        }
    }
}

