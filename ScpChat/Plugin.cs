using System;
using System.Collections.Generic;
using Exiled.API.Features;
using ScpChat.Extensions;
using PlayerRoles;

namespace ScpChat
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }

        public bool IsChatEnabled { get; set; }
        
        public HashSet<string> SpyingPlayers { get; } = new HashSet<string>();

        private readonly Dictionary<Player, DateTime> _cooldowns = new Dictionary<Player, DateTime>();

        public override string Name => "ScpChat";
        public override string Author => "honvert";
        public override Version Version => new Version(2, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 8, 0);

        public override void OnEnabled()
        {
            Instance = this;
            IsChatEnabled = Config.IsEnabled;
            Log.Info("Плагин ScpChat успешно загружен.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            SpyingPlayers.Clear();
            _cooldowns.Clear();
            Instance = null;
            Log.Info("Плагин ScpChat выгружен.");
            base.OnDisabled();
        }

        #region Helper Methods

        public void BroadcastMessage(Player sender, string message, bool isTest = false)
        {
            string scpNumber = "CHAT";
            if (sender.Role.Team == Team.SCPs)
            {
                scpNumber = sender.Role.Type.ToString().Replace("Scp", "SCP-");
            }
            
            string format = isTest ? Config.TestMessageFormat : Config.MessageFormat;
            
            string formattedMessage = format
               .Replace("{scp_number}", scpNumber)
               .Replace("{player}", sender.Nickname)
               .Replace("{message}", message);

            foreach (Player recipient in Player.List)
            {
                bool canReceive = recipient.HasScpChatPermission();
                bool isSpying = SpyingPlayers.Contains(recipient.UserId);
                bool isTestSender = isTest && recipient == sender;

                if (canReceive || isSpying)
                {
                    recipient.Broadcast(Config.MessageDuration, formattedMessage);
                }
            }
        }

        public bool IsOnCooldown(Player player) => _cooldowns.ContainsKey(player) && (DateTime.UtcNow - _cooldowns[player]).TotalSeconds < Config.CooldownSeconds;
        public void SetCooldown(Player player) => _cooldowns[player] = DateTime.UtcNow;

        #endregion
    }
}