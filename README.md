# ScpChat - SCP Communication Plugin for EXILED

## Installation
1. **Prerequisites**: Ensure you have EXILED 9.6.0+ installed on your SCP:SL server
2. **Download**: Get the latest release from the releases page
3. **Install**: Place `ScpChat.dll` in your `EXILED/Plugins` folder
4. **Configure**: Edit the generated config file to your preferences
5. **Restart**: Restart your server to load the plugin
6. 
<img width="1277" height="162" alt="image" src="https://github.com/user-attachments/assets/331983aa-b451-4c1f-a4b9-986869cc15c3" />

## ⚙️ Configuration

```yaml
# ScpChat Configuration
scp_chat:
  is_enabled: true
  debug: false
  cooldown_seconds: 5
  character_limit: 120
  message_duration: 5
  block_formatting: true
  
  # Standard SCP roles that can use the chat
  allowed_roles:
    - Scp049
    - Scp079
    - Scp096
    - Scp106
    - Scp173
    - Scp939
    - Scp0492
    - Scp3114
  
  # Custom roles that can use the chat (Examples)
  allowed_custom_roles:
    - SCP-343
    - SCP-999
  
  # Message formatting
  message_format: "[<color=red>{scp_number}</color>] {player}: {message}"
  test_message_format: "[<color=yellow>DEBUG</color>] {player}: {message}"
  
  # Admin permission for management commands
  admin_permission: "scpchat.admin"
```


## Commands

### **Player Commands**
- `.scpchat <message>` / `.sc <message>` - Send a message to SCP chat

### **Admin Commands** (Remote Admin)
- `sctoggle` / `sct` - Toggle SCP chat on/off
- `scpspy` - Enable/disable SCP chat monitoring
- `sctest` - Send a test message to SCP chat
- `scpdebug` / `scd` - Display detailed debugging information
- `scstatus` / `scs` - Show plugin status and statistics
  
## Compatibility
- **EXILED**: 9.6.0+
- **SCP:SL**: Compatible with latest versions
- **CustomRoles**: Full integration support
- **.NET Framework**: 4.8

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Troubleshooting

### Custom Roles Not Working?
1. Use `scpdebug` command to check role detection
2. Verify custom role names match exactly in config
3. Ensure CustomRoles plugin loads before ScpChat
4. Check server logs for detailed error messages

### Chat Not Appearing?
1. Verify player has correct role/permissions
2. Check if chat is enabled with `scstatus`
3. Ensure message format is valid
4. Test with `sctest` command
