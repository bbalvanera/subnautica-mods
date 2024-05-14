using Nautilus.Handlers;

namespace MarkAsRead.Helpers;

public static class LanguageHelper
{
    public static void Init()
    {
        LanguageHandler.SetLanguageLine("ClearNotifications", "mark as read", "English");
        LanguageHandler.SetLanguageLine("ClearNotifications", "marcar como leído", "Spanish (Latin America)");
        LanguageHandler.SetLanguageLine("ClearNotifications", "marcar como leído", "Spanish");
    }
}