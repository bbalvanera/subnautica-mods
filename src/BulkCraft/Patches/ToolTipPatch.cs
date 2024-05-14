using BulkCraft.Handlers;
using HarmonyLib;

namespace BulkCraft.Patches;

[HarmonyPatch(typeof(uGUI_Tooltip))]
internal class ToolTipPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(uGUI_Tooltip.OnUpdate))]
    public static void OnUpdatePostfix() => CraftAmountHandler.main.ResetIfToolTipHidden();
}