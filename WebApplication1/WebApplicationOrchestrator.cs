namespace WebApplication1
{
	public abstract class WebApplicationOrchestrator
	{
		protected WebApplicationOrchestrator Successor;
		protected WebApplicationOrchestrator(WebApplicationOrchestrator successor)
		{
			Successor = successor;
		}

		public void Orchestrate(WebApplication app)
		{
			Orchestrate1(app);

			if (Successor != null)
			{
				Successor.Orchestrate(app);
			}
		}

		public abstract void Orchestrate1(WebApplication app);
	}

	public class SwaggerOrchestrator : WebApplicationOrchestrator
	{
		public SwaggerOrchestrator(WebApplicationOrchestrator successor) : base(successor)
		{
		}

		public override void Orchestrate1(WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
		}
	}

	public class HttpsRedirectionOrchestrator : WebApplicationOrchestrator
	{
		public HttpsRedirectionOrchestrator(WebApplicationOrchestrator successor) : base(successor)
		{
		}

		public override void Orchestrate1(WebApplication app)
		{
			app.UseHttpsRedirection();
		}
	}

	public class AppRunOrchestrator : WebApplicationOrchestrator
	{
		public AppRunOrchestrator(WebApplicationOrchestrator successor) : base(successor)
		{
		}

		public override void Orchestrate1(WebApplication app)
		{
			app.Run();
		}
	}

	public class ControllersOrchestrator : WebApplicationOrchestrator
	{
		public ControllersOrchestrator(WebApplicationOrchestrator successor) : base(successor)
		{
		}

		public override void Orchestrate1(WebApplication app)
		{
			app.MapControllers();
		}
	}

	public class AuthOrchestrator : WebApplicationOrchestrator
	{
		public AuthOrchestrator(WebApplicationOrchestrator successor) : base(successor)
		{
		}

		public override void Orchestrate1(WebApplication app)
		{
			app.UseAuthorization();
		}
	}
}