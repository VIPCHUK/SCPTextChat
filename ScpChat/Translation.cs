using System.ComponentModel;

namespace ScpChat
{
    public class Translation
    {
        [Description("Message when plugin is disabled")]
        public string PluginDisabled { get; set; } = "ScpChat plugin is currently disabled by administration.";

        [Description("Message when user has no access to chat")]
        public string NoAccess { get; set; } = "You don't have access to this chat.";

        [Description("Message about empty message")]
        public string EmptyMessage { get; set; } = "[Error]: message cannot be empty.";

        [Description("Message about character limit exceeded")]
        public string MessageTooLong { get; set; } = "[Error]: message too long (max: {0}).";

        [Description("Message about cooldown")]
        public string OnCooldown { get; set; } = "Wait {0} seconds before sending the next message.";

        [Description("Message about successful sending")]
        public string MessageSent { get; set; } = "Message sent to SCP chat.";

        [Description("Message about successful test message sending")]
        public string TestMessageSent { get; set; } = "Test message sent.";

        [Description("Message that command can only be used by players")]
        public string PlayersOnly { get; set; } = "This command can only be used by players.";

        [Description("Message about missing permissions")]
        public string NoPermission { get; set; } = "You don't have permission to use this command.";

        [Description("Message about chat enabled")]
        public string ChatEnabled { get; set; } = "SCP chat enabled.";

        [Description("Message about chat disabled")]
        public string ChatDisabled { get; set; } = "SCP chat disabled.";

        [Description("Message about spy mode enabled")]
        public string SpyModeEnabled { get; set; } = "SCP chat monitoring mode enabled.";

        [Description("Message about spy mode disabled")]
        public string SpyModeDisabled { get; set; } = "SCP chat monitoring mode disabled.";

        [Description("Debug header for single player")]
        public string DebugHeaderSingle { get; set; } = "=== ScpChat Debug {0} ===";

        [Description("Debug header for all players")]
        public string DebugHeaderAll { get; set; } = "=== Overall ScpChat Debug ===";

        [Description("Configuration header in debug")]
        public string DebugConfigHeader { get; set; } = "=== Plugin config ===";

        [Description("Current role in debug")]
        public string DebugCurrentRole { get; set; } = "Current role: {0}";

        [Description("Team in debug")]
        public string DebugTeam { get; set; } = "Team: {0}";

        [Description("Is SCP in debug")]
        public string DebugIsScp { get; set; } = "Is SCP: {0}";

        [Description("Chat access in debug")]
        public string DebugChatAccess { get; set; } = "SCP chat access: {0}";

        [Description("Active custom role in debug")]
        public string DebugActiveCustomRole { get; set; } = "Active custom role: {0}";

        [Description("Custom role allowed in debug")]
        public string DebugCustomRoleAllowed { get; set; } = "Custom role allowed: {0}";

        [Description("No custom role in debug")]
        public string DebugNoCustomRole { get; set; } = "Custom role: none";

        [Description("Allowed roles in debug")]
        public string DebugAllowedRoles { get; set; } = "Allowed roles: {0}";

        [Description("Allowed custom roles in debug")]
        public string DebugAllowedCustomRoles { get; set; } = "Allowed custom roles: {0}";

        [Description("Registered custom roles in debug")]
        public string DebugRegisteredCustomRoles { get; set; } = "Registered custom roles: {0}";

        [Description("Total registered roles count in debug")]
        public string DebugTotalRegisteredRoles { get; set; } = "Total registered custom roles: {0}";

        [Description("Registered role names in debug")]
        public string DebugRegisteredRoleNames { get; set; } = "Registered role names: {0}";

        [Description("Debug command hint")]
        public string DebugAllHint { get; set; } = "Use 'scpdebug all' to check all players.";

        [Description("Plugin loaded message")]
        public string PluginLoaded { get; set; } = "ScpChat plugin loaded.";

        [Description("Plugin unloaded message")]
        public string PluginUnloaded { get; set; } = "ScpChat plugin unloaded.";

        [Description("Custom role check error message")]
        public string CustomRoleCheckError { get; set; } = "Error checking custom roles for {0}: {1}";

        [Description("Custom role name error message")]
        public string CustomRoleNameError { get; set; } = "Error getting custom role name for {0}: {1}";

