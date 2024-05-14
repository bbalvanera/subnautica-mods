using BulkCraft.Handlers;
using HarmonyLib;

namespace BulkCraft.Patches;

[HarmonyPatch(typeof(TooltipFactory))]
internal class TooltipFactoryPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(TooltipFactory.CraftRecipe))]
    public static void CraftRecipePostfix(TechType techType, TooltipData data)
    {
        CraftAmountHandler.main.UpdateCraftAmount(techType);
        ToolTipHandler.UpdateActionHint(techType, data.postfix);
    }
}