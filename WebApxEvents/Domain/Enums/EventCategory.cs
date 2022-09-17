using System.ComponentModel;

namespace Domain.Enums
{
    public enum EventCategory
    {
        [Description("social events")]
        Social = 1,
        [Description("corporate events")]
        Corporate = 2,
        [Description("religious events")]
        Religious = 3,
        [Description("academic and educational events")]
        AcademicEducational = 3,
        [Description("cultural and entertainment events")]
        CulturalEntertainment = 4
    }
}