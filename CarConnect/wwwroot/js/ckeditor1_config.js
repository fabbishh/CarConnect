CKEDITOR.editorConfig = function (config) {

    // Добавляем только кнопки для нумерованных списков и выделения жирным текстом
    config.toolbar = [
        { name: 'basicstyles', items: ['Bold'] },
        { name: 'lists', items: ['NumberedList'] }
    ];

    config.height = 700;

   // Остальные настройки по умолчанию
    config.language = 'ru';
    config.uiColor = '#F0F0F0';
    config.enterMode = CKEDITOR.ENTER_P;
    config.shiftEnterMode = CKEDITOR.ENTER_BR;
};
