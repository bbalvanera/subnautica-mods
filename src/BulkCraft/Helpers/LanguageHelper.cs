using Nautilus.Handlers;

namespace BulkCraft.Helpers;

internal static class LanguageHelper
{
    public static void Init()
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