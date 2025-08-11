using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
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

        public override string Name => "SCPChat";
        public override string Author => "vipchuk + hnvrt";
        public override Version Version => new Version(2, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 8, 0);

        public override void OnEnabled()
        {
            Instance = this;
            IsChatEnabled = Config.IsEnabled;
            Log.Info(Config.Translation.PluginLoaded);
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            SpyingPlayers.Clear();
            _cooldowns.Clear();
            Instance = null;
            Log.Info(Config.Translation.PluginUnloaded);
            base.OnDisabled();
        }

        #region Methods

        public string SanitizeMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return message;

            string pattern = @"</?(?:b|i|size|color|material|quad|sprite|link|align|alpha|cspace|font|indent|line-height|line-indent|lowercase|uppercase|smallcaps|margin|mark|mspace|nobr|noparse|page|pos|space|style|sub|sup|u|voffset|width)(?:\s*=\s*[^>]*)?/?>";
            
            string sanitized = Regex.Replace(message, pattern, "", RegexOptions.IgnoreCase);
            
            sanitized = sanitized.Replace("<", "").Replace(">", "");
            
            return sanitized;
        }

        public void BroadcastMessage(Player sender, string message, bool isTest = false)
        {
            string processedMessage = Config.BlockFormatting ? SanitizeMessage(message) : message;
            
            string scpNumber = "CHAT";
            
            if (sender.Role.Team == Team.SCPs)
            {
                scpNumber = sender.Role.Type.ToString().Replace("Scp", "SCP-");
            }
            else
            {
                string customRoleName = sender.GetCustomRoleName();
                if (!string.IsNullOrEmpty(customRoleName))
                {
                    scpNumber = customRoleName;
                }
            }
            
            string format = isTest ? Config.TestMessageFormat : Config.MessageFormat;
            
            string formattedMessage = format
               .Replace("{scp_number}", scpNumber)
               .Replace("{player}", sender.Nickname)
               .Replace("{message}", processedMessage);

            foreach (Player recipient in Player.List)
            {
                bool canReceive = recipient.HasScpChatPermission();
                bool isSpying = SpyingPlayers.Contains(recipient.UserId);

                if (canReceive || isSpying)
                {
                    recipient.Broadcast(Config.MessageDuration, formattedMessage);
                }
            }
        }

        public bool IsOnCooldown(Player player) => _cooldowns.ContainsKey(player) && (DateTime.UtcNow - _cooldowns[player]).TotalSeconds < Config.CooldownSeconds;
        public void SetCooldown(Player player) => _cooldowns[player] = DateTime.UtcNow;
        public double GetRemainingCooldown(Player player) => _cooldowns.ContainsKey(player) ? Config.CooldownSeconds - (DateTime.UtcNow - _cooldowns[player]).TotalSeconds : 0;

        #endregion
    }
}
