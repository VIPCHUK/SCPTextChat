using System.ComponentModel;

namespace ScpChat
{
    public class Translation
    {
        [Description("Сообщение при отключенном плагине")]
        public string PluginDisabled { get; set; } = "Плагин ScpChat в данный момент отключен администратцией.";

        [Description("Сообщение при отсутствии доступа к чату")]
        public string NoAccess { get; set; } = "У вас нет доступа к этому чату.";

        [Description("Сообщение о пустом сообщении")]
        public string EmptyMessage { get; set; } = "[Ошибка]: сообщение не может быть пустым.";

        [Description("Сообщение о превышении лимита символов")]
        public string MessageTooLong { get; set; } = "[Ошибка]: сообщение слишком длинное (макс: {0}).";

        [Description("Сообщение о кулдауне")]
        public string OnCooldown { get; set; } = "Подождите {0} секунд перед отправкой следующего сообщения.";

        [Description("Сообщение об успешной отправке")]
        public string MessageSent { get; set; } = "Сообщение отправлено в SCP чат.";

        [Description("Сообщение об успешной отправке тестового сообщения")]
        public string TestMessageSent { get; set; } = "Тестовое сообщение отправлено.";

        [Description("Сообщение о том, что команду могут использовать только игроки")]
        public string PlayersOnly { get; set; } = "Эту команду могут использовать только игроки.";

        [Description("Сообщение об отсутствии разрешений")]
        public string NoPermission { get; set; } = "У вас нет разрешения на использование этой команды.";

        [Description("Сообщение о включении чата")]
        public string ChatEnabled { get; set; } = "SCP чат включен.";

        [Description("Сообщение о выключении чата")]
        public string ChatDisabled { get; set; } = "SCP чат выключен.";

        [Description("Сообщение о включении режима шпиона")]
        public string SpyModeEnabled { get; set; } = "Режим наблюдения за SCP чатом включен.";

        [Description("Сообщение о выключении режима шпиона")]
        public string SpyModeDisabled { get; set; } = "Режим наблюдения за SCP чатом выключен.";

        [Description("Заголовок отладочной информации для одного игрока")]
        public string DebugHeaderSingle { get; set; } = "=== ScpChat Debug {0} ===";

        [Description("Заголовок отладочной информации для всех игроков")]
        public string DebugHeaderAll { get; set; } = "=== Overall ScpChat Debug ===";

        [Description("Заголовок конфигурации в отладке")]
        public string DebugConfigHeader { get; set; } = "=== Plugin config ===";

        [Description("Текущая роль в отладке")]
        public string DebugCurrentRole { get; set; } = "Текущая роль: {0}";

        [Description("Команда в отладке")]
        public string DebugTeam { get; set; } = "Команда: {0}";

        [Description("Является SCP в отладке")]
        public string DebugIsScp { get; set; } = "Является SCP: {0}";

        [Description("Доступ к чату в отладке")]
        public string DebugChatAccess { get; set; } = "Доступ к SCP чату: {0}";

        [Description("Активная кастомная роль в отладке")]
        public string DebugActiveCustomRole { get; set; } = "Активная кастомная роль: {0}";

        [Description("Кастомная роль разрешена в отладке")]
        public string DebugCustomRoleAllowed { get; set; } = "Кастомная роль разрешена: {0}";

        [Description("Кастомная роль отсутствует в отладке")]
        public string DebugNoCustomRole { get; set; } = "Кастомная роль: отсутствует";

        [Description("Разрешенные роли в отладке")]
        public string DebugAllowedRoles { get; set; } = "Разрешенные роли: {0}";

        [Description("Разрешенные кастомные роли в отладке")]
        public string DebugAllowedCustomRoles { get; set; } = "Разрешенные кастомные роли: {0}";

        [Description("Зарегистрированные кастомные роли в отладке")]
        public string DebugRegisteredCustomRoles { get; set; } = "Зарегистрированные кастомные роли: {0}";

        [Description("Общее количество зарегистрированных ролей в отладке")]
        public string DebugTotalRegisteredRoles { get; set; } = "Всего зарегистрированных кастомных ролей: {0}";

        [Description("Имена зарегистрированных ролей в отладке")]
        public string DebugRegisteredRoleNames { get; set; } = "Имена зарегистрированных ролей: {0}";

        [Description("Подсказка для команды отладки")]
        public string DebugAllHint { get; set; } = "Используйте 'scpdebug all' для проверки всех игроков.";

        [Description("Сообщение о загрузке плагина")]
        public string PluginLoaded { get; set; } = "Плагин ScpChat загружен.";

        [Description("Сообщение о выгрузке плагина")]
        public string PluginUnloaded { get; set; } = "Плагин ScpChat выгружен.";

        [Description("Сообщение об ошибке при проверке кастомных ролей")]
        public string CustomRoleCheckError { get; set; } = "Ошибка при проверке кастомных ролей для {0}: {1}";

        [Description("Сообщение об ошибке при получении имени кастомной роли")]
        public string CustomRoleNameError { get; set; } = "Ошибка при получении имени кастомной роли для {0}: {1}";

        [Description("Да")]
        public string Yes { get; set; } = "Да";

        [Description("Нет")]
        public string No { get; set; } = "Нет";

