﻿using CentOps.Api.Models;
using CentOps.Api.Services.ModelStore.Models;

namespace CentOps.Api.Services.ModelStore.Interfaces
{
    public interface IParticipantStore : IModelStore<ParticipantDto>
    {
        Task<IEnumerable<ParticipantDto>> GetAll(IEnumerable<ParticipantTypeDto> types, bool includeInactive);
        Task<ParticipantDto?> GetByApiKeyAsync(string apiKey);
        Task<ParticipantDto> UpdateState(string id, ParticipantState newState);
    }
}
