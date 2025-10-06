using MediatR;
using Microsoft.EntityFrameworkCore;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.Application.Features.Products.UpdateProducts;
using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.UpdateObyekt;

public class UpdateObyektHandler : IRequestHandler<UpdateObyektRequest, ApiResponse>
{
    private readonly ITechInventoryDB _context;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateObyektHandler(ITechInventoryDB context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task<ApiResponse> Handle(UpdateObyektRequest request, CancellationToken cancellationToken)
    {
        var type = ResponseType.Success;
        var Message = "Obyekt Not Found";
        var Id= 0;
        try
        {
            var currenObyekt = await _context
                .Obyekts
                .Include(x=>x.Akumalators)
                .Include(x=>x.Avtomats)
                .Include(x=>x.Boxes)
                .Include(x=>x.Brackets)
                .Include(x=>x.Cabels)
                .Include(x=>x.Cameras)
                .Include(x=>x.Connectors)
                .Include(x=>x.Counters)
                .Include(x=>x.Freezers)
                .Include(x=>x.GlueForNails)
                .Include(x=>x.Hooks)
                .Include(x=>x.Nails)
                .Include(x=>x.Projectors)
                .Include(x=>x.Racks)
                .Include(x=>x.Ribbons)
                .Include(x=>x.Servers)
                .Include(x=>x.Shelves)
                .Include(x=>x.Shells)
                .Include(x=>x.Sockets)
                .Include(x=>x.SpeedCheckings)
                .Include(x=>x.Stabilizers)
                .Include(x=>x.Stanchions)
                .Include(x=>x.SvetoforDetectors)
                .Include(x=>x.Switches)
                .Include(x=>x.TerminalServers)
                .Include(x=>x.VideoRecorders)
                .Include(x=>x.Ups)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

                if(currenObyekt == null) return ResponseHandler.GetAppResponse(type, new UpdateObyektResponse { Id = Id, Message = Message });

                currenObyekt.RegionId = request.RegionId;
                currenObyekt.DistrictId = request.DistrictId;
                currenObyekt.StreetId = request.StreetId;
                currenObyekt.ProjectId = request.ProjectId;
                currenObyekt.NumberOfOrderId = request.NumberOfOrderId;
                currenObyekt.ObjectClassTypeId = request.ObjectClassTypeId;
                currenObyekt.ObjectClassId = request.ObjectClassId;
                currenObyekt.NameAndAddress = request.NameAndAddress;
                currenObyekt.Latitude = request.Latitude;
                currenObyekt.Longitude = request.Longitude;
                currenObyekt.Info = request.Info;
                currenObyekt.ConnectionType = request.ConnectionType;

                currenObyekt.Akumalators.SyncCollection(
                    request.Akumalator,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Power = d.Power;
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                    },
                    d => new Akumalator
                    {
                        Power = d.Power,
                        Count = d.Count,
                        Info = d.Info
                    }
                );

            currenObyekt.Avtomats.SyncCollection(
                    request.Avtomat,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.ModelId = d.ModelId;
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                    },
                    d => new Avtomat
                    {
                        ModelId = d.ModelId,
                        Count = d.Count,
                        Info = d.Info
                    }
                );

            currenObyekt.Boxes.SyncCollection(
                   request.Box,
                   d => d.Id,
                   e => e.Id,
                   (entity, d) =>
                   {
                       entity.TypeId = d.TypeId;
                       entity.Meter = d.Meter;
                       entity.Info = d.Info;
                   },
                   d => new Box
                   {
                       TypeId = d.TypeId,
                       Meter = d.Meter,
                       Info = d.Info
                   }
               );

            currenObyekt.Brackets.SyncCollection(
                    request.Bracket,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.ModelId = d.ModelId;
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                    },
                    d => new Bracket
                    {
                        ModelId = d.ModelId,
                        Count = d.Count,
                        Info = d.Info
                    }
                );

            var cabelRequest = new List<UpdateCabel>();

            if(request.UtpCabel != null) cabelRequest.AddRange(request.UtpCabel.Select(d => { d.CabelType = CabelTypes.UTPable; return d; }));
            if(request.ElectrCabel != null) cabelRequest.AddRange(request.ElectrCabel.Select(d => { d.CabelType = CabelTypes.ElectricCable; return d; }));

