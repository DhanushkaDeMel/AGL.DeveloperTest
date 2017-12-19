using System.Collections.Generic;

using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Contracts.DataProviders
{
    /// <summary>
    /// IJosnDataProvider interface
    /// </summary>
    public interface IJosnDataProvider
    {
        /// <summary>
        /// Get people
        /// </summary>
        /// <returns>List of person</returns>
        List<Person> GetPeople();
    }
}
