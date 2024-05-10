using MediatR;
using Tech_Inventory.Application.Common.Exceptions;

namespace Tech_Inventory.Application.Features.ObjectClassTypeFeature.GetObejctClassTypesList;

public sealed record GetObjectClassTypesListRequest : IRequest<ApiResponse>
{
}
