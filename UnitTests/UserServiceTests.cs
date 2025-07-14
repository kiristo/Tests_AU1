using BlazorFluentCMS.Core;
using BlazorFluentCMS.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UserServiceTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null);
            _userService = new UserService(_userManagerMock.Object);
        }

        [Fact]
        public async Task GetUsersAsync_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = "1", UserName = "test1" },
                new ApplicationUser { Id = "2", UserName = "test2" }
            };
            _userManagerMock.Setup(x => x.Users).Returns(users.AsQueryable());

            // Act
            var result = await _userService.GetUsersAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
