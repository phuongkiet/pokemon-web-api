using AutoMapper;
using Demo2.Entity;
using Demo2.Repository;

namespace Demo2.Service
{
    public interface IOwnerService
    {
        public Task<ICollection<Owner>> GetOwners();
        public Task CreateOwner(int regionId, Owner Owner);

        public Task UpdateOwner(Owner Owner);

        public Task DeleteOwner(Owner Owner);

        public bool OwnerExists(int ownerId);

        public Task<ICollection<Pokemon>> GetPokemonByOwner(int ownerId);

        public Task<Owner> GetOwnerById(int ownerId);

        public Task<ICollection<Owner>> GetOwnersV2();
        public Task<ICollection<Owner>> GetOwnersV3();
    }
    public class OwnerService : IOwnerService
    {
        private readonly OwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerService(OwnerRepository ownerRepository, IMapper mapper) 
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task CreateOwner(int regionId, Owner owner)
        {
            await _ownerRepository.CreateOwner(regionId, owner);
        }

        public async Task DeleteOwner(Owner owner)
        {
            await _ownerRepository.Delete(owner);
        }

        public async Task<Owner> GetOwnerById(int ownerId)
        {
            return await _ownerRepository.GetByIntId(ownerId);
        }

        public async Task<ICollection<Owner>> GetOwners()
        {
            var owner = await _ownerRepository.GetAll();
            return owner.ToList();
        }

        public async Task<ICollection<Owner>> GetOwnersV2()
        {
            var owner = await _ownerRepository.GetOwnersV2();
            return owner.ToList();
        }

        public async Task<ICollection<Owner>> GetOwnersV3()
        {
            var owner = await _ownerRepository.GetOwnersV3();
            return owner.ToList();
        }

        public async Task<ICollection<Pokemon>> GetPokemonByOwner(int ownerId)
        {
            return await _ownerRepository.GetPokemonByOwner(ownerId);
        }

        public bool OwnerExists(int ownerId)
        {
            return _ownerRepository.OwnerExist(ownerId);
        }

        public async Task UpdateOwner(Owner owner)
        {
            await _ownerRepository.Update(owner);
        }
    }
}
