using System.Reflection.PortableExecutable;
/* Donnacha Kennedy
 * S00239822
 * CA3
 */


namespace CA3
{
	public class vars ///this class contains variables used in the age report
	{
		public static int unknown = 0, infants = 0, children = 0, teenage = 0, youngAdult = 0, adult = 0, olderAdult = 0;

	}
    internal class Program
	{
		static void Main(string[] args)

		{


			DisplayMenu();




		}
		static void DisplayMenu()
		{// Main menu displaying options for CA 
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
		{ // Ship report showing the names of the passengers on the ship that the user enters


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



		}


		static void OccupationReport()
		{ // when the user selects this option, all passengers occupations are shown



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
			Dictionary<string, int> occupations = new Dictionary<string, int>();
			using (StreamReader reader = new StreamReader("faminefile.csv"))
			{
				// Process each passenger record in the CSV file
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					string[] fields = line.Split(',');
					string ageString = fields[2];
					int age;

					try
					{ //check if the age starts with infant
						if (ageString.ToString().StartsWith("Infant"))
						{
							age = 0;
						}
						else
						  //skips the "age " to just the get the age
							age = int.Parse(ageString.ToString().Substring(4));
						
					}
					catch
					{
						age = -1;
					}
					




					// if statement to sort the ages
					if (age == -1)
					{
						vars.unknown++;

					}


					else if (age == 0)
					{
						vars.infants++;
					}
					else if (age >= 1 && age <= 12)
					{
						vars.children++;
					}
					else if (age >= 13 && age <= 19)
					{

						vars.teenage++;
					}
					else if (age >= 20 && age <= 29)
					{
						vars.youngAdult++;
					}
					else if (age >= 30 && age <= 49)
					{
						vars.adult++;
					}
					else if (age >= 50)
					{
						vars.olderAdult++;
					}
				}
			}
		

			// Print the age report
				Console.WriteLine("Age Report");
				Console.WriteLine("----------");
				Console.WriteLine($"Unknown: {vars.unknown}");
				Console.WriteLine($"Infants (0 years): {vars.infants}");
				Console.WriteLine($"Children (1-12 years): {vars.children}");
				Console.WriteLine($"Teenagers (13-19 years): {vars.teenage}");
				Console.WriteLine($"Young adults (20-29 years): {vars.youngAdult}");
				Console.WriteLine($"Adults (30-49 years): {vars.adult}");
				Console.WriteLine($"Older adults (50-64 years): {vars.olderAdult}");
				
		}
	}

}

























