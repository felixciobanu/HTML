using System.Threading.Tasks;
using UiS.Dat240.Lab3.Core.Domain.Invoicing;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace UiS.Dat240.Lab3.Pages.Orders{

public class InvoiceModel : PageModel
{
	private readonly IMediator _mediator;

	public InvoiceModel(IMediator mediator) => _mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));

	public Invoice Invoice { get; set; } = new();

	public async Task OnGetAsync(Guid id){
		Invoice = await _mediator.Send(new Core.Domain.Invoicing.Pipelines.GetInvoice.Request(id));
	}
}
}