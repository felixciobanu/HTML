using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace UiS.Dat240.Lab2.Tests
{
    public class WebApplicationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;

        public WebApplicationTests(WebApplicationFactory<Program> factory)
        {
            // This is a way to mock the asp.net core server, and we use it 
            // to gain access to the DI container
            this.factory = factory;
        }

        [Fact]
        public void IFoodItemValidatorTests()
        {
            // itemValidator will be null if it is not registered in the DI container
            var itemValidator = factory.Services.GetService<IFoodItemValidator>();
            // Use "Assert...." to verify different scenarioes.
            // This will show up when running dotnet test when
            // standing in the test project directory.
            Assert.NotNull(itemValidator);
        }
        
        [Fact]
        public void TestName()
        {
            var validator = factory.Services.GetService<IFoodItemValidator>();
            var testName = new FoodItem();
            testName.Name= "";
            testName.Description = "Test Description";
            testName.Price = 100;
            var errors = validator.IsValid(testName);
            Assert.Contains("Please fill in name", errors);
        }

        [Fact]
        public void TestDescription(){
            var validator = factory.Services.GetService<IFoodItemValidator>();
            var testDesc = new FoodItem();
            testDesc.Name="testName";
            testDesc.Description="";
            testDesc.Price = 100;
            var errors = validator.IsValid(testDesc);
            Assert.Contains("Please set a description", errors);
        }

        [Fact]
        public void TestPrice()
        {
            var validator = factory.Services.GetService<IFoodItemValidator>();
            var testPrice = new FoodItem();
            testPrice.Name = "Test Name";
            testPrice.Description = "Test desc";
            testPrice.Price = 0;
            var errors = validator.IsValid(testPrice);
            Assert.Contains("Price must be greater than 0", errors);
        }
    }
}