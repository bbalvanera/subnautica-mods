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

    public static string ScrollUpIcon => ToText(57406);
    public static string ScrollDownIcon => ToText(57407);

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

    private static string ToText(int utf32) => char.ConvertFromUtf32(utf32);
}