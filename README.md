Проект сделан с VS2022, .Net Framework 4.8

# Работа с таблицами Google
Для работы программы нужно скачать файл из [Credentials](https://console.cloud.google.com/apis/credentials), назвать его cred.json и положить рядом с исполняемым файлом.
![2022-05-17_023907](https://user-images.githubusercontent.com/15142804/168700060-86fbaccf-f1fc-4a86-8e6d-169024ef8625.png)
# Работа с со скриптами Google
![2022-05-21_081032](https://user-images.githubusercontent.com/15142804/169636740-4c3fdaf0-554f-438a-9849-3bf63a02c296.png)
1. Получить данные проекта скриптов. ID проекта скриптов находится в свойствах [проекта](https://script.google.com/home/projects/)
2. Выбор файла проекта для редактирования. Файл appsscript присутствует всегда. Изменять его без надобности не нужно. Содержимое файла появится в поле редакирования.
3. Сохранение изменений. Сохраняются только изменения в выбранном в данный момент файле.
4. Выбор функции. Позволяет выбрать функцию для запуска. При выборе функции в таблицу добавляются аргументы для вызова этой функции.
5. Запуск функции на исполнении. Запускается только сохранённая версия. Аргументы, если есть, берутся из таблицы.
6. Аргументы выбранной функции
# Подсчёт символов документе Word
Работает с файлами Word: `*.docx`, `*.docm`, `*.dotx`, `*.dotm`, `*.doc`. Для обработки файлов `*.doc` на компьютере должна быть установлена любая версия Word, начиная с Word 2003
![2022-05-21_083019](https://user-images.githubusercontent.com/15142804/169637210-05bb7fdc-19d6-4caf-abbf-aab95b4a2d9b.png)
