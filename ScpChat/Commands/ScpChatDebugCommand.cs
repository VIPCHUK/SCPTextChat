using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using CommandSystem;
using Exiled.Permissions.Extensions;
using ScpChat.Extensions;

namespace ScpChat.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ScpChatDebugCommand : ICommand
    {
        public string Command => "scpdebug";
        public string[] Aliases => new[] { "scd" };
        public string Description => Plugin.Instance?.Config?.Translation?.ScpChatDebugCommandDescription ?? "Отладочная команда для проверки кастомных ролей SCP чата.";

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

            if (arguments.Count > 0 && arguments.At(0).ToLower() == "all")
            {
                response = Plugin.Instance.Config.Translation.DebugHeaderAll + "\n";
                
                foreach (var p in Player.List)
                {
                    response += $"\n[{p.Nickname}] {string.Format(Plugin.Instance.Config.Translation.DebugCurrentRole, p.Role.Type)}";
                    response += $" | {string.Format(Plugin.Instance.Config.Translation.DebugIsScp, p.Role.Team == PlayerRoles.Team.SCPs ? Plugin.Instance.Config.Translation.Yes : Plugin.Instance.Config.Translation.No)}";
                    response += $" | {string.Format(Plugin.Instance.Config.Translation.DebugChatAccess, p.HasScpChatPermission() ? Plugin.Instance.Config.Translation.Yes : Plugin.Instance.Config.Translation.No)}";
                    
                    string customRole = p.GetCustomRoleName();
                    if (!string.IsNullOrEmpty(customRole))
                    {
                        response += $" | {string.Format(Plugin.Instance.Config.Translation.DebugActiveCustomRole, customRole)}";
                    }
                }
                
                response += $"\n\n{Plugin.Instance.Config.Translation.DebugConfigHeader}";
                response += $"\n{string.Format(Plugin.Instance.Config.Translation.DebugAllowedRoles, string.Join(", ", Plugin.Instance.Config.AllowedRoles))}";
                response += $"\n{string.Format(Plugin.Instance.Config.Translation.DebugAllowedCustomRoles, string.Join(", ", Plugin.Instance.Config.AllowedCustomRoles))}";
                response += $"\n{string.Format(Plugin.Instance.Config.Translation.DebugRegisteredCustomRoles, string.Join(", ", CustomRole.Registered.Select(cr => cr.Name)))}";
                
                return true;
            }

            response = string.Format(Plugin.Instance.Config.Translation.DebugHeaderSingle, player.Nickname) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugCurrentRole, player.Role.Type) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugTeam, player.Role.Team) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugIsScp, player.Role.Team == PlayerRoles.Team.SCPs ? Plugin.Instance.Config.Translation.Yes : Plugin.Instance.Config.Translation.No) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugChatAccess, player.HasScpChatPermission() ? Plugin.Instance.Config.Translation.Yes : Plugin.Instance.Config.Translation.No) + "\n";
            
            string customRoleName = player.GetCustomRoleName();
            if (!string.IsNullOrEmpty(customRoleName))
            {
                response += string.Format(Plugin.Instance.Config.Translation.DebugActiveCustomRole, customRoleName) + "\n";
                response += string.Format(Plugin.Instance.Config.Translation.DebugCustomRoleAllowed, Plugin.Instance.Config.AllowedCustomRoles.Contains(customRoleName) ? Plugin.Instance.Config.Translation.Yes : Plugin.Instance.Config.Translation.No) + "\n";
            }
            else
            {
                response += Plugin.Instance.Config.Translation.DebugNoCustomRole + "\n";
            }
            
            response += $"\n{Plugin.Instance.Config.Translation.DetailedCustomRoleDiagnostic}\n";
            
            var foundRoles = new List<string>();
            foreach (var customRole in CustomRole.Registered)
            {
                if (customRole.Check(player))
                {
                    foundRoles.Add(customRole.Name);
                }
            }
            
            if (foundRoles.Any())
            {
                response += string.Format(Plugin.Instance.Config.Translation.FoundRolesViaCheck, string.Join(", ", foundRoles)) + "\n";
            }
            else
            {
                response += Plugin.Instance.Config.Translation.NoRolesFoundViaCheck + "\n";
            }
            
            if (CustomRole.TryGet(player, out IReadOnlyCollection<CustomRole> playerRoles))
            {
                var roleNames = playerRoles.Select(r => r.Name).ToArray();
                response += string.Format(Plugin.Instance.Config.Translation.FoundRolesViaTryGet, string.Join(", ", roleNames)) + "\n";
            }
            else
            {
                response += Plugin.Instance.Config.Translation.NoRolesFoundViaTryGet + "\n";
            }
            
            response += $"\n{Plugin.Instance.Config.Translation.DebugConfigHeader}\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugAllowedRoles, string.Join(", ", Plugin.Instance.Config.AllowedRoles)) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugAllowedCustomRoles, string.Join(", ", Plugin.Instance.Config.AllowedCustomRoles)) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugTotalRegisteredRoles, CustomRole.Registered.Count()) + "\n";
            response += string.Format(Plugin.Instance.Config.Translation.DebugRegisteredRoleNames, string.Join(", ", CustomRole.Registered.Select(cr => cr.Name))) + "\n";
            
            response += "\n" + Plugin.Instance.Config.Translation.DebugAllHint;
            
            return true;
        }
    }
}
