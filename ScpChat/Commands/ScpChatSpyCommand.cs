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
        public string Description => Plugin.Instance?.Config?.Translation?.ScpChatSpyCommandDescription ?? "Включает/выключает просмотр SCP чата.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = Plugin.Instance.Config.Translation.PlayersOnly;
                return false;
            }
            
            if (!player.CheckPermission(Plugin.Instance.Config.AdminPermission))
            {
                response = Plugin.Instance.Config.Translation.NoPermission;
                return false;
            }

            if (Plugin.Instance.SpyingPlayers.Contains(player.UserId))
            {
                Plugin.Instance.SpyingPlayers.Remove(player.UserId);
                response = Plugin.Instance.Config.Translation.SpyModeDisabled;
            }
            else
            {
                Plugin.Instance.SpyingPlayers.Add(player.UserId);
                response = Plugin.Instance.Config.Translation.SpyModeEnabled;
            }

            return true;
        }
    }
}