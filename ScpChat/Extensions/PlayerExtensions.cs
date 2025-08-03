using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;

namespace ScpChat.Extensions
{
    public static class PlayerExtensions
    {
        public static bool HasScpChatPermission(this Player player)
        {
            if (player == null) return false;
            
            if (Plugin.Instance.Config.AllowedRoles.Contains(player.Role.Type.ToString()))
                return true;
            
            try 
            {
                foreach (var customRole in CustomRole.Registered)
                {
                    if (customRole.Check(player))
                    {
                        if (Plugin.Instance.Config.Debug)
                        {
                            Exiled.API.Features.Log.Debug(string.Format($"{Plugin.Instance.Config.Translation.DebugPrefix} {Plugin.Instance.Config.Translation.PlayerHasCustomRole}", player.Nickname, customRole.Name));
                        }
                        
                        if (Plugin.Instance.Config.AllowedCustomRoles.Contains(customRole.Name))
                        {
                            return true;
                        }
                    }
                }
                
                if (CustomRole.TryGet(player, out IReadOnlyCollection<CustomRole> playerRoles))
                {
                    if (Plugin.Instance.Config.Debug)
                    {
                        Log.Debug(string.Format($"{Plugin.Instance.Config.Translation.DebugPrefix} {Plugin.Instance.Config.Translation.PlayerHasCustomRolesCount}", player.Nickname, playerRoles.Count));
                    }
                    
                    foreach (var role in playerRoles)
                    {
                        if (Plugin.Instance.Config.AllowedCustomRoles.Contains(role.Name))
                        {
                            return true;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (Plugin.Instance.Config.Debug)
                {
                    Exiled.API.Features.Log.Debug(string.Format(Plugin.Instance.Config.Translation.CustomRoleCheckError, player.Nickname, ex.Message));
                }
            }
            
            return false;
        }
        
        public static string GetCustomRoleName(this Player player)
        {
            if (player == null) return null;
            
            try
            {
                foreach (var customRole in CustomRole.Registered)
                {
                    if (customRole.Check(player))
                    {
                        return customRole.Name;
                    }
                }
                
                if (CustomRole.TryGet(player, out IReadOnlyCollection<CustomRole> playerRoles))
                {
                    var firstRole = playerRoles.FirstOrDefault();
                    if (firstRole != null)
                    {
                        return firstRole.Name;
                    }
                }
            }
            catch (System.Exception ex)
            {
                if (Plugin.Instance.Config.Debug)
                {
                    Log.Debug(string.Format(Plugin.Instance.Config.Translation.CustomRoleNameError, player.Nickname, ex.Message));
                }
            }
            
            return null;
        }
    }
}