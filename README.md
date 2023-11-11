# Медицинский осмотр
Проект по предмету "Проектирование информационных систем"

# Инструкция по сборке и запуску

Перед сборкой и запуском приложения удостоверьтесь, что на компьютере установлены:

1. СУБД PostgreSQL 16
2. Visual Studio
3. .NET Core 6.0

Сборка и запуск:

1. Склонируйте этот репозиторий
2. Откройте приложение в Visual Studio
3. В проекте ServerME в файле Data/Context.cs в методе OnConfiguring измените в конфигурационной строке Password={Ваш пароль от сервера в PostgreSQL}, сервер локальный
4. В проекте ServerME в файле Data/DataBaseFiller.cs можете изменить заполнение базы данных, если не устраивает стандартный набор данных. При последующем использовании (после первого запуска), чтобы данные не обновлялись постоянно на заранее заполненные в DataBaseFiller.cs закомментируйте в Program.cs 3 и 4 строки с dbFiller
5. Для одновременного запуска клиента и сервера необходмо сделать запуск нескольких проектов, для этого в обозревателе решений нажмите ПКМ на решение, выберите "Настрока начальных проектов", в открывшимся окне выберите "Несколько запускаемых проектов", в колонке "Действия" выберите для обоих проектов из списка "Запуск", нажмите "Применить" и "ОК"
6. Запустите приложение 
