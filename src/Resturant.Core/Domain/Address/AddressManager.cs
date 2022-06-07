using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Resturant.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Domain.Address
{
    public class AddressManager: DomainService,IAddressManager
    {
        private readonly IRepository<Country> _countriesRepository;
        private readonly IRepository<State> _statesRepository;

        public AddressManager(IRepository<Country> countriesRepository, IRepository<State> statesRepository)
        {
            this._countriesRepository = countriesRepository;
            _statesRepository = statesRepository;
        }
        /// <summary>
        /// Get a specific Country.
        /// </summary>
        public async Task<Country> GetCountryAsync(int? countryId)
        {
            return await _countriesRepository.FirstOrDefaultAsync(i => i.Id == countryId);
        }
        public async Task<State> GetStateAsync(int? stateId)
        {
            return await _statesRepository.FirstOrDefaultAsync(i => i.Id == stateId);
        }
    }
}
