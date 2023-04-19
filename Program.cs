using System.Reflection.PortableExecutable;


namespace CA3
{
	public class vars ///this class contains variables used in the program
	{
		public static int unknown = 0, infants = 0, children = 0, teenage = 0, youngAdult = 0, adult = 0, olderAdult = 0;  

	}
	class shipreport
	{
		private string _FirstName;
		private string _LastName;
		private string _Age;
		private string _Gender;
		private string _Occupation;
		private string _Country;
		private string _Port;
		private string _Destination;
		private string _Ship;
		private string _Arrival;
	}
	public class Passenger2
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Passenger2(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
	public class Passenger
	{
		private string _firstName;
		private int _age;

		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		public int Age
		{
			get { return _age; }
			set 
			{

				Console.WriteLine("age assigned");
				int age;
				try{
					if (value.ToString().StartsWith("Infant"))
					{
						age = 0;
					}
					else
					{
						age = int.Parse(value.ToString().Substring(4));
					}
				}
				catch 
				{
					age = -1;
				}
				_age = age;





				if (age == -1)
				{
					vars.unknown++;

				}


				else if (age == 0)
				{
					vars.infants++;
				}
				else if (age <= 12)
				{
					vars.children++;
				}
				else if (age <= 19)
				{
					Console.WriteLine("I fired");
					vars.teenage++;
				}
				else if (age <= 29)
				{
					vars.youngAdult++;
				}
				else if (age >= 30)
				{
					vars.adult++;
				}
				else if (age >= 50)
				{
					vars.olderAdult++;
				}
			}
		}
	}

	public class Ship
	{
		public string Name { get; set; }
		public string DeparturePort { get; set; }
		public string ArrivalDate { get; set; }
		public Passenger[] Passengers { get; set; }

		public int PassengerCount
		{
			get { return Passengers.Length; }
		}

		public Ship(string name, string departurePort, string arrivalDate, Passenger[] passengers)
		{
			Name = name;
			DeparturePort = departurePort;
			ArrivalDate = arrivalDate;
			Passengers = passengers;
		    


		
		}
	}




	internal class Program
	{
		static void Main(string[] args)

		{


			DisplayMenu();




		}
		static void DisplayMenu()
		{
			string input;
			do
			{
				Console.WriteLine();
				Console.WriteLine("Main Menu");
				Console.WriteLine("1. Ship Reports");
				Console.WriteLine("2. Occupation Report");
				Console.WriteLine("3. Age Report");
				Console.WriteLine("4. Exit");
				Console.WriteLine();
				Console.Write("Enter Choice: ");
				input = Console.ReadLine();
				if (input == "1")
				{
					ShipReports();
				}
				if (input == "2")
				{
					OccupationReport();
				}
				if (input == "3")
				{
					AgeReport();
				}



			} while (input != "4");


		}
		static void ShipReports()
		{


			Console.WriteLine("Enter the name of the ship:");
			string shipName = Console.ReadLine();

			using (var reader = new StreamReader("faminefile.csv"))
			{
				int counter = 0;
				
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					
					var values = line.Split(',');

					if (values[8].Trim() == shipName)
					{
						

						for (int i = 1; i < values.Length - 2; i += 2)
						{
							Console.WriteLine("First Name " + values[i] + " : Last Name " + values[i - 1]);

							counter++;



							break;
						}
						



					}
					
				}
				Console.WriteLine($"Amount of passengers on this ship {counter}");
			}


			static string GetNumPassengers(string str)
			{
				int numPassengers;
				if (int.TryParse(str, out numPassengers))
				{
					return numPassengers.ToString();
				}
				else if (str.ToLower() == "missing")
				{
					return "Unknown number of";
				}
				else
				{
					return "Invalid number of";
				}
			}
		}


		static void OccupationReport()
		{ 

		

				Dictionary<string, int> occupations = new Dictionary<string, int>();


				using (StreamReader reader = new StreamReader("faminefile.csv"))
				{
					string line;

					while ((line = reader.ReadLine()) != null)
					{
						string[] parts = line.Split(',');


						if (parts.Length != 10)
						{
							Console.WriteLine("Invalid line: " + line);
							continue;
						}

						string occupation = parts[4];
						if (occupation == "")
							occupation = "Unknown";

						if (occupations.ContainsKey(occupation))
							occupations[occupation]++;
						else
							occupations.Add(occupation, 1);
					}
				}


				foreach (KeyValuePair<string, int> kvp in occupations)
				{
					Console.WriteLine(kvp.Key + ": " + kvp.Value);
				}
		}


			static List<Passenger> ReadFile()
			{

				List<Passenger> passes = new List<Passenger>() { };

				using (StreamReader reader = new StreamReader("faminefile.csv"))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						string[] parts = line.Split(',');


						if (parts.Length != 10)
						{
							Console.WriteLine("Invalid line: " + line);
							continue;
						}


						Passenger one = new Passenger();

						one.FirstName = parts[0];
						one.Age = int.Parse(parts[2]);
						passes.Add(one);


					}

				}
				return passes;
			}








			static void AgeReport()
			{


				List<Passenger> list = ReadFile();

				Console.WriteLine("Infants (<1 year): " + vars.infants);
				Console.WriteLine("Children (1-12): " + vars.children);
				Console.WriteLine("Teenage (12-19): " + vars.teenage);
				Console.WriteLine("Young adult (20-29): " + vars.youngAdult);
				Console.WriteLine("Adult (30+): " + vars.adult);
				Console.WriteLine("Older adult (50+): " + vars.olderAdult);
				Console.WriteLine("Unknown: " + vars.unknown);




			}



	}

}
	



	
	
