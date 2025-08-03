using System;
using System.Linq;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using CommandSystem;
using Exiled.Permissions.Extensions;

namespace ScpChat.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ScpChatStatusCommand : ICommand
    {
        public string Command => "scstatus";
        public string[] Aliases => new[] { "scs" };
        public string Description => "Показывает статус плагина ScpChat.";

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

            response = Plugin.Instance.Config.Translation.PluginStatusHeader + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugPluginVersion, Plugin.Instance.Version) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugChatStatus, 
                Plugin.Instance.IsChatEnabled ? Plugin.Instance.Config.Translation.Enabled : Plugin.Instance.Config.Translation.Disabled) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugActiveSpies, Plugin.Instance.SpyingPlayers.Count) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugPlayerCount, Player.List.Count()) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugFormattingBlocked, 
                Plugin.Instance.Config.BlockFormatting ? Plugin.Instance.Config.Translation.Yes : Plugin.Instance.Config.Translation.No) + "\n";
            
            response += $"\n{Plugin.Instance.Config.Translation.DebugConfigHeader}\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugAllowedRoles, string.Join(", ", Plugin.Instance.Config.AllowedRoles)) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugAllowedCustomRoles, 
                Plugin.Instance.Config.AllowedCustomRoles.Any() ? string.Join(", ", Plugin.Instance.Config.AllowedCustomRoles) : Plugin.Instance.Config.Translation.None) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugTotalRegisteredRoles, CustomRole.Registered.Count()) + "\n";

            return true;
        }
    }
}
