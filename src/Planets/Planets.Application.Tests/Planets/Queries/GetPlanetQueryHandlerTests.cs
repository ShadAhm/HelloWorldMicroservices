using Moq;
using Planets.Domain.Entities;
using Planets.Domain.ValueObjects;
using Planets.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Planets.Application.Planets.Queries.Tests
{
    public class GetPlanetQueryHandlerTests
    {
        private Mock<IDataFile<Planet>> _dataFileMock;
        private IEnumerable<Planet> planets = new List<Planet>
        {
            new Planet
            { 
                Name = "Earth",
                LinguaFrancaCulture = "ms-MY",
                Endonyms = new List<Endonym>
                {
                    new Endonym("world", "en-GB"),
                    new Endonym("dunia", "ms-MY")
                }
            }
        };

        public GetPlanetQueryHandlerTests()
        {
            _dataFileMock = new Mock<IDataFile<Planet>>();
        }

        [Fact(DisplayName = "Should return lingua franca Endonym if no culture requested")]
        public async Task NoCultureRequested_ShouldReturnLinguaFrancaEndonym()
        {
            GetPlanetQuery request = new GetPlanetQuery
            {
                Name = "Earth",
                Culture = null
            };

            _dataFileMock.Setup(o => o.GetAll()).Returns(planets);
            var service = new GetPlanetQueryHandler(_dataFileMock.Object);

            var result = await service.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(result);
            Assert.Equal("dunia", result!.Endonym);
        }
    }
}