using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant.Customers.Dto;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Runtime.Validation;
using Abp.Runtime.Security;
using Microsoft.AspNetCore.Identity;
using Resturant.CrudAppServiceBase;
using Resturant.Authorization.Users;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using Resturant.Localization.SourceFiles;
using Microsoft.EntityFrameworkCore;
using ITLand.CMMS.Libs.DevExtreme;

namespace Resturant.Customers
{
    public class CustomerAppService : ResturantAsyncCrudAppService<Customer, CustomerDto, int, ResturantBaseListInputDto, CreateCustomerDto, EditCustomerDto>, ICustomerAppService

    {
        private readonly IRepository<Customer> _CustomerRepository;
        private readonly UserManager _userManager;

        public CustomerAppService(IRepository<Customer> Repository, UserManager userManager) : base(Repository)
        {
            _CustomerRepository = Repository;
            _userManager = userManager;

        }

        /// <summary>
        /// filtering list params
        /// </summary>
        /// <param name="input">search-filter</param>
        /// <returns></returns>
        /// 
        protected override IQueryable<Customer> CreateFilteredQuery(ResturantBaseListInputDto input)
        {
            var data = base.CreateFilteredQuery(input);
            //data = data.WhereIf(input.ReasonRelatedTo.HasValue, i => i.RelatedTo == input.ReasonRelatedTo.Value);
            if (input.HasFilter)
            {
                data = new DataSourceLoaderImpl<Customer>(data, input, default, true).LoadAsync().Result;
            }
            return data;
        }
        public async Task<PagedResultDto<CustomerListDto>> GetAllCustomersAsync(ResturantBaseListInputDto input)
        {
            try
            {
                var data = CreateFilteredQuery(input);
                var totalCount = await AsyncQueryableExecuter.CountAsync(data);
                data = ApplySorting(data, input);
                data = ApplyPaging(data, input);
                var list = await AsyncQueryableExecuter.ToListAsync(data);
                var listDto = ObjectMapper.Map<List<CustomerListDto>>(list);

                foreach (var item in listDto)
                {
                    item.PhoneNumber = _userManager.Users.SingleOrDefault(a => a.Id == item.UserId).PhoneNumber;
                    item.EmailAddress = _userManager.Users.SingleOrDefault(a => a.Id == item.UserId).EmailAddress;
                    item.Surname = _userManager.Users.SingleOrDefault(a => a.Id == item.UserId).Surname;
                    item.Name = _userManager.Users.SingleOrDefault(a => a.Id == item.UserId).Name;
                    item.UserName = _userManager.Users.SingleOrDefault(a => a.Id == item.UserId).UserName;
                    item.IsActive = _userManager.Users.SingleOrDefault(a => a.Id == item.UserId).IsActive;
                    //item.StateName = Enum.GetName(typeof(Status), item.CustomerStatus);
                    var user = await _userManager.FindByIdAsync(AbpSession.GetUserId().ToString());
                    item.CreatorUserName = (await _userManager.GetUserByIdAsync(user.Id)).UserName;
                }
                return new PagedResultDto<CustomerListDto>(totalCount, listDto);
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        public override async Task<CustomerDto> CreateAsync(CreateCustomerDto input)
        {
            try
            {
                if (input.UserId == 0)
                {
                    CheckCreatePermission();
                    var user = ObjectMapper.Map<User>(input);
                    user.TenantId = AbpSession.TenantId;
                    user.IsEmailConfirmed = true;

                    await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

                    CheckErrors(await _userManager.CreateAsync(user, input.Password));
                    var Customer = MapToEntity(input);
                    var existCustomer = await _CustomerRepository.FirstOrDefaultAsync(a => a.UserId == user.Id);
                    if (existCustomer == null)
                    {
                        Customer.UserId = user.Id;
                    
                        Customer.Id = await Repository.InsertAndGetIdAsync(Customer);

                        //Add Customer Role to this Customer
                     }
                    var CustomerDto = MapToEntityDto(Customer);
                    //  CurrentUnitOfWork.SaveChanges();
                    return CustomerDto;
                }
                else
                {
                    var Customer = MapToEntity(input);
                    var existCustomer = await _CustomerRepository.FirstOrDefaultAsync(a => a.UserId == Customer.UserId);
                    if (existCustomer == null)
                    {
                        Customer.Id = await Repository.InsertAndGetIdAsync(Customer);
                    }
                    var CustomerDto = MapToEntityDto(Customer);
                    return CustomerDto;
                }

            }
            catch (NullReferenceException)
            {
                throw;
            }
        }
        public async override Task<CustomerDto> UpdateAsync(EditCustomerDto input)
        {

            var Customer = Repository.GetAsync(input.Id).Result;
            if (Customer == null)
                throw new UserFriendlyException(string.Format((Exceptions.ObjectWasNotFound), input.Id));

            var user = _userManager.Users.FirstOrDefault(a => a.Id == Customer.UserId);
            // user.IsActive = input.IsActive;
            user.Name = input.Name;
            user.UserName = input.UserName;
            user.Surname = input.Surname;
            user.EmailAddress = input.EmailAddress;
            user.PhoneNumber = input.PhoneNumber;
            //user.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, input.Password);
            user.LastModifierUserId = AbpSession.UserId;
            CheckErrors(await _userManager.UpdateAsync(user));
            //if (user.IsActive)
            //{
            //    input.CustomerStatus = Status.Accepted;
            //}
            //else
            //{
            //    input.CustomerStatus = Status.Suspended;
            //}
            CurrentUnitOfWork.SaveChanges();
            return await base.UpdateAsync(input);

        }
        public async Task ActivateDeactivate(EntityDto<int> input)
        {
            var Customer = await Repository.GetAsync(input.Id);
            if (Customer == null)
                throw new UserFriendlyException(string.Format((Exceptions.ObjectWasNotFound), input.Id));
            var user = _userManager.Users.FirstOrDefault(a => a.Id == Customer.UserId);
            user.IsActive = !user.IsActive;
            CheckErrors(await _userManager.UpdateAsync(user));
          
            CurrentUnitOfWork.SaveChanges();
            await Repository.UpdateAsync(Customer);

        }
        public override async Task<CustomerDto> GetAsync(EntityDto<int> input)
        {
            var Customer = await Repository.FirstOrDefaultAsync(input.Id);
            if (Customer == null)
                throw new UserFriendlyException(string.Format((Exceptions.ObjectWasNotFound), Tokens.Customer));

            var CustomerDto = ObjectMapper.Map<CustomerDto>(Customer);
            var user = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == Customer.UserId);
            if (user == null)
                throw new UserFriendlyException(string.Format((Exceptions.ObjectWasNotFound), Tokens.Users));
            CustomerDto.UserName = user.UserName;
            CustomerDto.Name = user.Name;
            CustomerDto.Surname = user.Surname;
            CustomerDto.IsActive = user.IsActive;
            CustomerDto.EmailAddress = user.EmailAddress;
            CustomerDto.CreatorUserName = (await _userManager.GetUserByIdAsync(CustomerDto.CreatorUserId.Value)).Name;

            return CustomerDto;
        }
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var Customer = await Repository.FirstOrDefaultAsync(input.Id);
            if (Customer == null)
                throw new UserFriendlyException(string.Format((Exceptions.ObjectWasNotFound), Tokens.Customer));
            await Repository.DeleteAsync(Customer);
            var user = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == Customer.UserId);
            if (user == null)
                throw new UserFriendlyException(string.Format((Exceptions.ObjectWasNotFound), Tokens.Users));
            await _userManager.DeleteAsync(user);
            MapToEntityDto(Customer);

        }

    }
}

