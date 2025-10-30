using System;
using UnityEngine;

namespace BulkCraft.Helpers;

internal static class MouseHelper
{
    public enum ScrollDir
    {
        None,
        Up,
        Down,
    }

    public static string ScrollUpIcon => "<sprite name=\"MouseWheelUp\" color=#ADF8FFFF>";
    public static string ScrollDownIcon => "<sprite name=\"MouseWheelDown\" color=#ADF8FFFF>";

    public static ScrollDir GetScrollDir()
    {
        var scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        return scroll switch
        {
            0 => ScrollDir.None,
            < 0 => ScrollDir.Down,
            > 0 => ScrollDir.Up,
            _ => throw new NotImplementedException(),
        };
    }
}