            currenObyekt.Cabels.SyncCollection(
                  cabelRequest,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.CabelTypeId = d.CabelTypeId;
                      entity.CabelType = d.CabelType;
                      entity.ModelId = d.ModelId;
                      entity.Meter = d.Meter;
                      entity.Info = d.Info;
                  },
                  d => new Cabel
                  {
                      CabelTypeId = d.CabelTypeId,
                      CabelType = d.CabelType,
                      ModelId = d.ModelId,
                      Meter = d.Meter,
                      Info = d.Info
                  }
              );

            var cameraRequest = new List<UpdateCamera>();

            if (request.Camera != null) cameraRequest.AddRange(request.Camera.Select(d => { d.CameraType = CameraTypes.Camera; return d; }));
            if (request.AnprCamera != null) cameraRequest.AddRange(request.AnprCamera.Select(d => { d.CameraType = CameraTypes.ANPR; return d; }));
            if (request.SpeedCheckingCamera != null) cameraRequest.AddRange(request.SpeedCheckingCamera.Select(d => { d.CameraType = CameraTypes.Radar; return d; }));
            if (request.PtzCamera != null) cameraRequest.AddRange(request.PtzCamera.Select(d => { d.CameraType = CameraTypes.PTZ; return d; }));
            if (request.C327Camera != null) cameraRequest.AddRange(request.C327Camera.Select(d => { d.CameraType = CameraTypes.C327; return d; }));
            if (request.ChqbaCamera != null) cameraRequest.AddRange(request.ChqbaCamera.Select(d => { d.CameraType = CameraTypes.CHQBA; return d; }));
            if (request.C733Camera != null) cameraRequest.AddRange(request.C733Camera.Select(d => { d.CameraType = CameraTypes.C733; return d; }));

            currenObyekt.Cameras.SyncCollection(
                  cameraRequest,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.Ip = d.Ip;
                      entity.Info = d.Info;
                      entity.Name = d.Name;
                      entity.Status = d.Status;
                      entity.ModelId = d.ModelId;
                      entity.SerialNumber = d.SerialNumber;
                      entity.CameraType = d.CameraType;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = d.CameraType,
                  }
              );

            currenObyekt.Connectors.SyncCollection(
                    request.Connector,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                    },
                    d => new Connector
                    {
                        Count = d.Count,
                        Info = d.Info
                    }
                );

            currenObyekt.Counters.SyncCollection(
                    request.Counter,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.ModelId = d.ModelId;
                        entity.NumberOfConcern = d.NumberOfConcern;
                        entity.Info = d.Info;
                    },
                    d => new Counter
                    {
                        ModelId = d.ModelId,
                        NumberOfConcern = d.NumberOfConcern,
                        Info = d.Info
                    }
                );

            currenObyekt.Freezers.SyncCollection(
                    request.Freezer,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                    },
                    d => new Freezer
                    {
                        Count = d.Count,
                        Info = d.Info
                    }
                );

            currenObyekt.GlueForNails.SyncCollection(
                    request.GlueForNail,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.CountOfCrate = d.CountOfCrate;
                        entity.Info = d.Info;
                    },
                    d => new GlueForNail
                    {
                        CountOfCrate = d.CountOfCrate,
                        Info = d.Info
                    }
                );

            var hookRequest = new List<UpdateHook>();

            if (request.CabelHook != null) hookRequest.AddRange(request.CabelHook.Select(d => { d.HookType = HookTypes.CabelHook; return d; }));
            if (request.SipHook != null) hookRequest.AddRange(request.SipHook.Select(d => { d.HookType = HookTypes.SipHook; return d; }));

            currenObyekt.Hooks.SyncCollection(
                    hookRequest,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                        entity.HookType = d.HookType;
                    },
                    d => new Hook
                    {
                        Count = d.Count,
                        Info = d.Info,
                        HookType = d.HookType
                    }
                );

            currenObyekt.Nails.SyncCollection(
                    request.Nail,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Weight = d.Weight;
                        entity.Info = d.Info;
                    },
                    d => new Nail
                    {
                        Weight = d.Weight,
                        Info = d.Info
                    }
                );

            currenObyekt.Projectors.SyncCollection(
                    request.Projector,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.ModelId = d.ModelId;
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                    },
                    d => new Projector
                    {
                        ModelId = d.ModelId,
                        Count = d.Count,
                        Info = d.Info
                    }
                );

            var rackRequest = new List<UpdateRack>();

            if (request.MiniOpticRack != null) rackRequest.AddRange(request.MiniOpticRack.Select(d => { d.RackType = RackTypes.MiniOpticRack; return d; }));
            if (request.OdfOpticRack != null) rackRequest.AddRange(request.OdfOpticRack.Select(d => { d.RackType = RackTypes.ODFOpticRack; return d; }));

            currenObyekt.Racks.SyncCollection(
                    rackRequest,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.NumberOfFibers = d.NumberOfFibers;
                        entity.TypeOfAdapter = d.TypeOfAdapter;
                        entity.CountOfPorts = d.CountOfPorts;
                        entity.Info = d.Info;
                        entity.RackType = d.RackType;
                    },
                    d => new Rack
                    {
                        NumberOfFibers = d.NumberOfFibers,
                        TypeOfAdapter = d.TypeOfAdapter,
                        CountOfPorts = d.CountOfPorts,
                        Info = d.Info,
                        RackType = d.RackType,
                    }
                );

            currenObyekt.Ribbons.SyncCollection(
                    request.Ribbon,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Meter = d.Meter;
                        entity.Info = d.Info;
                    },
                    d => new Ribbon
                    {
                        Meter = d.Meter,
                        Info = d.Info
                    }
                );

            currenObyekt.Servers.SyncCollection(
                    request.Server,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Ip = d.Ip;
                        entity.Info = d.Info;
                    },
                    d => new Server
                    {
                        Ip = d.Ip,
                        Info = d.Info
                    }
                );

            var shelfRequest = new List<UpdateShelf>();

            if (request.CentralTelecomunicationShelf != null) shelfRequest.AddRange(request.CentralTelecomunicationShelf.Select(d => { d.ShelfType = ShelfTypes.CentralTelecommunicationShelf; return d; }));
            if (request.MainTelecomunicationShelf != null) shelfRequest.AddRange(request.MainTelecomunicationShelf.Select(d => { d.ShelfType = ShelfTypes.MainElectronicShelf; return d; }));
            if (request.DistributionShelf != null) shelfRequest.AddRange(request.DistributionShelf.Select(d => { d.ShelfType = ShelfTypes.DistributionShelf; return d; }));
            if (request.TelecomunicationShelf != null) shelfRequest.AddRange(request.TelecomunicationShelf.Select(d => { d.ShelfType = ShelfTypes.TelecommunicationShelf; return d; }));

            currenObyekt.Shelves.SyncCollection(
                    shelfRequest,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.BrandId = d.BrandId;
                        entity.SerialNumber = d.SerialNumber;
                        entity.Number = d.Number;
                        entity.Info = d.Info;
                        entity.ShelfType = d.ShelfType;
                    },
                    d => new Shelf
                    {
                        BrandId = d.BrandId,
                        SerialNumber = d.SerialNumber,
                        Number = d.Number,
                        Info = d.Info,
                        ShelfType = d.ShelfType
                    }
                );

            var shellRequest = new List<UpdateShell>();

            if (request.GofraShell != null) shellRequest.AddRange(request.GofraShell.Select(d => { d.ShellType = ShellTypes.GofraShell; return d; }));
            if (request.PlasticShell != null) shellRequest.AddRange(request.PlasticShell.Select(d => { d.ShellType = ShellTypes.PlasticShell; return d; }));

            currenObyekt.Shells.SyncCollection(
                    shellRequest,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Meter = d.Meter;
                        entity.Info = d.Info;
                        entity.ShellType = d.ShellType;
                    },
                    d => new Shell
                    {
                        Meter = d.Meter,
                        Info = d.Info,
                        ShellType = d.ShellType,
                    }
                );

            currenObyekt.Sockets.SyncCollection(
                   request.Socket,
                   d => d.Id,
                   e => e.Id,
                   (entity, d) =>
                   {
                       entity.ModelId = d.ModelId;
                       entity.Count = d.Count;
                       entity.Info = d.Info;
                   },
                   d => new Socket
                   {
                       ModelId = d.ModelId,
                       Count = d.Count,
                       Info = d.Info,
                   }
               );

            currenObyekt.SpeedCheckings.SyncCollection(
                   request.SpeedChecking,
                   d => d.Id,
                   e => e.Id,
                   (entity, d) =>
                   {
                       entity.ModelId = d.ModelId;
                       entity.SerialNumber = d.SerialNumber;
                       entity.Info = d.Info;
                   },
                   d => new SpeedChecking
                   {
                       ModelId = d.ModelId,
                       SerialNumber = d.SerialNumber,
                       Info = d.Info,
                   }
               );

            currenObyekt.Stabilizers.SyncCollection(
                   request.Stabilizer,
                   d => d.Id,
                   e => e.Id,
                   (entity, d) =>
                   {
                       entity.ModelId = d.ModelId;
                       entity.Power = d.Power;
                       entity.Info = d.Info;
                   },
                   d => new Stabilizer
                   {
                       ModelId = d.ModelId,
                       Power = d.Power,
                       Info = d.Info,
                   }
               );

            currenObyekt.Stanchions.SyncCollection(
                   request.Stanchion,
                   d => d.Id,
                   e => e.Id,
                   (entity, d) =>
                   {
                       entity.StanchionTypeId = d.StanchionTypeId;
                       entity.Count = d.Count;
                       entity.Info = d.Info;
                   },
                   d => new Stanchion
                   {
                       StanchionTypeId = d.StanchionTypeId,
                       Count = d.Count,
                       Info = d.Info,
                   }
               );

           

            var svetaforRequest = new List<UpdateSvetafor>();

            if (request.SvetaforDetektor != null) svetaforRequest.AddRange(request.SvetaforDetektor.Select(d => { d.SvetaforType = SvetaforTypes.SvetaforDetector; return d; }));
            if (request.SvetaforDetektorForCamera != null) svetaforRequest.AddRange(request.SvetaforDetektorForCamera.Select(d => { d.SvetaforType = SvetaforTypes.SvetaforDetectorForCamera; return d; }));

            currenObyekt.SvetoforDetectors.SyncCollection(
                  svetaforRequest,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.CountOfPorts = d.CountOfPorts;
                      entity.Info = d.Info;
                      entity.SvetaforType = d.SvetaforType;
                  },
                  d => new SvetoforDetector
                  {
                      ModelId = d.ModelId,
                      CountOfPorts = d.CountOfPorts,
                      Info = d.Info,
                      SvetaforType = d.SvetaforType,
                  }
              );

            var switchRequest = new List<UpdateSwitch>();

            if (request.SwitchPoe != null) switchRequest.AddRange(request.SwitchPoe.Select(d => { d.SwitchType = SwitchTypes.SwitchPoE; return d; }));
            if (request.SwitchKombo != null) switchRequest.AddRange(request.SwitchKombo.Select(d => { d.SwitchType = SwitchTypes.SwitchCombo; return d; }));

            currenObyekt.Switches.SyncCollection(
                  switchRequest,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.CountOfPorts = d.CountOfPorts;
                      entity.Info = d.Info;
                      entity.SwitchType = d.SwitchType;
                  },
                  d => new Switch
                  {
                      ModelId = d.ModelId,
                      CountOfPorts = d.CountOfPorts,
                      Info = d.Info,
                      SwitchType = d.SwitchType
                  }
              );

            currenObyekt.TerminalServers.SyncCollection(
                  request.TerminalServer,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.Info = d.Info;
                  },
                  d => new TerminalServer
                  {
                      ModelId = d.ModelId,
                      Info = d.Info,
                  }
              );

            currenObyekt.VideoRecorders.SyncCollection(
                  request.VideoRecorder,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.Info = d.Info;
                  },
                  d => new VideoRecorder
                  {
                      ModelId = d.ModelId,
                      Info = d.Info,
                  }
              );

            currenObyekt.Ups.SyncCollection(
                  request.Ups,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.Power = d.Power;
                      entity.Info = d.Info;
                  },
                  d => new Ups
                  {
                      ModelId = d.ModelId,
                      Power = d.Power,
                      Info = d.Info,
                  }
              );


            await _unitOfWork.Save(cancellationToken);

                Message = "Object has updated!";
                Id = currenObyekt.Id;

            return ResponseHandler.GetAppResponse(type, new UpdateObyektResponse { Id = Id, Message = Message });
        }
        catch (Exception ex)
        {

            return ResponseHandler.GetExceptionResponse(ex);
        }
    }
}
