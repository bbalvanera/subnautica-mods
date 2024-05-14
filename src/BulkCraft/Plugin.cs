using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
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

        SetMessages();

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

    private void SetMessages()
    {
        // English
        LanguageHandler.SetLanguageLine("NotEnoughPower", "Not enough power to craft the selected amount!", "English");
        LanguageHandler.SetLanguageLine("ChangeItemAmount", "change quantity", "English");

        // Spanish
        LanguageHandler.SetLanguageLine("NotEnoughPower", "No hay suficiente energía para tanta cantidad!", "Spanish");
        LanguageHandler.SetLanguageLine("ChangeItemAmount", "cambiar cantidad", "Spanish");

        // Spanish (Latin America)
        LanguageHandler.SetLanguageLine("NotEnoughPower", "No hay suficiente energía para tanta cantidad!", "Spanish (Latin America)");
        LanguageHandler.SetLanguageLine("ChangeItemAmount", "cambiar cantidad", "Spanish (Latin America)");
    }
}
