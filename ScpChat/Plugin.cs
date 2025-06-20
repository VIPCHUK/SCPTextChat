namespace ScpChat
{
    using System;
    using System.Collections.Generic;
    using Exiled.API.Features;
    using ScpChat.Extensions;
    using PlayerRoles;

    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }

        private readonly Dictionary<Player, DateTime> cooldowns = new Dictionary<Player, DateTime>();

        public override string Name => "ScpChat";
        public override string Author => "honvert";
        public override Version Version => new Version(1, 3, 0); // Версия обновлена
        public override Version RequiredExiledVersion => new Version(8, 8, 0);

        public override void OnEnabled()
        {
            Instance = this;
            Log.Info("Плагин ScpChat успешно загружен.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            Log.Info("Плагин ScpChat выгружен.");
            base.OnDisabled();
        }

        #region Helper Methods

        public void BroadcastMessage(Player sender, string message)
        {
            string scpNumber = "CHAT";
            if (sender.Role.Team == Team.SCPs)
            {
                scpNumber = sender.Role.Type.ToString().Replace("Scp", "SCP-");
            }

            string formattedMessage = Config.MessageFormat
               .Replace("{scp_number}", scpNumber)
               .Replace("{player}", sender.Nickname)
               .Replace("{message}", message);

            foreach (Player recipient in Player.List)
            {
                if (recipient.HasScpChatPermission())
                {
                    recipient.Broadcast(Config.MessageDuration, formattedMessage);
                }
            }
        }

        public bool IsOnCooldown(Player player)
        {
            return cooldowns.ContainsKey(player) && (DateTime.UtcNow - cooldowns[player]).TotalSeconds < Config.CooldownSeconds;
        }

        public void SetCooldown(Player player)
        {
            cooldowns[player] = DateTime.UtcNow;
        }

        #endregion
    }
}
