using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Fulfillment;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace UiS.Dat240.Lab3.Pages.Orders{

	public class OfferModel : PageModel
	{
		private readonly IMediator _mediator;

		public OfferModel(IMediator mediator) => _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));

		public Offer Offer { get; set; } = new();

		public async Task OnGetAsync(Guid id){
			Offer = await _mediator.Send(new Core.Domain.Fulfillment.Pipelines.GetOffer.Request(id));
		}
	}
}