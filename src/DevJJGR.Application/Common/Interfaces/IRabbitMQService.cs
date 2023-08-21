using System;
namespace Donouts.Application.Common.Interfaces
{
	public interface IRabbitMQService
	{
		void SendMessage(string message);
	}
}

