using System;
using System.Collections.Generic;
using System.IO;

namespace CashierLineSimulation
{
    //GroceryHelper Class has all the methods which the main grocery class needs to assign registers and evaluate time.

    public class GroceryHelper
	{
        private const bool V = true;

        public static LinkedList<Customer> customerQueue = GroceryMain.CustomerQueue;
     
        public static void collectSameTimeCustomers(List<Customer> customerListArrivedAtSameTime, int time)
		{
			Customer customer = customerQueue.First.Value;
			while(customer != null && customer.TimeArrived == time)
            {

                //customerListArrivedAtSameTime.Add(customerQueue.RemoveFirst());
                //customerListArrivedAtSameTime.Remove(customerQueue.First.Value);
             
                customerListArrivedAtSameTime.AddRange(customerQueue);
                customer = customerQueue.First.Value;
                
            }

        }

        //serve the customer till items are not empty,once all the items are empty,remove that customer from the list.
        public static void expertServe(LinkedList<Customer> customer)
		{
			Customer cust = customer.First.Value;
			if (cust != null && cust.servedItems() == 0)
			{
				customer.RemoveFirst();
			}
		}
		
		public static void traineeServe(LinkedList<Customer> customer)
		{
			Customer cust = customer.First.Value;
			if (cust != null)
			{
				if (!cust.InService)
				{
					cust.InService = true;
				}
				else
				{
					if (cust.servedItems() == 0)
					{
						customer.RemoveFirst();
					}
					else
					{
						cust.InService = false; 
					}
				}
			}
		}
		
		public static GroceryMain initiaize(string[] args)
		{
			GroceryMain groceryMain = null;
			RegisterCollection grocery = null;
			string line = "";
			int firstLine = 0;
            StreamReader Reader = null;

            Console.WriteLine("Hint for text file input: input1.txt, input2.txt, input3.txt, input4.txt, input5.txt \n");
            
            Console.WriteLine("Please Enter The Name of text File: ");
          
            string input = Console.ReadLine();

            try
            {
               Reader = new StreamReader(@"C:\Users\sweety\Documents\Visual Studio 2015\Projects\CashierLineSimulation\" + input);

                // Reader = new StreamReader((file, args[0]));
            }
			catch (FileNotFoundException e)
			{
				Console.WriteLine("File not found-->" + e.Message);
			 
				Environment.Exit(-1);
			}
			try
			{
				while (!string.ReferenceEquals((line = Reader.ReadLine()), null))
				{
					if (firstLine == 0)
					{
						try
						{
							int Reg = int.Parse(line);
							grocery = new RegisterCollection(Reg);
						}
						catch (System.FormatException e)
						{
							Console.WriteLine("Error in parsing number of registers->" + e.Message);
						}
					}
					else
					{
						Customer customer = buildCustomerObjects(line);
						customerQueue.AddLast(customer);
					}
					firstLine++;
				}

               
				groceryMain = new GroceryMain(grocery);
			}
			catch (IOException e)
			{
				Console.WriteLine("Exception in reading the file" + e.Message);
			
				Environment.Exit(-1);
			}


			return groceryMain;
		}
		
		public static Customer buildCustomerObjects(string line)
		{
			string[] items = line.Split(" ", V);
			if (items.Length != 3)
			{
				Console.WriteLine("Error in Input-->" + line);
			
				Environment.Exit(-1);
			}
			if (items[0].Equals(Type.A.ToString()))
			{
				return new Customer(Type.A, int.Parse(items[1]), int.Parse(items[2]));
			}
			else if (items[0].Equals(Type.B.ToString()))
			{
				return new Customer(Type.B, int.Parse(items[1]), int.Parse(items[2]));
			}
			else
			{
				Console.WriteLine("Customer Type is Invalid");
			
				Environment.Exit(-1);
				return null;
			}
		}
	}

}