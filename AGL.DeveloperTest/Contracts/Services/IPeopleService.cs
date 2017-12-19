using AGL.DeveloperTest.Models;
using System.Collections.Generic;

namespace AGL.DeveloperTest.Contracts.Services
{
    /// <summary>
    /// IPeopleService interface
    /// </summary>
    public interface IPeopleService
    {
        /// <summary>
        /// Get gender
        /// </summary>
        /// <returns>List of gender</returns>
        List<string> GetGenders();

        /// <summary>
        /// Get pet names by gender
        /// </summary>
        /// <param name="type">string</param>
        /// <returns>List of PetNamesByGender</returns>
        List<PetNamesByGender> GetPetsByGender(string type);

        /// <summary>
        /// Get cat names by gender
        /// </summary>
        /// <returns>List of PetNamesByGender</returns>
        List<PetNamesByGender> GetCatsByGender();
    }
}
