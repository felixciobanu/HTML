using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Ordering;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;
using UiS.Dat240.Lab3.Core.Domain.Fulfillment.Pipelines;

namespace UiS.Dat240.Lab3.Pages.Orders{

public class DetailsModel : PageModel
{
	private readonly IMediator _mediator;

	public DetailsModel(IMediator mediator) => _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));

	public Order Order { get; set; } = new();

	public string shipper { get; set; } = null!;

	public async Task OnGetAsync(Guid id){
		Order = await _mediator.Send(new Core.Domain.Ordering.Pipelines.GetOne.Request(id));
	}

	public async Task<IActionResult> OnPostAsync(string shipperName, Guid id)
	{
		Console.WriteLine(id);
		await _mediator.Send(new SetShipper.Request(shipperName, id));

		return RedirectToPage("./Index");
	}

}
}
