using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ScpChat
{
    public class Config : IConfig
    {
        [Description("Enable or disable the plugin by default when the server starts.")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;

        [Description("Cooldown in seconds between sending messages by one player.")]
        public int CooldownSeconds { get; set; } = 5;

        [Description("Maximum number of characters in one message.")]
        public int CharacterLimit { get; set; } = 120;

        [Description("List of roles that can use and see this chat. Accepts RoleTypeId (e.g., Scp173).")]
        public List<string> AllowedRoles { get; set; } = new List<string> { "Scp049", "Scp079", "Scp096", "Scp106", "Scp173", "Scp939", "Scp0492", "Scp3114" };
        
        [Description("List of custom roles (CustomRoles) that can use and see this chat. Specify exact custom role names.")]
        public List<string> AllowedCustomRoles { get; set; } = new List<string>();
        
        [Description("Permission required to use admin commands (.sctoggle, .scpspy).")]
        public string AdminPermission { get; set; } = "scpchat.admin";

        [Description("Display message format. Available placeholders: {scp_number}, {player}, {message}.")]
        public string MessageFormat { get; set; } = "[<color=red>{scp_number}</color>] {player}: {message}";
        
        [Description("Test message format.")]
        public string TestMessageFormat { get; set; } = "[<color=yellow>DEBUG</color>] {player}: {message}";

        [Description("Message display duration on screen in seconds.")]
        public ushort MessageDuration { get; set; } = 5;
        
        [Description("Block Unity Rich Text formatting tags in player messages (recommended: true).")]
        public bool BlockFormatting { get; set; } = true;
        
        [Description("Plugin localization settings.")]
        public Translation Translation { get; set; } = new Translation();
    }
}
