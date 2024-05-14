using BulkCraft.Handlers;
using HarmonyLib;

namespace BulkCraft.Patches;

[HarmonyPatch(typeof(Crafter))]
internal class CrafterPatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(Crafter.Craft))]
    public static void CraftPrefix(TechType techType, ref float duration)
    {
        if (CraftAmountHandler.main.IsHandlingTechType(techType))
            duration = CraftAmountHandler.main.GetActualCraftDuration(duration);
    }
}