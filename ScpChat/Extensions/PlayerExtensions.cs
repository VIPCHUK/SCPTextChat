using Exiled.API.Features;
using PlayerRoles;

namespace ScpChat.Extensions
{
    public static class PlayerExtensions
    {
        public static bool HasScpChatPermission(this Player player)
        {
            if (player == null) return false;
            return Plugin.Instance.Config.AllowedRoles.Contains(player.Role.Type.ToString());
        }
    }
}