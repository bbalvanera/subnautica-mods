using BulkCraft.Handlers;
using HarmonyLib;

namespace BulkCraft.Patches;

[HarmonyPatch(typeof(uGUI_CraftingMenu))]
internal class CraftingMenuPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(uGUI_CraftingMenu.Open))]
    public static void OpenPostfix(CraftTree.Type treeType) => CraftAmountHandler.main.SetCurrentTreeType(treeType);
}