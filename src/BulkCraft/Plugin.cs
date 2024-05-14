using BepInEx;
using BepInEx.Logging;
using BulkCraft.Helpers;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace BulkCraft;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus")]
public class Plugin : BaseUnityPlugin
{
    private static float lastTimeShowMessage;
    private static readonly float waitingForMessage = 1f;

    public new static ManualLogSource Logger { get; private set; }
    private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

    private void Awake()
    {
        Logger = base.Logger;

        LanguageHelper.Init();
        Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }

    // adapted from EasyCraft 
    public static bool ShowMessage(string str)
    {
        if (lastTimeShowMessage + waitingForMessage < Time.unscaledTime || lastTimeShowMessage > Time.unscaledTime)
        {
            ErrorMessage.AddWarning(str);
            lastTimeShowMessage = Time.unscaledTime;
            return true;
        }

        return false;
    }
}
