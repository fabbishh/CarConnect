CKEDITOR.editorConfig = function (config) {
    // Удаляем все кнопки из тулбара
    config.toolbar = [];

    // Добавляем только кнопки для нумерованных списков и выделения жирным текстом
    config.toolbar.push(['NumberedList']);
    config.toolbar.push(['Bold']);

    config.height = 700;

   // Остальные настройки по умолчанию
    config.language = 'ru';
    config.uiColor = '#F0F0F0';
    config.enterMode = CKEDITOR.ENTER_P;
    config.shiftEnterMode = CKEDITOR.ENTER_BR;
};
