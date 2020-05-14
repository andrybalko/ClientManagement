using LoremNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms.Internals;

namespace ClientManagement.models.stub
{
	/// <summary>
	/// Used data from https://github.com/RandomAPI/RandomClient.me-Node/tree/master/api/1.0/data/US/lists
	/// </summary>
	public class Data
	{
		private static string[] FirstNames = { "allison", "alma", "alyssa", "amanda", "amber", "amelia", "amy", "ana", "andrea", "anita", "ann", "anna", "anne", "annette", "annie", "april", "arianna", "arlene", "alberto", "alex", "alexander", "alfred", "alfredo", "allan", "allen", "alvin", "andre", "andrew", "andy", "angel", "anthony", "antonio", "armando", "arnold", "arron", "arthur", "austin", "barry", "ben", "benjamin", "bernard", "bill" };
		private static string[] LastNames = { "fletcher", "campbell", "carlson", "carpenter", "carr", "carroll", "carter", "castillo", "castro", "chambers", "chapman", "chavez", "clark", "cole", "coleman", "collins", "cook", "cooper", "cox", "craig", "crawford", "cruz", "cunningham", "curtis" };
		private static string[] States = { "alabama", "alaska", "arizona", "arkansas", "california", "colorado", "connecticut", "delaware", "florida", "georgia", "hawaii", "idaho", "illinois", "indiana", "iowa", "kansas", "kentucky", "louisiana", "maine", "maryland", "massachusetts", "michigan", "minnesota", "mississippi", "missouri", "montana", "nebraska", "nevada", "new hampshire", "new jersey", "new mexico", "new york", "north carolina", "north dakota", "ohio", "oklahoma", "oregon", "pennsylvania", "rhode island", "south carolina", "south dakota", "tennessee", "texas", "utah", "vermont", "virginia", "washington", "west virginia", "wisconsin", "wyoming", };
		private static string[] Streets = { "adams st", "ash dr", "avondale ave", "blossom hill rd", "bollinger rd", "brown terrace", "bruce st", "cackson st", "camden ave", "central st", "cherry st", "college st", "country club rd", "crockett st", "daisy dr", "dane st", "depaul dr", "dogwood ave", "e center st", "e little york rd", "e north st", "e pecan st", "e sandy lake rd", "eason rd", "edwards rd", "elgin st", "fairview st", "fincher rd", "first street", "forest ln", "frances ct", "green rd", "groveland terrace", "hamilton ave", "harrison ct", "hickory creek dr", "hillcrest rd", "hogan st", "homestead rd", "hunters creek dr", "james st", "karen dr", "lakeshore rd", "lakeview st", "locust rd", "lone wolf trail", "lovers ln", "marsh ln", "mcclellan rd", "mcgowen st", };
		private static string[] Cities = { "allen", "allentown", "altoona", "amarillo", "anaheim", "anchorage", "ann arbor", "anna", "antioch", "arlington", "arvada", "athens", "atlanta", "aubrey", "augusta", "aurora", "austin", "bakersfield", "baltimore", "baton rouge", "beaumont", "belen", "bellevue", "berkeley", "bernalillo", "billings", "birmingham", "boise", "boston", "boulder", "bozeman", "bridgeport", "broken arrow", "brownsville", "bueblo", "buffalo", "burbank", "burkburnett", "caldwell", "cambridge", "cape coral", "cape fear", "carlsbad", "carrollton", "cary", "cedar hill", "marsh ln", "mcclellan rd", "mcgowen st", };

		private static int Index(int length) => new Random().Next(0, length - 1);

		private static string Element(string[] source)
		{
			return ToUppercase(source[Index(source.Length)]);
		}

		private static string ToUppercase (string input) 
		{
			var ar = input.Split(" ".ToCharArray()[0]);

			for (int i = ar.Length - 1; i >= 0; i--)
			{
				ar[i] = ar[i].First().ToString().ToUpper() + ar[i].Substring(1);
			}

			return string.Join(" ", ar);
		} 
		

		private static string PhoneNumber()
		{
			string s = string.Empty;
			for (int i = 0; i < 10; i++)
				s = String.Concat(s, Index(10).ToString());
			return s;
		}



		public static Client GetClient => new Client()
		{
			FirstName = Element(FirstNames),
			LastName = Element(LastNames),
			Description = Lorem.Sentence(5, 10),
			Created = DateTime.Now.AddDays(-Index(2000)),
			Avatar = "https://picsum.photos/id/" + Index(1000) + "/200",
			Address = new Address()
			{
				City = Element(Cities),
				Landline = Regex.Replace(PhoneNumber(), @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3"),
				Mobile = Regex.Replace(PhoneNumber(), @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3"),
				WorkPhone = Regex.Replace(PhoneNumber(), @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3"),
				PostalCode = Index(100000),
				State = Element(States),
				Street = Index(150) + ", " + Element(Streets)
			}
		};



	}
}
