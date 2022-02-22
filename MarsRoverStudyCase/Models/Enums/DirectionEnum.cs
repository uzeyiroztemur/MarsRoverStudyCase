using System;
using System.ComponentModel;

namespace MarsRoverStudyCase.Models.Enums
{
    public enum DirectionEnum
    {
        [Description("Kuzey")]
        North,

        [Description("Güney")]
        South,

        [Description("Doğu")]
        East,

        [Description("Batı")]
        West
    }
}
