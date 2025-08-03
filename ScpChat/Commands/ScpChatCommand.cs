using System;
using Exiled.API.Features;
using CommandSystem;
using ScpChat.Extensions;
using Exiled.Permissions.Extensions;

namespace ScpChat.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ScpChatCommand : ICommand
    {
        public string Command => "scpchat";
        public string[] Aliases => new[] { "sc" };
        public string Description => Plugin.Instance?.Config?.Translation?.ScpChatCommandDescription ?? "Отправляет сообщение в чат SCP.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = Plugin.Instance.Config.Translation.PlayersOnly;
                return false;
            }

            if (!Plugin.Instance.IsChatEnabled)
            {
                response = Plugin.Instance.Config.Translation.PluginDisabled;
                return false;
            }
            
            if (!player.HasScpChatPermission())
            {
                response = Plugin.Instance.Config.Translation.NoAccess;
                return false;
            }

            if (arguments.Count == 0)
            {
                response = Plugin.Instance.Config.Translation.EmptyMessage;
                return false;
            }

            string message = string.Join(" ", arguments);

            if (message.Length > Plugin.Instance.Config.CharacterLimit)
            {
                response = string.Format(Plugin.Instance.Config.Translation.MessageTooLong, Plugin.Instance.Config.CharacterLimit);
                return false;
            }

            if (Plugin.Instance.IsOnCooldown(player))
            {
                var remainingTime = Plugin.Instance.GetRemainingCooldown(player);
                response = string.Format(Plugin.Instance.Config.Translation.OnCooldown, Math.Ceiling(remainingTime));
                return false;
            }

            bool hadFormatting = Plugin.Instance.Config.BlockFormatting && 
                                Plugin.Instance.SanitizeMessage(message) != message;

            Plugin.Instance.BroadcastMessage(player, message);
            Plugin.Instance.SetCooldown(player);

            if (hadFormatting)
            {
                response = Plugin.Instance.Config.Translation.MessageSent + " " + Plugin.Instance.Config.Translation.FormattingRemoved;
            }
            else
            {
                response = Plugin.Instance.Config.Translation.MessageSent;
            }
            
            return true;
        }
    }
}
