using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CA3
{
	internal class shipreport
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
		public class Passenger
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public Passenger(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}

	public class Ship
	{
		public string Name { get; set; }
		public string DeparturePort { get; set; }
		public string ArrivalDate { get; set; }
		public List<Passenger> Passengers { get; set; }

		public int PassengerCount
		{
			get { return Passengers.Count; }
		}

		public Ship(string name, string departurePort, string arrivalDate, List<Passenger> passengers)
		{
			Name = name;
			DeparturePort = departurePort;
			ArrivalDate = arrivalDate;
			Passengers = passengers;
		}

		public Ship(string name, string departurePort, string arrivalDate, string passengersString, int capacity)
		{
			Name = name;
			DeparturePort = departurePort;
			ArrivalDate = arrivalDate;

			Passengers = new List<Passenger>();
			var passengers = passengersString.Split(';');
			foreach (var passenger in passengers)
			{
				var names = passenger.Trim().Split(' ');
				if (names.Length == 2)
				{
					Passengers.Add(new Passenger(names[0], names[1]));
				}
			}

			// Fill up the remaining capacity with empty passengers
			while (Passengers.Count < capacity)
			{
				Passengers.Add(new Passenger("", ""));
			}
		}
	}

}
