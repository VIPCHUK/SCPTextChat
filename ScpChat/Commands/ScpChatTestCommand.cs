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
        public string Description => Plugin.Instance?.Config?.Translation?.ScpChatTestCommandDescription ?? "[DEBUG] Тестирует видимость сообщений в SCP чате.";

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
            Plugin.Instance.BroadcastMessage(player, Plugin.Instance.Config.Translation.TestMessage, true);
            Plugin.Instance.BroadcastMessage(player, Plugin.Instance.Config.Translation.TestMessage, true);
            response = Plugin.Instance.Config.Translation.TestMessageSent;
            return true;
        }
    }
}