using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace ScpChat.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ScpChatToggleCommand : ICommand
    {
        public string Command => "sctoggle";
        public string[] Aliases => new[] { "sct" };
        public string Description => "Включает или отключает SCP чат.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(Plugin.Instance.Config.AdminPermission))
            {
                response = "У вас нет прав для использования этой команды.";
                return false;
            }

            Plugin.Instance.IsChatEnabled = !Plugin.Instance.IsChatEnabled;
            
            response = $"SCP чат успешно {(Plugin.Instance.IsChatEnabled ? "включен" : "отключен")}.";
            return true;
        }
    }
}