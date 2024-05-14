using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MarkAsRead.Helpers;
using Nautilus.Handlers;
using System.Reflection;

namespace MarkAsRead;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency(Nautilus.PluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BaseUnityPlugin
{
    public new static ManualLogSource Logger { get; private set; }

    private static Assembly ExecutingAssembly { get; } = Assembly.GetExecutingAssembly();

    private void Awake()
    {
        Logger = base.Logger;

        LanguageHelper.Init();
        Harmony.CreateAndPatchAll(ExecutingAssembly, $"{PluginInfo.PLUGIN_GUID}");

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
}