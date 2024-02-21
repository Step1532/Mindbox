### Ответ на Вопрос №3:

```sql
SELECT p.Name AS ProductName, ISNULL(c.Name, 'Отсутствует') AS CategoryName
FROM Products p
LEFT JOIN ProductsCategories pc ON pc.ProductId = p.Id 
LEFT JOIN Categories c ON pc.CategoryId = c.Id
```