namespace ScpChat.Commands
{
    using System;
    using Exiled.API.Features;
    using CommandSystem;
    using ScpChat.Extensions;

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

            if (!Plugin.Instance.Config.IsEnabled)
            {
                response = "Чат SCP в данный момент отключен.";
                return true;
            }
            
            if (!player.HasScpChatPermission())
            {
                response = "У вас нет доступа к этому чату.";
                return true;
            }

            if (arguments.Count == 0)
            {
                response = "Ошибка: сообщение не может быть пустым. Использование: .scpchat <сообщение>";
                return true;
            }

            string message = string.Join(" ", arguments);

            if (message.Length > Plugin.Instance.Config.CharacterLimit)
            {
                response = $"Ошибка: сообщение слишком длинное. Максимальная длина: {Plugin.Instance.Config.CharacterLimit} символов.";
                return true;
            }

            if (Plugin.Instance.IsOnCooldown(player))
            {
                response = $"Ошибка: подождите, прежде чем отправлять следующее сообщение. КД: {Plugin.Instance.Config.CooldownSeconds} сек.";
                return true;
            }

            Plugin.Instance.BroadcastMessage(player, message);
            Plugin.Instance.SetCooldown(player);

            response = "Сообщение отправлено в чат SCP.";
            return true;
        }
    }
}
