using System;

namespace Unchord
{
    [Flags]
    public enum UIState
    {
        FlagShowing = 0b01,
        FlagTransiting = 0b10,

        Hidden = 0b00,
        Hiding = 0b10,

        Shown = 0b01,
        Showing = 0b11,
    }
}