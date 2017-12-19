using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

using AGL.DeveloperTest.Contracts.DataProviders;
using AGL.DeveloperTest.Models;
using System.Configuration;

namespace AGL.DeveloperTest.DataProviders
{
    /// <summary>
    /// JosnDataProvider class
    /// </summary>
    public class JosnDataProvider : IJosnDataProvider 
    {
        private static string AppSettings_Url = "Url";

        private List<Person> _getPeopleCache;

        /// <summary>
        /// Get People
        /// </summary>
        /// <returns>List of person</returns>
        public List<Person> GetPeople()
        {
            if (_getPeopleCache == null)
            {
                string _url = ConfigurationManager.AppSettings[AppSettings_Url];
                _getPeopleCache = JsonConvert.DeserializeObject<List<Person>>(new WebClient().DownloadString(_url));
            }

            return _getPeopleCache;
        }
    }
}
