using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SampleProject.Enums
{
    public enum DirectionTypes
    {
        [Description("N")]
        North = 1,
        [Description("E")]
        East = 2,
        [Description("S")]
        South = 3,
        [Description("W")]
        West = 4
    }
}
