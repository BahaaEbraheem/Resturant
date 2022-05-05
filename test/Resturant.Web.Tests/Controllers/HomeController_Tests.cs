using System.Threading.Tasks;
using Resturant.Models.TokenAuth;
using Resturant.Web.Controllers;
using Shouldly;
using Xunit;

namespace Resturant.Web.Tests.Controllers
{
    public class HomeController_Tests: ResturantWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}