        [Description("Yes")]
        public string Yes { get; set; } = "Yes";

        [Description("No")]
        public string No { get; set; } = "No";

        [Description("None")]
        public string None { get; set; } = "None";
        
        [Description("SCP chat command description")]
        public string ScpChatCommandDescription { get; set; } = "Sends a message to SCP chat.";
        
        [Description("SCP chat test command description")]
        public string ScpChatTestCommandDescription { get; set; } = "[DEBUG] Tests SCP chat message visibility.";
        
        [Description("SCP chat toggle command description")]
        public string ScpChatToggleCommandDescription { get; set; } = "Enables or disables SCP chat.";
        
        [Description("SCP chat spy command description")]
        public string ScpChatSpyCommandDescription { get; set; } = "Enables/disables SCP chat monitoring.";
        
        [Description("SCP chat debug command description")]
        public string ScpChatDebugCommandDescription { get; set; } = "Debug command for checking custom roles in SCP chat.";
        
        [Description("Message about formatting being removed")]
        public string FormattingRemoved { get; set; } = "Warning: formatting tags were removed from your message.";
        
        [Description("Message when no custom roles found")]
        public string NoCustomRolesFound { get; set; } = "No custom roles found";
        
        [Description("Detailed custom role diagnostic header")]
        public string DetailedCustomRoleDiagnostic { get; set; } = "=== Debug ===";
        
        [Description("Found custom roles via Check method")]
        public string FoundRolesViaCheck { get; set; } = "Found custom roles via Check(): {0}";
        
        [Description("Found custom roles via TryGet method")]
        public string FoundRolesViaTryGet { get; set; } = "Custom roles via TryGet(): {0}";
        
        [Description("Message when no custom roles found via Check")]
        public string NoRolesFoundViaCheck { get; set; } = "Custom roles via Check(): not found";
        
        [Description("Message when no custom roles found via TryGet")]
        public string NoRolesFoundViaTryGet { get; set; } = "Custom roles via TryGet(): not found";
        
        [Description("Formatting blocked status in debug")]
        public string DebugFormattingBlocked { get; set; } = "Formatting blocked: {0}";
        
        [Description("Test message text")]
        public string TestMessage { get; set; } = "This is a test message.";
        
        [Description("Chat toggle success message")]
        public string ChatToggleSuccess { get; set; } = "SCP chat {0}.";
        
        [Description("Enabled")]
        public string Enabled { get; set; } = "enabled";
        
        [Description("Disabled")]
        public string Disabled { get; set; } = "disabled";
        
        [Description("Debug message prefix in log")]
        public string DebugPrefix { get; set; } = "[ScpChat]";
        
        [Description("Message about player having custom role")]
        public string PlayerHasCustomRole { get; set; } = "Player {0} has custom role: {1}";
        
        [Description("Message about number of found custom roles")]
        public string PlayerHasCustomRolesCount { get; set; } = "Player {0} has {1} custom roles via TryGet";
        
        [Description("Plugin status header")]
        public string PluginStatusHeader { get; set; } = "=== Plugin Status ===";
        
        [Description("Chat status in debug")]
        public string DebugChatStatus { get; set; } = "Chat status: {0}";
        
        [Description("Number of active spies")]
        public string DebugActiveSpies { get; set; } = "Active spies: {0}";
        
        [Description("Plugin version in debug")]
        public string DebugPluginVersion { get; set; } = "Plugin version: {0}";
        
        [Description("Number of players on server")]
        public string DebugPlayerCount { get; set; } = "Players on server: {0}";
        
        [Description("Command execution error message")]
        public string CommandExecutionError { get; set; } = "Command execution error: {0}";
                
        [Description("Command unavailable message")]
        public string CommandUnavailable { get; set; } = "Command temporarily unavailable.";
        
        [Description("Configuration reloaded message")]
        public string ConfigReloaded { get; set; } = "Plugin configuration reloaded.";
        
        [Description("Configuration reload error message")]
        public string ConfigReloadError { get; set; } = "Configuration reload error: {0}";
        
        [Description("Feature in development message")]
        public string FeatureInDevelopment { get; set; } = "This feature is in development.";
        
        [Description("Invalid command syntax message")]
        public string InvalidCommandSyntax { get; set; } = "Invalid command syntax. Use: {0}";
        }
}
