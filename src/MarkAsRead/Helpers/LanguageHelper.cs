using Nautilus.Handlers;

namespace MarkAsRead.Helpers;

public static class LanguageHelper
{
    public static void Init()
    {
        LanguageHandler.SetLanguageLine("MarkAsRead", "mark as read", "English");
        LanguageHandler.SetLanguageLine("MarkAsRead", "marcar como leído", "Spanish (Latin America)");
        LanguageHandler.SetLanguageLine("MarkAsRead", "marcar como leído", "Spanish");
    }
}