/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // ��������� ������ � ������ ���������
    config.width = '100%'; // ������ ���������
    config.height = 700;

    // ��������� �������
    config.toolbar = [
        { name: 'document', items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
        { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
        { name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
        '/',
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
        { name: 'links', items: ['Link', 'Unlink'] },
        { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
        '/',
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
        { name: 'others', items: ['-'] },
    ];

    // ��������� ������ ��������
    config.format_tags = 'p;h1;h2;h3;pre';

    // ��������� ����� (�� �������)
    config.language = 'ru';

    // ��������� ������� ��������� (�����) ��������
    config.coreStyles_bold = { element: 'strong', overrides: 'b' };
    config.coreStyles_italic = { element: 'em', overrides: 'i' };
    config.coreStyles_strike = { element: 'del' };

    // ��������� ������� �������� (��� ������� ����� ��� ��������������)
    config.forcePasteAsPlainText = true;

    // ��������� �����
    config.stylesSet = [
        { name: 'Title', element: 'h2', styles: { 'font-size': '24px' } },
        { name: 'Subtitle', element: 'h3', styles: { 'font-size': '18px' } },
        { name: 'Quote', element: 'blockquote', styles: { 'font-style': 'italic' } },
        { name: 'Left Align', element: 'p', styles: { 'text-align': 'left' } },
        { name: 'Center Align', element: 'p', styles: { 'text-align': 'center' } },
        { name: 'Right Align', element: 'p', styles: { 'text-align': 'right' } },
        { name: 'Justify', element: 'p', styles: { 'text-align': 'justify' } }
    ];
};


