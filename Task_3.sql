SELECT 
    p.Name AS [Product],
    c.Name AS [Category]
FROM 
    Products p
LEFT JOIN
    Shop s ON p.ID = s.ProductID
LEFT JOIN 
    Categories c ON s.CategoryID = c.ID
ORDER BY 
    p.Name,
    c.Name;

/*
    Пояснение:
    Из условия понятно, что таблицы находятся в отношении многие ко многим, значит структура базы данных будет выглядеть так:
    - таблица Products c полем Name  и ключом ID
    - таблица Category c полем Name И ключом ID
    - связующая таблица Shop  с внешними ключами CategoryID и ProductsID
    Далее задача решается обычным LEFT JOIN и и выдается результат в отсортированном виде.
    
    Скрипт создания таблиц:
    CREATE TABLE Products (
        ID INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL
    );

    CREATE TABLE Categories (
        ID INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL
    );

    CREATE TABLE Shop (
        ID INT PRIMARY KEY IDENTITY(1,1),
        ProductID INT,
        CategoryID INT,
        FOREIGN KEY (ProductID) REFERENCES Products(ID),
        FOREIGN KEY (CategoryID) REFERENCES Categories(ID)
    );

*/

