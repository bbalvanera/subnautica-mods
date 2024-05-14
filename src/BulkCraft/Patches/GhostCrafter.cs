using BulkCraft.Handlers;
using HarmonyLib;

namespace BulkCraft.Patches;

[HarmonyPatch(typeof(GhostCrafter))]
internal class GhostCrafterPatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(GhostCrafter.Craft))]
    public static bool CraftPrefix(GhostCrafter __instance, TechType techType)
    {
        if (CraftAmountHandler.main.IsHandlingTechType(techType))
        {
            var canCraft = CraftAmountHandler.main.CanCraftAmount(__instance.powerRelay);

            if (canCraft)
            {
                CrafterLogic.ConsumeEnergy(__instance.powerRelay, CraftAmountHandler.main.GetActualEnergyCost());
            }
            else
            {
                Plugin.ShowMessage(Language.main.Get("NotEnoughPower"));
                __instance.CancelInvoke(nameof(GhostCrafter.Craft));
                return false;
            }
        }

        return true;
    }
}