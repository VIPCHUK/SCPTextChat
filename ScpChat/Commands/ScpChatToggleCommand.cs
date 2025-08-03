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
        public string Description => Plugin.Instance?.Config?.Translation?.ScpChatToggleCommandDescription ?? "Включает или отключает SCP чат.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(Plugin.Instance.Config.AdminPermission))
            {
                response = Plugin.Instance.Config.Translation.NoPermission;
                return false;
            }

            Plugin.Instance.IsChatEnabled = !Plugin.Instance.IsChatEnabled;
            
            string status = Plugin.Instance.IsChatEnabled ? 
                Plugin.Instance.Config.Translation.Enabled : 
                Plugin.Instance.Config.Translation.Disabled;
            
            response = string.Format(Plugin.Instance.Config.Translation.ChatToggleSuccess, status);
            return true;
        }
    }
}