using System;

namespace CashierLineSimulation
{
    //Customer class tell us about the type of customer,if it is currently being served or not and count of items.

    public class Customer : IComparable<Customer>
	{

		private int? itemCount; 
		private Type type;
		private bool inService;
		private int timeArrived;


		public Customer(Type type, int timeArrived, int? itemCount)
		{
			this.type = type;
			this.timeArrived = timeArrived;
			this.itemCount = itemCount;
		}

		public virtual int? ItemCount
		{
			get
			{
				return itemCount.Value;
			}
			set
			{
				this.itemCount = value;
			}
		}

		public virtual Type Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}


		public virtual bool InService
		{
			get
			{
				return inService;
			}
			set
			{
				this.inService = value;
			}
		}


		public virtual int TimeArrived
		{
			get
			{
				return timeArrived;
			}
			set
			{
				this.timeArrived = value;
			}
		}


		public virtual int? servedItems()
		{
			return --this.itemCount;
        }
		

        //compareTo compares the customers based on the item counts, if the count is same then comparing them for type.

        public virtual int CompareTo(Customer o)
		{
			int val = 0;
				val = this.itemCount.Value.CompareTo(o.itemCount);
			if (val == 0)
			{
				val = this.type.CompareTo(o.type);
			}
			return val;
		}

	}
	public enum Type
	{
		A,
		B
	}

}