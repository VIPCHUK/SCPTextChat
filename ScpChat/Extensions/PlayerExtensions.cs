namespace ScpChat.Extensions
{
    using Exiled.API.Features;
    using PlayerRoles;

    public static class PlayerExtensions
    {
        public static bool HasScpChatPermission(this Player player)
        {
            string currentRole = player.RoleManager.CurrentRole.RoleTypeId.ToString();
            string currentGroup = player.GroupName;

            bool hasRole = Plugin.Instance.Config.AllowedRoles.Contains(currentRole);
            bool hasGroup = !string.IsNullOrEmpty(currentGroup) && Plugin.Instance.Config.AllowedRoles.Contains(currentGroup);
            
            return hasRole || hasGroup;
        }
    }
}