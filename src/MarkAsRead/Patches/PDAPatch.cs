using HarmonyLib;
using System.Linq;
using TabGroup = NotificationManager.Group;

namespace MarkAsRead.Patches;

[HarmonyPatch(typeof(uGUI_PDA))]
public class PDAPatch
{
    [HarmonyPostfix, HarmonyPatch(nameof(uGUI_PDA.OnToolbarClick))]
    public static void OnToolbarClick(int index, int button)
    {
        var tab = GetTabName(index);

        if (button != 1 || tab == TabGroup.Undefined)
            return;

        NotificationManager.main.notifications
            .Keys
            .Where(n => n.group == tab)
            .ToArray()
            .ForEach(id =>
            {
                NotificationManager.main.notifications.Remove(id);
                NotificationManager.main.NotifyRemove(id);
            });
    }

    [HarmonyPostfix, HarmonyPatch(nameof(uGUI_PDA.GetToolbarTooltip))]
    static void GetToolbarTooltip(int index, TooltipData data)
    {
        var tab = GetTabName(index);
        var count = NotificationManager.main.GetCount(tab);

        if (tab != TabGroup.Undefined && count > 0)
        {
            data.prefix
                .Append($"\n<size=20> </size>")
                .Append($"<sprite name=\"MouseButtonRight\" color=#ADF8FFFF>")
                .Append($" - <color=#00FFFFFF>{Language.main.Get("MarkAsRead")}</color>");
        }
    }

    private static TabGroup GetTabName(int idx)
    {
        return idx switch
        {
            0 => TabGroup.Inventory,
            1 => TabGroup.Blueprints,
            3 => TabGroup.Gallery,
            4 => TabGroup.Log,
            5 => TabGroup.Encyclopedia,
            _ => TabGroup.Undefined
        };
    }
}
