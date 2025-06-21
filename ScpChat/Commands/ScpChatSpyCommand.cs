using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace ScpChat.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ScpChatSpyCommand : ICommand
    {
        public string Command => "scpspy";
        public string[] Aliases => new string[0];
        public string Description => "Включает/выключает просмотр SCP чата.";

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
                response = "У вас нет прав для использования этой команды.";
                return false;
            }

            if (Plugin.Instance.SpyingPlayers.Contains(player.UserId))
            {
                Plugin.Instance.SpyingPlayers.Remove(player.UserId);
                response = "Режим просмотра SCP чата отключен.";
            }
            else
            {
                Plugin.Instance.SpyingPlayers.Add(player.UserId);
                response = "Режим просмотра SCP чата включен.";
            }

            return true;
        }
    }
}