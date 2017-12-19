using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGL.DeveloperTest.Contracts.DataProviders;
using AGL.DeveloperTest.Test.DataProviders;
using AGL.DeveloperTest.Services;
using AGL.DeveloperTest.Contracts.Services;

namespace AGL.DeveloperTest.Test
{
    [TestClass]
    public class PeopleServiceTest
    {       

        private IPeopleService _PeopleService
        {
            get
            {
                IJosnDataProvider mockedJosnDataProvider = new MockedJosnDataProvider();
                return new PeopleService(mockedJosnDataProvider);
            }
        }

        [TestMethod]
        public void GetGendersCountTest()
        {
            Assert.AreEqual(_PeopleService.GetGenders().Count, 2);
        }

        [TestMethod]
        public void GetPetsByGenderCountTest()
        {
            Assert.AreEqual(_PeopleService.GetPetsByGender("cat")[0].PetNames.Count, 4);
        }

        [TestMethod]
        public void GetCatssByGenderSortedTest()
        {
            var obj = _PeopleService.GetCatsByGender();
            Assert.AreEqual(obj[1].PetNames[0], "Garfield");
            Assert.AreEqual(obj[1].PetNames[2], "Tabby");
        }
    }
}
