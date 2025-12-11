using BierShop9.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BierShop9.Controllers
{
    public class GenericController : Controller
    {
        public void Index()
        {
            DataStore numbers = new DataStore();

            numbers.AddOrUpdate(0, 20);
            numbers.AddOrUpdate(1, 40);
            numbers.AddOrUpdate(2, 10);

            DataStore<string> cities = new DataStore<string>();

            cities.AddOrUpdate(0, "Mumbai");
            cities.AddOrUpdate(1, "Chicago");
            cities.AddOrUpdate(2, "London");

            DataStore<int> empIds = new DataStore<int>();
            empIds.AddOrUpdate(0, 50);
            empIds.AddOrUpdate(1, 65);
            empIds.AddOrUpdate(2, 89);
        }
    }
}
