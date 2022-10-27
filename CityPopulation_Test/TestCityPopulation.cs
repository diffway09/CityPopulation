using CityPopulation.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CityPopulation_Test
{
    public class TestCityPopulation
    {
        [Fact]
        public void GetTopTen_OnSuccess_ReturnsStatusCode200()
        {
            var cityPopulation = new CityPopulationController();

            var result = (OkObjectResult)cityPopulation.GetTopTenCityPopulation();

            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData("Chiang Rai")]
        [InlineData("ชลบุรี")]
        public void GetPopulationByCity_OnSuccess_ReturnsStatusCode200(string city)
        {
            var cityPopulation = new CityPopulationController();

            var result = (OkObjectResult)cityPopulation.GetPopulationByCity(city);

            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData("เชียงราย")]
        [InlineData("ไทย")]
        [InlineData("=][6iu")]
        public void GetPopulationByCity_NotFound_ReturnsStatusCode404(string city)
        {
            var cityPopulation = new CityPopulationController();

            var result = (NotFoundResult)cityPopulation.GetPopulationByCity(city);

            result.StatusCode.Should().Be(404);
        }
    }
}