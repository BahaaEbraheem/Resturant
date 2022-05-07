using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.CrudAppServiceBase
{
    public abstract class ResturantAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey>
    : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
    where TEntity : class, IEntity<TPrimaryKey>
    where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected ResturantAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {

        }
    }

    public abstract class ResturantAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput>
        : ResturantAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto, TEntityDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TGetAllInput : ResturantBaseListInputDto
    {
        protected ResturantAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
            LocalizationSourceName = ResturantConsts.LocalizationTokens;
        }
    }

    public abstract class ResturantAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TGetAllInput : ResturantBaseListInputDto
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        protected ResturantAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
            LocalizationSourceName = ResturantConsts.LocalizationTokens;
        }

        protected override IQueryable<TEntity> CreateFilteredQuery(TGetAllInput input)
        {
            var data = base.CreateFilteredQuery(input);

            if (input.HasFilter)
            {
                input.Filter = input.Filter.Replace(@"\", "");
                input.FilterExpr = JsonConvert.DeserializeObject<IList>(input.Filter, new JsonSerializerSettings
                {
                    DateParseHandling = DateParseHandling.None
                });
            }
            input.Sorting = FixSorting(input.Sorting);
            return data;
        }

        protected void CorrectFilterSelectors(IList filter, Dictionary<string, string> selectors)
        {
            foreach (var selector in selectors)
            {
                if (IsCriteria(filter[0]))
                {
                    foreach (var item in filter)
                    {
                        var operand = item as IList;
                        if (operand != null)
                            CorrectFilterSelectors(operand, selectors);
                    }
                }
                else
                {
                    if (filter[0].ToString().Equals(selector.Key))
                    {
                        if (filter[0] is string)
                            filter[0] = selector.Value;
                        else
                            filter[0] = new JValue(selector.Value);
                    }
                }
            }
        }

        bool IsCriteria(object item) => item is IList && !(item is String);

        protected string FixSorting(string sort)
        {
            string sorting = "";
            if (!string.IsNullOrEmpty(sort))
            {
                var sortingInfo = JsonConvert.DeserializeObject<IList>(sort, new JsonSerializerSettings
                {
                    DateParseHandling = DateParseHandling.None
                });
                sorting = ((JProperty)((JObject)sortingInfo[0]).First).Last.ToString() + (((bool)((JValue)(((JProperty)((JObject)sortingInfo[0]).Last).First)).Value) ? " desc" : " asc");
            }
            return sorting;
        }
    }


}
