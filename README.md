### Ответ на Вопрос №3:

```python
res = product_category_pairs.join(products, on='product_id', how='right') \
    .join(categories, on='category_id', how='left') \
    .select('product_name',
            when(col('category_name').isNull(), 'отсутствует').otherwise(col('category_name')).alias("category_name"))

```
