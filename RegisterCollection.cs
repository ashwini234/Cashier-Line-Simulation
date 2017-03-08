using System;
using System.Collections.Generic;

namespace CashierLineSimulation
{
    //RegisterCollection class contains list of Registers and registerList will hold Register Objects.
    public class RegisterCollection
	{

		private IList<Register> registerList = new List<Register>();

        //inititalizes the RegisterCollection with the number of registers and adds it to list of register
        public RegisterCollection(int registers)
		{
			for (int i = 0; i < registers; i++)
			{
				registerList.Add(new Register(i));
			}
		}
		
		public virtual IList<Register> Registers
		{
			get
			{
				return registerList;
			}
		}

        //chooses a register for type A customer
        public virtual Register ShortRegisterBySize
		{
			get
			{
                List<Register> sortedList = new List<Register>();
				foreach (Register register in registerList)
				{
					sortedList.Add(register);
                }
               
               sortedList.Sort();
				return sortedList[0];
			}
		}
         
            
        public virtual Register ShortRegisterByIndex
		{
			get
			{
				List<Register> sortedListByIndex = new List<Register>();
				foreach (Register register in registerList)
				{
					sortedListByIndex.Add(register);
				}

				sortedListByIndex.Sort();
				return sortedListByIndex[0];
			}
		}

		
		public virtual Register RegisterLeastItemsEnd
		{
			get
			{
				IDictionary<Customer, Register> custRegMap = new Dictionary<Customer, Register>();
				List<Register> emptyList = new List<Register>();
				List<Customer> listWithItems = new List<Customer>();
				foreach (Register register in registerList)
				{
					if (register.CustomerList.Count == 0)
					{
						emptyList.Add(register);
					}
					else
					{
						Customer lastCustomer = getLastElement(register.CustomerList);
						custRegMap[lastCustomer] = register;
						listWithItems.Add(lastCustomer);
					}
				}
				if (emptyList.Count > 0)
				{
					emptyList.Sort();
					return emptyList[0];
				}
				else
				{
					listWithItems.Sort();
					return custRegMap[listWithItems[0]];
				}
			}
		}
		
        // to find last element in list 
		private Customer getLastElement(LinkedList<Customer> customerList)
		{
			Customer lastCustomer = null;
			IEnumerator<Customer> iterator = customerList.GetEnumerator();
			while (iterator.MoveNext())
			{
				lastCustomer = iterator.Current;
			}
			return lastCustomer;
		}
		
		public virtual void serviceCustomer(IList<Customer> customerList)
		{
			foreach (Customer customer in customerList)
			{
				if (customer.Type.Equals(Type.A))
				{
					Register shortestRegister = ShortRegisterBySize;
					shortestRegister.CustomerList.AddLast(customer);
				}
				else
				{
					Register registerwithleastItems = RegisterLeastItemsEnd;
					registerwithleastItems.CustomerList.AddLast(customer);
				}
			}
		}

        //Keeps track of registers in the store and checks if it is serving customer
        public virtual bool RegisterinService
		{
			get
			{
				foreach (Register register in registerList)
				{
					if (register.CustomerList.Count != 0)
					{
						return true;
					}
				}
				return false;
			}
		}

	}

}