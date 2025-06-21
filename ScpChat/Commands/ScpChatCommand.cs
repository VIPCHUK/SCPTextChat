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
        public string Description => "Отправляет сообщение в чат SCP.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (player == null)
            {
                response = "Эту команду могут использовать только игроки.";
                return false;
            }

            if (!Plugin.Instance.IsChatEnabled)
            {
                response = "Чат SCP в данный момент отключен администратором.";
                return false;
            }
            
            if (!player.HasScpChatPermission())
            {
                response = "У вас нет доступа к этому чату.";
                return false;
            }

            if (arguments.Count == 0)
            {
                response = "Ошибка: сообщение не может быть пустым.";
                return false;
            }

            string message = string.Join(" ", arguments);

            if (message.Length > Plugin.Instance.Config.CharacterLimit)
            {
                response = $"Ошибка: сообщение слишком длинное (макс: {Plugin.Instance.Config.CharacterLimit}).";
                return false;
            }

            if (Plugin.Instance.IsOnCooldown(player))
            {
                response = "Ошибка: подождите перед отправкой следующего сообщения.";
                return false;
            }

            Plugin.Instance.BroadcastMessage(player, message);
            Plugin.Instance.SetCooldown(player);

            response = "Сообщение отправлено в чат SCP.";
            return true;
        }
    }
}
