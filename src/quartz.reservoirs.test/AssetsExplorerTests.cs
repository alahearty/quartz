using NUnit.Framework;
using quartz.application.reservoirs.ViewModels;
using quartz.reservoirs.test.Base;
using Microsoft.Practices.Unity;
using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;
using Moq;
using quartz.application.reservoirs;
using System.Collections.Generic;
using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Linq;

namespace quartz.reservoirs.test
{
    [TestFixture]
    public class AssetsExplorerTests: BaseSetup
    {
        Mock<IAPIClient> mock_apiClient;

        [SetUp]
        public void Setup()
        {
            mock_apiClient = new Mock<IAPIClient>();
        }

        [Test]
        public void GetReservoirs_WhenReservoirExist_ShouldReturnAllReservoirs()
        {
            mock_apiClient.Setup(gt => gt.Get(It.IsAny<APIQuery>(), It.IsAny<ReservoirListRequest>(), null, null)).
                Returns(new ReponseEnvelop<List<ReservoirIndexResponse>>("OK", "OK", Faker.GetReservoirIndexes()));
            ITabDockService tabDockService = Container.Resolve<ITabDockService>();
            AssetExplorerViewModel assetExplorerViewModel = new AssetExplorerViewModel(tabDockService, mock_apiClient.Object);
            
            var result = assetExplorerViewModel.GetReservoirs();

            Assert.That(result.Count == Faker.GetReservoirIndexes().Count);
        }

        [Test]
        public void GetReservoirs_WhenThereIsNoReservoir_ShouldReturnZeroCount()
        {
            mock_apiClient.Setup(gt => gt.Get(It.IsAny<APIQuery>(), It.IsAny<ReservoirListRequest>(), null, null)).
                Returns(new ReponseEnvelop<List<ReservoirIndexResponse>>("OK", "OK", new List<ReservoirIndexResponse>()));
            ITabDockService tabDockService = Container.Resolve<ITabDockService>();
            AssetExplorerViewModel assetExplorerViewModel = new AssetExplorerViewModel(tabDockService, mock_apiClient.Object);

            var result = assetExplorerViewModel.GetReservoirs();

            Assert.IsNotNull(result);
            Assert.That(result.Count == 0);
        }

        [Test]
        public void AssetExplorerViewModel_WhenAPIServiceIsNotAvailable_ShouldReturnNull()
        {
            AssetExplorerViewModel assetExplorerViewModel = Container.Resolve<AssetExplorerViewModel>();

            var result = assetExplorerViewModel.GetReservoirs();

            Assert.IsNull(result);
        }

        [Test]
        public void GetReservoir_WhenCalled_ShouldReturnAReservoirById()
        {
            var new_reservoir = Faker.GetReservoir();
            mock_apiClient.Setup(gt => gt.Get<Reservoir>(It.IsAny<APIQuery>(), null, null)).
                Returns(()=> new ReponseEnvelop<Reservoir>("OK", "OK", new_reservoir));
            ITabDockService tabDockService = Container.Resolve<ITabDockService>();
            AssetExplorerViewModel assetExplorerViewModel = new AssetExplorerViewModel(tabDockService, mock_apiClient.Object);

            var result = assetExplorerViewModel.GetReservoir(2);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(new_reservoir));
        }

        [Test]
        public void GetReservoir_WhenReservoirIdDoesNotExist_ShouldReturnNull()
        {
            var new_reservoir = Faker.GetReservoir();
            mock_apiClient.Setup(gt => gt.Get<Reservoir>(It.IsAny<APIQuery>(), null, null)).
                Returns(() => new ReponseEnvelop<Reservoir>("OK", "OK", null));
            ITabDockService tabDockService = Container.Resolve<ITabDockService>();
            AssetExplorerViewModel assetExplorerViewModel = new AssetExplorerViewModel(tabDockService, mock_apiClient.Object);

            var result = assetExplorerViewModel.GetReservoir(2);

            Assert.IsNull(result);
        }

        [Test]
        public void AddNewReservoir_WhenReservoirIsNull_ShouldThrowNullexception()
        {
            AssetExplorerViewModel assetExplorerViewModel = Container.Resolve<AssetExplorerViewModel>();

            Assert.Throws<NullReferenceException>(() => assetExplorerViewModel.AddNewReservoir(2, null));
        }

        [Test]
        public void AddNewReservoir_WhenCalled_ShouldIncreasementReservoirList()
        {
            var new_reservoir = Faker.GetReservoir();
            AssetExplorerViewModel assetExplorerViewModel = Container.Resolve<AssetExplorerViewModel>();
            assetExplorerViewModel.GetReservoirsAsync();
            assetExplorerViewModel.AddNewReservoir(2, new_reservoir);

            Assert.That(assetExplorerViewModel.Reservoirs.Count == 1);
            // Assert.That(assetExplorerViewModel.Reservoirs, Contains.Item(new_reservoir.Name));
            Assert.That(assetExplorerViewModel.Reservoirs.Any(x => x.Reservoir == new_reservoir));
        }
    }
}
