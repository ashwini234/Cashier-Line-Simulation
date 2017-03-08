using System;
using System.Collections.Generic;

namespace CashierLineSimulation
{
    //Register contains the list of customers

    public class Register : IComparable<Register>
	{

		private LinkedList<Customer> customerList = null;
		private int? index;

		public Register(int index)
		{
			this.index = index;
			customerList = new LinkedList<Customer>();
		}

		public virtual LinkedList<Customer> CustomerList
		{
			get
			{
				return customerList;
			}
		}

		public virtual int? Index
		{
			get
			{
				return index;
			}
		}

        //sorts the Register Objects by their size
        public int compare(Register o1, Register o2)
			{
				int? size = o1.customerList.Count;
				int? size1 = o2.customerList.Count;
				return size.Value.CompareTo(size1);
			}

        //sorts the Register Objects by their index
        public virtual int CompareTo(Register o)
		{
			return this.index.Value.CompareTo(o.index);
		}

       
    }

}