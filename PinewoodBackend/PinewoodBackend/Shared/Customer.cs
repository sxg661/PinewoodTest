namespace PinewoodBackend.Shared
{
	public class Customer
	{
		public static string NewId => Guid.NewGuid().ToString();
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
