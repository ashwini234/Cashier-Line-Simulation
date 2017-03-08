using System;
using System.Collections.Generic;


namespace CashierLineSimulation
{ 
    //Main Grocery class that gives the simulation of Cashier line 
    public class GroceryMain
	{

		private static LinkedList<Customer> customerQueue = new LinkedList<Customer>();
		internal RegisterCollection registerCollection = null;

		public GroceryMain(RegisterCollection registerCollection)
		{
			this.registerCollection = registerCollection;
		}

		public virtual RegisterCollection RegisterCollection
		{
			get
			{
				return registerCollection;
			}
		}

		protected internal static LinkedList<Customer> CustomerQueue
		{
			get
			{
				return customerQueue;
			}
		}
		
		public static void Main(string[] args)
		{
			GroceryMain groceryMain = GroceryHelper.initiaize(args);
			RegisterCollection registerCollection = groceryMain.RegisterCollection;
			int totalTime = calculateTime(registerCollection, groceryMain);
			Console.WriteLine("Finished at: t=" + totalTime + " minutes");

            Console.ReadKey();
		}

		//Simulation logic : executed till customers are served and time is evaluated.

		public static int calculateTime(RegisterCollection registerCollection, GroceryMain groceryMain)
		{
			int time = 1;
			while (customerQueue.Count > 0 || registerCollection.RegisterinService)
			{
                List<Customer> customerListArrivedAtSameTime = new List<Customer>();
				GroceryHelper.collectSameTimeCustomers(customerListArrivedAtSameTime, time);
            
                customerListArrivedAtSameTime.Sort();
				registerCollection.serviceCustomer(customerListArrivedAtSameTime);
				int index = 0;
				while (index < registerCollection.Registers.Count)
				{
					LinkedList<Customer> customer = registerCollection.Registers[index].CustomerList;
					if (index == registerCollection.Registers.Count - 1)
					{
						GroceryHelper.traineeServe(customer);
					}
					else
					{
						GroceryHelper.expertServe(customer);
					}
					index++;
				}
				time++;
			}
			return time;
		}
	}

}