using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ScpChat
{
    public class Config : IConfig
    {
        [Description("Включить или выключить плагин по умолчанию при старте сервера.")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;

        [Description("Задержка в секундах между отправкой сообщений одним игроком.")]
        public int CooldownSeconds { get; set; } = 5;

        [Description("Максимальное количество символов в одном сообщении.")]
        public int CharacterLimit { get; set; } = 120;

        [Description("Список ролей, которые могут использовать и видеть этот чат. Принимает RoleTypeId (например, Scp173).")]
        public List<string> AllowedRoles { get; set; } = new List<string> { "Scp049", "Scp079", "Scp096", "Scp106", "Scp173", "Scp939", "Scp0492", "Scp3114" };
        
        [Description("Список кастомных ролей (CustomRoles), которые могут использовать и видеть этот чат. Укажите точные названия кастомных ролей.")]
        public List<string> AllowedCustomRoles { get; set; } = new List<string> { "SCP-343" };
        
        [Description("Разрешение (permission), необходимое для использования админ-команд (.sctoggle, .scpspy).")]
        public string AdminPermission { get; set; } = "scpchat.admin";

        [Description("Формат отображаемого сообщения. {scp_number}, {player}, {message}.")]
        public string MessageFormat { get; set; } = "[<color=red>{scp_number}</color>] {player}: {message}";
        
        [Description("Формат тестового сообщения.")]
        public string TestMessageFormat { get; set; } = "[<color=yellow>DEBUG</color>] {player}: {message}";

        [Description("Продолжительность отображения сообщения на экране в секундах.")]
        public ushort MessageDuration { get; set; } = 5;
        
        [Description("Блокировать теги форматирования Unity Rich Text в сообщениях игроков.")]
        public bool BlockFormatting { get; set; } = true;
        
        [Description("Настройки локализации плагина.")]
        public Translation Translation { get; set; } = new Translation();
    }
}