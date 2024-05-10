using Tech_Inventory.Domain.Entities;

namespace Tech_Inventory.Application.Features.ObyektFeature.GetObyektProducts;

public sealed record GetObyektProductsResponse
{
    public int CameraCount { get; set; }
    public int SpeedCheckingCameraCount { get; set; }
    public int ANPRCameraCount { get; set; }
    public int PTZCameraCount { get; set; }
    public int C327CameraCount { get; set; }
    public int CHQBACameraCount { get; set; }
    public int C733CameraCount { get; set; }
    public int UpsCount { get; set; }
    public int SpeedCheckingCount { get; set; }
    public int SocketCount { get; set; }
    public int StanchionCount { get; set; }
    public int AvtomatCount { get; set; }   
    public int AkumalatorCount { get; set; }   
    public int ProjectorCount { get; set; }
    public int OdfOpticRackCount { get; set; }
    public int MiniOpticRackCount { get; set; }
    public int DistributionShelfCount { get; set; } 
    public int MainElectronicShelfCount { get; set; }
    public int TelecommunicationShelfCount { get; set; }
    public int CentralTelecommunicationShelfCount { get; set; }
    public int BoksCount { get; set; }
    public int SvetaforDetectorCount { get; set; }
    public int SvetaforDetectorForCameraCount { get; set; }
    public int ElectrCabelCount { get; set; }
    public int UtpCabelCount { get; set; }
    public int SwitchComboCount { get; set; }
    public int SwitchPoeCount { get; set; }
    public int StabilizerCount { get; set; }
    public int TerminalServerCount { get; set; }
    //
    public int BoxCount { get; set; }
    public int bracketCount { get; set; }
    public int ConnectorCount { get; set; }
    public int CounterCount { get; set; }
    public int SipHookCount { get; set; }
    public int CabelHookCount { get; set; }
    public int GofraShellCount { get; set; }
    public int PlasticShellCount { get; set; }
    public int VideoRecorderCount { get; set; }
    public int RibbonCount { get; set; }
    public int ServerCount { get; set; }
    public int FreezerCount { get; set; }
    public int NailCount { get; set; }
    public int GlueForNailCount { get; set; }
    public int MountingBoxCount { get; set; }
}
