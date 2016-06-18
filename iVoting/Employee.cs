using System;
namespace iVoting
{
	public class Employee
	{
		public string Name { get; set; }
	}

	public class EmployeeManager {

		public Employee Login (string account, string password) {
			return new Employee {Name = @"Liddle Fang" };
		}
	
	}
}

