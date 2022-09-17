using System.ComponentModel;

namespace Domain.Enums
{
    public enum EventType
    {
        [Description("online paid")]
        OnlinePaid = 1,
        [Description("free online")]
        FreeOnline = 2,
        [Description("face-to-face paid")]
        FaceToFacePaid = 3,
        [Description("free face-to-face")]
        FreeFaceToFace = 4
    }
}