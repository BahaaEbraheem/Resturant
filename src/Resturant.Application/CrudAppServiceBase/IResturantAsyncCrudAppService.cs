using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.CrudAppServiceBase
{


    public interface IResturantAsyncCrudAppService<TEntityDto, TPrimaryKey>
 : IAsyncCrudAppService<TEntityDto, TPrimaryKey>
 where TEntityDto : IEntityDto<TPrimaryKey>
    {

    }

    public interface IResturantAsyncCrudAppService<TEntityDto, TPrimaryKey, in TGetAllInput>
        : IResturantAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto, TEntityDto>
        where TEntityDto : IEntityDto<TPrimaryKey>
    {
    }

    public interface IResturantAsyncCrudAppService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput>
        : IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
    }

}
