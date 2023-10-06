namespace ConsoleApp2
{
	public interface ITimeOffRequestHandler
	{
		void RequestTimeOff(TimeOffRequest timeOffRequest);
	}

	public class TimeOffRequest
	{

	}

	public class Organization
	{

	}

	public abstract class TimeOffRequestHandler : ITimeOffRequestHandler
	{
		private ITimeOffRequestHandler _timeOffRequestHandler;

		protected abstract void HandleRequest(TimeOffRequest timeOffRequest);

		public void SetManager(ITimeOffRequestHandler timeOffRequestHandler)
		{
			_timeOffRequestHandler = timeOffRequestHandler;
		}

		public void RequestTimeOff(TimeOffRequest timeOffRequest)
		{
			HandleRequest(timeOffRequest);

			if (_timeOffRequestHandler != null)
				_timeOffRequestHandler.RequestTimeOff(timeOffRequest);
		}
	}

	public class Employee : TimeOffRequestHandler
	{
		private readonly IEnumerable<string> roles;

		public string Email { get; set; }

		public Employee(string email, IEnumerable<string> roles)
		{
			Email = email;
			this.roles = roles;
		}

		protected override void HandleRequest(TimeOffRequest timeOffRequest)
		{
			if (roles.Contains("Admin"))
			{
				Console.WriteLine($"Handled time off request successfully! by {Email}");
				// send confirmation email
			}
			else
			{
				Console.WriteLine($"Insufficient priviliges to handled time off request by {Email}");
			}
		}
	}
}