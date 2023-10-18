using System.Collections.Generic;
using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Ordering;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UiS.Dat240.Lab3.Pages.Orders{
	public class IndexModel : PageModel
	{
		private readonly IMediator _mediator;

		public IndexModel(IMediator mediator) => _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));

		public List<Order> Orders { get; set; } = new();

		public async Task OnGetAsync(){
			Orders = await _mediator.Send(new Core.Domain.Ordering.Pipelines.Get.Request());

		}
	}
}