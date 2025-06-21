using System;
using Exiled.API.Features;
using CommandSystem;
using ScpChat.Extensions;
using Exiled.Permissions.Extensions;

namespace ScpChat.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ScpChatTestCommand : ICommand
    {
        public string Command => "sctest";
        public string[] Aliases => new string[0];
        public string Description => "Тестирует видимость сообщений в SCP чате.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "Эту команду могут использовать только игроки.";
                return false;
            }
            
            if (!player.CheckPermission(Plugin.Instance.Config.AdminPermission))
            {
                response = "У вас нет доступа к этому чату.";
                return false;
            }

            Plugin.Instance.BroadcastMessage(player, "Это тестовое сообщение.", true);
            
            response = "Тестовое сообщение отправлено.";
            return true;
        }
    }
}