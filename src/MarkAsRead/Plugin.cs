using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;

namespace MarkAsRead;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus")]
public class Plugin : BaseUnityPlugin
{
    public new static ManualLogSource Logger { get; private set; }

    private static Assembly ExecutingAssembly { get; } = Assembly.GetExecutingAssembly();

    private void Awake()
    {
        Logger = base.Logger;

        SetMessages();

        Harmony.CreateAndPatchAll(ExecutingAssembly, $"{PluginInfo.PLUGIN_GUID}");
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    private void SetMessages()
    {
        LanguageHandler.SetLanguageLine("ClearNotifications", "mark as read", "English");
        LanguageHandler.SetLanguageLine("ClearNotifications", "marcar como leído", "Spanish (Latin America)");
        LanguageHandler.SetLanguageLine("ClearNotifications", "marcar como leído", "Spanish");

        Plugin.Logger.LogDebug($"Current Language is: {Language.main.currentLanguage}");
    }
}