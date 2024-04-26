using FluentValidation;

namespace Tech_Inventory.Application.Features.AvtomatFeature.UpdateAvtomat;

public class UpdateAvtomatValidator : AbstractValidator<UpdateAvtomatRequest>
{
    public UpdateAvtomatValidator()
    {
        RuleFor(x => x.Name).NotEmpty();    
    }
}
