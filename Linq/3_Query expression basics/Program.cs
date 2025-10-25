using System;
using System.Collections.Generic;
using System.Linq;

namespace QueryExpressionBasics
{
	record City(string Name, int Population);
	record Country(string Name, int Population, int Area, List<City> Cities);

	class Program
	{
		static void Main(string[] args)
		{
			// 1) Filtering & ordering (scores)
			int[] scores = { 99, 82, 75, 91, 85, 60, 55, 100 };

			var highScoresQuery =
				from score in scores
				where score > 80
				orderby score descending
				select score;

			Console.WriteLine("High scores > 80:");
			foreach (var s in highScoresQuery)
				Console.WriteLine(s);
			Console.WriteLine();

			// 2) Projection with let (names -> first names)
			string[] names = { "Svetlana Omelchenko", "Claire O'Donnell" };
			var firstNames =
				from name in names
				let firstName = name.Split(' ')[0]
				select firstName;

			Console.WriteLine("First names (using let):");
			foreach (var f in firstNames)
				Console.WriteLine(f);
			Console.WriteLine();

			// 3) from ... from (flattening) and where (cities)
			var countries = new List<Country>
			{
				new Country("Utopia", 50_000_000, 500_000, new List<City>
				{
					new City("Metropolis", 5_000_000),
					new City("Smallville", 500_000)
				}),
				new Country("Megaland", 200_000_000, 1_000_000, new List<City>
				{
					new City("GigaCity", 12_000_000),
					new City("Townsville", 2_000_000)
				})
			};

			var bigCities =
				from country in countries
				from city in country.Cities
				where city.Population > 1_000_000
				select new { Country = country.Name, City = city.Name, city.Population };

			Console.WriteLine("Cities with population > 1_000_000:");
			foreach (var c in bigCities)
				Console.WriteLine($"{c.City} ({c.Country}) - {c.Population:N0}");
			Console.WriteLine();

			// 4) group ... into (grouping)
			var queryCountryGroups =
				from country in countries
				group country by country.Name[0] into countryGroup
				orderby countryGroup.Key
				select new { Letter = countryGroup.Key, Countries = countryGroup.Select(c => c.Name) };

			Console.WriteLine("Countries grouped by first letter:");
			foreach (var g in queryCountryGroups)
				Console.WriteLine($"{g.Letter}: {string.Join(", ", g.Countries)}");
			Console.WriteLine();

			// 5) Subquery example: max city population per country
			var maxCityPerCountry =
				from country in countries
				select new
				{
					Country = country.Name,
					MaxCityPopulation = (from city in country.Cities select city.Population).Max()
				};

			Console.WriteLine("Max city population per country:");
			foreach (var x in maxCityPerCountry)
				Console.WriteLine($"{x.Country}: {x.MaxCityPopulation:N0}");
			Console.WriteLine();

			// 6) Deferred execution demonstration
			var deferred = from s in scores where s > 80 select s;
			Console.WriteLine("Deferred execution demo - query created, then data changes:");
			Console.WriteLine("Original matching values: " + string.Join(", ", deferred));
			// Modify source array
			scores[1] = 50; // was 82
			Console.WriteLine("After modifying scores[1] to 50:");
			Console.WriteLine("Re-evaluated matching values: " + string.Join(", ", deferred));
		}
	}
}