        [Description("Отсутствует")]
        public string None { get; set; } = "Отсутствует";
        
        [Description("Описание команды отправки сообщения в SCP чат")]
        public string ScpChatCommandDescription { get; set; } = "Отправляет сообщение в чат SCP.";
        
        [Description("Описание команды тестирования SCP чата")]
        public string ScpChatTestCommandDescription { get; set; } = "[DEBUG] Тестирует видимость сообщений в SCP чате.";
        
        [Description("Описание команды переключения SCP чата")]
        public string ScpChatToggleCommandDescription { get; set; } = "Включает или отключает SCP чат.";
        
        [Description("Описание команды наблюдения за SCP чатом")]
        public string ScpChatSpyCommandDescription { get; set; } = "Включает/выключает просмотр SCP чата.";
        
        [Description("Описание команды отладки SCP чата")]
        public string ScpChatDebugCommandDescription { get; set; } = "Отладочная команда для проверки кастомных ролей SCP чата.";
        
        [Description("Сообщение о том, что форматирование было удалено из сообщения")]
        public string FormattingRemoved { get; set; } = "Внимание: из вашего сообщения были удалены теги форматирования.";
        
        [Description("Сообщение о том, что кастомные роли не найдены")]
        public string NoCustomRolesFound { get; set; } = "Кастомные роли не найдены";
        
        [Description("Заголовок детальной диагностики кастомных ролей")]
        public string DetailedCustomRoleDiagnostic { get; set; } = "=== Debug ===";
        
        [Description("Найденные кастомные роли через метод Check")]
        public string FoundRolesViaCheck { get; set; } = "Найденные кастомные роли через Check(): {0}";
        
        [Description("Найденные кастомные роли через метод TryGet")]
        public string FoundRolesViaTryGet { get; set; } = "Кастомные роли через TryGet(): {0}";
        
        [Description("Сообщение когда кастомные роли не найдены через Check")]
        public string NoRolesFoundViaCheck { get; set; } = "Кастомные роли через Check(): не найдены";
        
        [Description("Сообщение когда кастомные роли не найдены через TryGet")]
        public string NoRolesFoundViaTryGet { get; set; } = "Кастомные роли через TryGet(): не найдены";
        
        [Description("Статус блокировки форматирования в отладке")]
        public string DebugFormattingBlocked { get; set; } = "Блокировка форматирования: {0}";
        
        [Description("Текст тестового сообщения")]
        public string TestMessage { get; set; } = "Это тестовое сообщение.";
        
        [Description("Сообщение об успешном переключении состояния чата")]
        public string ChatToggleSuccess { get; set; } = "SCP чат {0}.";
        
        [Description("Включен")]
        public string Enabled { get; set; } = "включен";
        
        [Description("Выключен")]
        public string Disabled { get; set; } = "выключен";
        
        [Description("Префикс для отладочных сообщений в логе")]
        public string DebugPrefix { get; set; } = "[ScpChat]";
        
        [Description("Сообщение о том, что игрок имеет кастомную роль")]
        public string PlayerHasCustomRole { get; set; } = "Игрок {0} имеет кастомную роль: {1}";
        
        [Description("Сообщение о количестве найденных кастомных ролей")]
        public string PlayerHasCustomRolesCount { get; set; } = "Игрок {0} имеет {1} кастомных ролей через TryGet";
        
        [Description("Заголовок информации о статусе плагина")]
        public string PluginStatusHeader { get; set; } = "=== Plugin Status ===";
        
        [Description("Состояние чата в отладке")]
        public string DebugChatStatus { get; set; } = "Состояние чата: {0}";
        
        [Description("Количество активных шпионов")]
        public string DebugActiveSpies { get; set; } = "Активных шпионов: {0}";
        
        [Description("Версия плагина в отладке")]
        public string DebugPluginVersion { get; set; } = "Версия плагина: {0}";
        
        [Description("Количество игроков на сервере")]
        public string DebugPlayerCount { get; set; } = "Игроков на сервере: {0}";
        
        [Description("Сообщение об ошибке при выполнении команды")]
        public string CommandExecutionError { get; set; } = "Ошибка при выполнении команды: {0}";
        
        [Description("Сообщение о неизвестной команде")]
        public string UnknownCommand { get; set; } = "Неизвестная команда. Используйте help для получения списка команд.";
        
        [Description("Сообщение о недоступности команды")]
        public string CommandUnavailable { get; set; } = "Команда временно недоступна.";
        
        [Description("Сообщение о перезагрузке конфигурации")]
        public string ConfigReloaded { get; set; } = "Конфигурация плагина перезагружена.";
        
        [Description("Сообщение об ошибке перезагрузки конфигурации")]
        public string ConfigReloadError { get; set; } = "Ошибка при перезагрузке конфигурации: {0}";
        
        [Description("Сообщение о том, что функция в разработке")]
        public string FeatureInDevelopment { get; set; } = "Эта функция находится в разработке.";
        
        [Description("Сообщение о неверном синтаксисе команды")]
        public string InvalidCommandSyntax { get; set; } = "Неверный синтаксис команды. Используйте: {0}";
        
        [Description("Сообщение о том, что сервер перезапускается")]
        public string ServerRestarting { get; set; } = "Сервер перезапускается, чат временно недоступен.";
    }
}
