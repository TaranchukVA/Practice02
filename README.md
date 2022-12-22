Тестовое задание 1

Загрузка информации из внешней системы.

Необходимо написать консольную программу на С#. 
Программа должна загружать данные о покупках из XML файла в базу данных
Пример XML файла

```xml
<orders>
    <order>
        <no>1</no>
        <reg_date>2012.12.19</reg_date>
        <sum>234022.25</sum>
        <product>
            <quantity>2</quantity>
            <name>LG 1755</name>
            <price>12000.75</price>
        </product>
        <product>
            <quantity>5</quantity>
            <name>Xiomi 12X</name>
            <price>42000.75</price>
        </product>
        <product>
            <quantity>10</quantity>
            <name>Noname 14232</name>
            <price>1.7</price>
        </product>
        <user>
            <fio>Иванов Иван Иванович</fio>
            <email>abc@email.com</fio>
        </user>
    </order>
    <order>
        <no>122</no>
        <reg_date>2018.01.09</reg_date>
        <sum>126065,05</sum>
        <product>
            <quantity>3</quantity>
            <name>Xiomi 12X</name>
            <price>42000.75</price>
        </product>
        <product>
            <quantity>20</quantity>
            <name>Noname 222</name>
            <price>3.14</price>
        </product>
        <user>
            <fio>Петров Виктор Семенович</fio>
            <email>xyz@email.com</fio>
        </user>
    </order>
</orders>
```

Настройка:
1. В файле Appsettings.json в каталоге Exercise1 заполнить пропуски для подключения к СУБД PosetgreSQL,
2. Выбрать проект Exersice1 для дальнейших действий,
3. В консоли диспетчера пакетов выполнить команду add-migration init для генирации кода, исползуемого для создания БД,
4. Собрать проект,
5. Запустить проект.

Проверка методов:
1. Ввести путь к xml файлу.
2. Для повтора нажать Y.
