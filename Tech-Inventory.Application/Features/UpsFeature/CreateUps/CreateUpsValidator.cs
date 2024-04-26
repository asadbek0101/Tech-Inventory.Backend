using FluentValidation;

namespace Tech_Inventory.Application.Features.UpsFeature.CreateUps;

public class CreateUpsValidator : AbstractValidator<CreateUpsRequest>
{
    public CreateUpsValidator()
    {
    }
}
