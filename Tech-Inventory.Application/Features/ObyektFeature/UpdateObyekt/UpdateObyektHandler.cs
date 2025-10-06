using MediatR;
using Microsoft.EntityFrameworkCore;
using Minio.DataModel.Notification;
using Tech_Inventory.Application.Common.Exceptions;
using Tech_Inventory.Application.Common.Helpers;
using Tech_Inventory.Application.Common.Interfaces;
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

            currenObyekt.Cabels.SyncCollection(
                  request.ElectrCabel,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.CabelTypeId = d.CabelTypeId;
                      entity.CabelType = CabelTypes.ElectricCable;
                      entity.ModelId = d.ModelId;
                      entity.Meter = d.Meter;
                      entity.Info = d.Info;
                  },
                  d => new Cabel
                  {
                      CabelTypeId = d.CabelTypeId,
                      CabelType = CabelTypes.ElectricCable,
                      ModelId = d.ModelId,
                      Meter = d.Meter,
                      Info = d.Info
                  }
              );

            currenObyekt.Cabels.SyncCollection(
                  request.UtpCabel,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.CabelTypeId = d.CabelTypeId;
                      entity.CabelType = CabelTypes.UTPable;
                      entity.ModelId = d.ModelId;
                      entity.Meter = d.Meter;
                      entity.Info = d.Info;
                  },
                  d => new Cabel
                  {
                      CabelTypeId = d.CabelTypeId,
                      CabelType = CabelTypes.UTPable,
                      ModelId = d.ModelId,
                      Meter = d.Meter,
                      Info = d.Info
                  }
              );

            currenObyekt.Cameras.SyncCollection(
                  request.Camera,
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
                      entity.CameraType = CameraTypes.Camera;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = CameraTypes.Camera,
                  }
              );

            currenObyekt.Cameras.SyncCollection(
                  request.AnprCamera,
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
                      entity.CameraType = CameraTypes.ANPR;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = CameraTypes.ANPR,
                  }
              );

            currenObyekt.Cameras.SyncCollection(
                  request.SpeedCheckingCamera,
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
                      entity.CameraType = CameraTypes.Radar;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = CameraTypes.Radar,
                  }
              );

            currenObyekt.Cameras.SyncCollection(
                  request.PtzCamera,
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
                      entity.CameraType = CameraTypes.PTZ;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = CameraTypes.PTZ,
                  }
              );

            currenObyekt.Cameras.SyncCollection(
                  request.C327Camera,
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
                      entity.CameraType = CameraTypes.C327;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = CameraTypes.C327,
                  }
              );

            currenObyekt.Cameras.SyncCollection(
                  request.ChqbaCamera,
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
                      entity.CameraType = CameraTypes.CHQBA;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = CameraTypes.CHQBA,
                  }
              );

            currenObyekt.Cameras.SyncCollection(
                  request.C733Camera,
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
                      entity.CameraType = CameraTypes.C733;
                  },
                  d => new Camera
                  {
                      Ip = d.Ip,
                      Info = d.Info,
                      Name = d.Name,
                      Status = d.Status,
                      ModelId = d.ModelId,
                      SerialNumber = d.SerialNumber,
                      CameraType = CameraTypes.C733,
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

            currenObyekt.Hooks.SyncCollection(
                    request.CabelHook,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                        entity.HookType = HookTypes.CabelHook;
                    },
                    d => new Hook
                    {
                        Count = d.Count,
                        Info = d.Info,
                        HookType = HookTypes.CabelHook
                    }
                );

            currenObyekt.Hooks.SyncCollection(
                    request.SipHook,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Count = d.Count;
                        entity.Info = d.Info;
                        entity.HookType = HookTypes.SipHook;
                    },
                    d => new Hook
                    {
                        Count = d.Count,
                        Info = d.Info,
                        HookType = HookTypes.SipHook
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

            currenObyekt.Racks.SyncCollection(
                    request.OdfOpticRack,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.NumberOfFibers = d.NumberOfFibers;
                        entity.TypeOfAdapter = d.TypeOfAdapter;
                        entity.CountOfPorts = d.CountOfPorts;
                        entity.Info = d.Info;
                        entity.RackType = RackTypes.ODFOpticRack;
                    },
                    d => new Rack
                    {
                        NumberOfFibers = d.NumberOfFibers,
                        TypeOfAdapter = d.TypeOfAdapter,
                        CountOfPorts = d.CountOfPorts,
                        Info = d.Info,
                        RackType = RackTypes.ODFOpticRack,
                    }
                );

            currenObyekt.Racks.SyncCollection(
                    request.MiniOpticRack,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.NumberOfFibers = d.NumberOfFibers;
                        entity.TypeOfAdapter = d.TypeOfAdapter;
                        entity.CountOfPorts = d.CountOfPorts;
                        entity.Info = d.Info;
                        entity.RackType = RackTypes.MiniOpticRack;
                    },
                    d => new Rack
                    {
                        NumberOfFibers = d.NumberOfFibers,
                        TypeOfAdapter = d.TypeOfAdapter,
                        CountOfPorts = d.CountOfPorts,
                        Info = d.Info,
                        RackType = RackTypes.MiniOpticRack,
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

            currenObyekt.Shelves.SyncCollection(
                    request.CentralTelecomunicationShelf,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.BrandId = d.BrandId;
                        entity.SerialNumber = d.SerialNumber;
                        entity.Number = d.Number;
                        entity.Info = d.Info;
                        entity.ShelfType = ShelfTypes.CentralTelecommunicationShelf;
                    },
                    d => new Shelf
                    {
                        BrandId = d.BrandId,
                        SerialNumber = d.SerialNumber,
                        Number = d.Number,
                        Info = d.Info,
                        ShelfType = ShelfTypes.CentralTelecommunicationShelf,
                    }
                );

            currenObyekt.Shelves.SyncCollection(
                    request.MainTelecomunicationShelf,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.BrandId = d.BrandId;
                        entity.SerialNumber = d.SerialNumber;
                        entity.Number = d.Number;
                        entity.Info = d.Info;
                        entity.ShelfType = ShelfTypes.MainElectronicShelf;
                    },
                    d => new Shelf
                    {
                        BrandId = d.BrandId,
                        SerialNumber = d.SerialNumber,
                        Number = d.Number,
                        Info = d.Info,
                        ShelfType = ShelfTypes.MainElectronicShelf,
                    }
                );

            currenObyekt.Shelves.SyncCollection(
                   request.DistributionShelf,
                   d => d.Id,
                   e => e.Id,
                   (entity, d) =>
                   {
                       entity.BrandId = d.BrandId;
                       entity.SerialNumber = d.SerialNumber;
                       entity.Number = d.Number;
                       entity.Info = d.Info;
                       entity.ShelfType = ShelfTypes.DistributionShelf;
                   },
                   d => new Shelf
                   {
                       BrandId = d.BrandId,
                       SerialNumber = d.SerialNumber,
                       Number = d.Number,
                       Info = d.Info,
                       ShelfType = ShelfTypes.DistributionShelf,
                   }
               );
            
            currenObyekt.Shelves.SyncCollection(
                   request.TelecomunicationShelf,
                   d => d.Id,
                   e => e.Id,
                   (entity, d) =>
                   {
                       entity.BrandId = d.BrandId;
                       entity.SerialNumber = d.SerialNumber;
                       entity.Number = d.Number;
                       entity.Info = d.Info;
                       entity.ShelfType = ShelfTypes.TelecommunicationShelf;
                   },
                   d => new Shelf
                   {
                       BrandId = d.BrandId,
                       SerialNumber = d.SerialNumber,
                       Number = d.Number,
                       Info = d.Info,
                       ShelfType = ShelfTypes.TelecommunicationShelf,
                   }
               );

            currenObyekt.Shells.SyncCollection(
                    request.GofraShell,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Meter = d.Meter;
                        entity.Info = d.Info;
                        entity.ShellType = ShellTypes.GofraShell;
                    },
                    d => new Shell
                    {
                        Meter = d.Meter,
                        Info = d.Info,
                        ShellType = ShellTypes.GofraShell,
                    }
                );

            currenObyekt.Shells.SyncCollection(
                    request.PlasticShell,
                    d => d.Id,
                    e => e.Id,
                    (entity, d) =>
                    {
                        entity.Meter = d.Meter;
                        entity.Info = d.Info;
                        entity.ShellType = ShellTypes.PlasticShell;
                    },
                    d => new Shell
                    {
                        Meter = d.Meter,
                        Info = d.Info,
                        ShellType = ShellTypes.PlasticShell,
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

            currenObyekt.SvetoforDetectors.SyncCollection(
                  request.SvetaforDetektor,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.CountOfPorts = d.CountOfPorts;
                      entity.Info = d.Info;
                      entity.SvetaforType = SvetaforTypes.SvetaforDetector;
                  },
                  d => new SvetoforDetector
                  {
                      ModelId = d.ModelId,
                      CountOfPorts = d.CountOfPorts,
                      Info = d.Info,
                      SvetaforType = SvetaforTypes.SvetaforDetector,
                  }
              );

            currenObyekt.SvetoforDetectors.SyncCollection(
                  request.SvetaforDetektorForCamera,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.CountOfPorts = d.CountOfPorts;
                      entity.Info = d.Info;
                      entity.SvetaforType = SvetaforTypes.SvetaforDetectorForCamera;
                  },
                  d => new SvetoforDetector
                  {
                      ModelId = d.ModelId,
                      CountOfPorts = d.CountOfPorts,
                      Info = d.Info,
                      SvetaforType = SvetaforTypes.SvetaforDetectorForCamera,
                  }
              );

            currenObyekt.Switches.SyncCollection(
                  request.SwitchPoe,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.CountOfPorts = d.CountOfPorts;
                      entity.Info = d.Info;
                      entity.SwitchType = SwitchTypes.SwitchPoE;
                  },
                  d => new Switch
                  {
                      ModelId = d.ModelId,
                      CountOfPorts = d.CountOfPorts,
                      Info = d.Info,
                      SwitchType = SwitchTypes.SwitchPoE
                  }
              );

            currenObyekt.Switches.SyncCollection(
                  request.SwitchKombo,
                  d => d.Id,
                  e => e.Id,
                  (entity, d) =>
                  {
                      entity.ModelId = d.ModelId;
                      entity.CountOfPorts = d.CountOfPorts;
                      entity.Info = d.Info;
                      entity.SwitchType = SwitchTypes.SwitchCombo;
                  },
                  d => new Switch
                  {
                      ModelId = d.ModelId,
                      CountOfPorts = d.CountOfPorts,
                      Info = d.Info,
                      SwitchType = SwitchTypes.SwitchCombo
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
