using System.Reflection.PortableExecutable;

namespace CA3
{
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
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine();
						var values = line.Split(',');

						if (values[8].Trim() == shipName)
						{
							Console.WriteLine(values[0] + " leaving from " + values[7] + " Arrived : " + values[9] + " with " + GetNumPassengers(values[9]) + " passengers");

							for (int i = 1; i < values.Length - 2; i += 2)
							{
								Console.WriteLine("First Name " + values[i] + " : Last Name " + values[i - 1]);
							}

							
							break;
						}
					}
				}
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
					return "Unknown number of passengers";
				}
				else
				{
					return "Invalid number of passengers";
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











			static void AgeReport()
			{


				string[] lines = File.ReadAllLines("faminefile.csv");


				int infants = 0, children = 0, teenage = 0, youngAdult = 0, adult = 0, olderAdult = 0, unknown = 0;


				foreach (string line in lines)
				{

					string[] columns = line.Split(',');


					string ageString = columns[2].Trim().ToLower();
					int age;

					if (ageString.StartsWith("age "))
					{

						age = int.Parse(ageString.Substring(4));
					}
					else if (ageString.StartsWith("Infant in months: "))
					{

						int months = int.Parse(ageString.Substring(18));
						age = months / 12;
					}


					else
					{

						age = -1;
					}


					if (age < 1)
					{
						infants++;
					}
					else if (age <= 12)
					{
						children++;
					}
					else if (age <= 19)
					{
						teenage++;
					}
					else if (age <= 29)
					{
						youngAdult++;
					}
					else if (age >= 50)
					{
						adult++;
					}
					else if (age >= 30)
					{
						olderAdult++;
					}
					else
					{
						unknown++;
					}
				}




				Console.WriteLine("Infants (<1 year): " + infants);
				Console.WriteLine("Children (1-12): " + children);
				Console.WriteLine("Teenage (12-19): " + teenage);
				Console.WriteLine("Young adult (20-29): " + youngAdult);
				Console.WriteLine("Adult (30+): " + adult);
				Console.WriteLine("Older adult (50+): " + olderAdult);
				Console.WriteLine("Unknown: " + unknown);




			}



		}

	
}	



	
	
