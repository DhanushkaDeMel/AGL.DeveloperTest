using AGL.DeveloperTest.Contracts.DataProviders;
using AGL.DeveloperTest.Contracts.Services;
using AGL.DeveloperTest.DataProviders;
using AGL.DeveloperTest.Services;
using System;

namespace AGL.DeveloperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IJosnDataProvider josnDataProvider = new JosnDataProvider();
                IPeopleService peopleService = new PeopleService(josnDataProvider);
                
                var catNamesByGenderList = peopleService.GetCatsByGender();

                if (catNamesByGenderList != null)
                {
                    foreach (var catNamesByGender in catNamesByGenderList)
                    {
                        Console.WriteLine(catNamesByGender.Gender);
                        Console.WriteLine();
                        catNamesByGender.PetNames.ForEach(i => Console.WriteLine(string.Concat("\t", i)));
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No records.");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error occured : {0}", ex.Message));
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
