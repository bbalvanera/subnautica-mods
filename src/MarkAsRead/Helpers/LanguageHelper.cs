using Nautilus.Handlers;

namespace MarkAsRead.Helpers;

public static class LanguageHelper
{
    public static void Init()
    {
        LanguageHandler.SetLanguageLine("MarkAsRead", "Mark as read", "English");
        LanguageHandler.SetLanguageLine("MarkAsRead", "Marcar como leído", "Spanish (Latin America)");
        LanguageHandler.SetLanguageLine("MarkAsRead", "Marcar como leído", "Spanish");
    }
}