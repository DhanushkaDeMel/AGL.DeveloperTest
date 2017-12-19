using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

using AGL.DeveloperTest.Contracts.DataProviders;
using AGL.DeveloperTest.Models;

namespace AGL.DeveloperTest.Test.DataProviders
{
    /// <summary>
    /// JosnDataProvider class
    /// </summary>
    public class MockedJosnDataProvider : IJosnDataProvider 
    {
        public string jsonData = @"[{'name':'Bob','gender':'Male','age':23,'pets':[{'name':'Garfield','type':'Cat'},{'name':'Fido','type':'Dog'}]},{'name':'Jennifer','gender':'Female','age':18,'pets':[{'name':'Garfield','type':'Cat'}]},{'name':'Steve','gender':'Male','age':45,'pets':null},{'name':'Fred','gender':'Male','age':40,'pets':[{'name':'Tom','type':'Cat'},{'name':'Max','type':'Cat'},{'name':'Sam','type':'Dog'},{'name':'Jim','type':'Cat'}]},{'name':'Samantha','gender':'Female','age':40,'pets':[{'name':'Tabby','type':'Cat'}]},{'name':'Alice','gender':'Female','age':64,'pets':[{'name':'Simba','type':'Cat'},{'name':'Nemo','type':'Fish'}]}]";
        
        /// <summary>
        /// Get People
        /// </summary>
        /// <returns>List of person</returns>
        public List<Person> GetPeople()
        {
            return JsonConvert.DeserializeObject<List<Person>>(jsonData);
        }
    }
}
