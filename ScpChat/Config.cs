namespace ScpChat
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    public class Config : IConfig
    {
        [Description("Включить или выключить плагин.")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("Debug")]
        public bool Debug { get; set; } = true;

        [Description("Задержка в секундах между отправкой сообщений одним игроком.")]
        public int CooldownSeconds { get; set; } = 5;

        [Description("Максимальное количество символов в одном сообщении.")]
        public int CharacterLimit { get; set; } = 120;

        [Description("Список ролей, которые могут использовать и видеть этот чат. Принимает RoleTypeId (например, Scp173) и названия групп из remote admin (например, owner).")]
        public List<string> AllowedRoles { get; set; } = new List<string>
        {
            "Scp049",
            "Scp079",
            "Scp096",
            "Scp106",
            "Scp173",
            "Scp939"
        };
        
        [Description("Формат отображаемого сообщения. {scp_number} - номер SCP, {player} - имя отправителя, {message} - текст сообщения.")]
        public string MessageFormat { get; set; } = "[<color=red>{scp_number}</color>] {player}: {message}";
        
        [Description("Продолжительность отображения сообщения на экране в секундах.")]
        public ushort MessageDuration { get; set; } = 5;
    }
}