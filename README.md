Завдання:
Створити проект що буде реалізовувати прості 2д механіки використавши для роботи надані матеріали (архів з 2д спрайтам).
Для складання тестового рівня використайте ассет із стору.Сумістити можливості нативного паралаксу чи програмного, і камери для презентації персонажу і об'єму за ним(як референс камера у грі Ori). Майте на увазі персонажі 3D, оточення 2D/3D.
Створіть меню запуску гри, на рівні паузу.
Створит 2 персонажі (будь які моделі на ваш вибір із Mixamo) герой котрим управляємо(рух, атака, без руху на місці) і ворог(те саме), що повинен мати  зону зору і при попаданні ГГ у неї спробувати атакувати його, також стан базового патрулювання від точки до точки., дати як можливо більшу кількість параметрів для налаштування. Також реалізувати систему хелс пойнтів і нанесення пошкоджень. І спавн ворогів поза камерою.
знайти у мережі будь-яку безкоштовну воду (океан/річка) і накласти постпроцессінг. Вода повинна бути і до  і після 0 плану персонажів. 
Усі реалізації і використані патерни на ваш розсуд. 

Посилання:
https://www.mixamo.com/
https://assetstore.unity.com/packages/2d/environments/free-asset-2d-handcrafted-art-117049

Реалізовано:
Керування персонажем стрілочками або кнопками A і D. Прижок на стрілочку вверх, пробіл або кнопку W. Атака на клік мишки або Shift. Налпштування кнопок у файлі Assets/Settings/InputActions.
Прижки з-під платформ. Налаштування руху гравця у файлі Assets/Settings/Gameplay/PlayerMovementConfig.
Два бота: пасивний патрулюючий і агресивний патрулюючий, наносять гравцю урон при дотику, після смерті можуть воскреснути, якщо будуть за межами камери.

Не реалізовано:
Дабл джамп, даш, прижок вниз під платформу. Анімація удару ворогом. Інші типи ворогів. Звуки.
