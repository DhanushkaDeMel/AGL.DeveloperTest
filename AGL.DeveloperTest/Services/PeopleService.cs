using AGL.DeveloperTest.Contracts.DataProviders;
using AGL.DeveloperTest.Contracts.Services;
using AGL.DeveloperTest.DataProviders;
using AGL.DeveloperTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace AGL.DeveloperTest.Services
{
    /// <summary>
    /// PeopleService class
    /// </summary>
    public class PeopleService : IPeopleService
    {
        private IJosnDataProvider _josnDataProvider;

        /// <summary>
        /// Default constructor
        /// </summary>
        public PeopleService(IJosnDataProvider josnDataProvider)
        {
            _josnDataProvider = josnDataProvider;
        }

        /// <summary>
        /// Get gender
        /// </summary>
        /// <returns>List of gender</returns>
        public List<string> GetGenders()
        {
            return _josnDataProvider.GetPeople().Select(d => d.Gender).Distinct().ToList();
        }

        /// <summary>
        /// Get pet names by gender
        /// </summary>
        /// <param name="type">string</param>
        /// <returns>List of PetNamesByGender</returns>
        public List<PetNamesByGender> GetPetsByGender(string type)
        {
            var result = new List<PetNamesByGender>();
            var gendersList = GetGenders();

            foreach(var gender in gendersList)
            {
                var petsByGender = new PetNamesByGender();
                petsByGender.Gender = gender;

                petsByGender.PetNames = _josnDataProvider.GetPeople()
                            .Where(e => e.Gender.ToLower() == gender.ToLower() && e.Pets != null)
                            .SelectMany(r => r.Pets)
                            .Where(e => e.Type.ToLower() == type.ToLower())
                            .Select(r => r.Name)
                            .OrderBy(r => r).ToList();
                
                result.Add(petsByGender);
            }

            return result;
        }

        /// <summary>
        /// Get cat names by gender
        /// </summary>
        /// <returns>List of PetNamesByGender</returns>
        public List<PetNamesByGender> GetCatsByGender()
        {
            return GetPetsByGender("cat");
        }
    }
}
