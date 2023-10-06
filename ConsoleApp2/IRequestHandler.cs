namespace ConsoleApp2
{
	public class Request
	{
		public int Amount { get; set; }

		public Request(int amount)
		{
			Amount = amount;
		}
	}

	public interface IRequestHandler
	{
		void Handle(Request request);
	}

	public class RequestCompositeHandler : IRequestHandler //Composite
	{
		public void Handle(Request request)
		{
			var handler1 = new Manager(1000);
			var handler2 = new Manager(3000);
			var handler3 = new Manager(8500);
			var endOfChain = new NullRequestHandler();

			handler1.RegisterNext(handler2);
			handler2.RegisterNext(handler3);
			handler3.RegisterNext(endOfChain);

			handler1.Handle(request);
		}
	}

	public abstract class RequestHandler : IRequestHandler
	{
		protected IRequestHandler Next;

		public abstract void Handle(Request request);

		public void RegisterNext(IRequestHandler next) => Next = next;
	}

	public class Manager : RequestHandler
	{
		private readonly int maxAmount;
		public Manager(int maxAmount)
		{
			this.maxAmount = maxAmount;
		}

		public override void Handle(Request request)
		{
			if (request.Amount > maxAmount)
			{
				Console.WriteLine($"Cannot approave this request because my max limit is {maxAmount}");
				Console.WriteLine("Forwarding the request to the next handler");
				Next.Handle(request);
			}
			else
			{
				Console.WriteLine("Approaved the request successfully!!!!");
			}
		}
	}

	public class NullRequestHandler : IRequestHandler
	{
		public void Handle(Request request) => Console.WriteLine($"Request {request.Amount} is denied!");
	}
}
