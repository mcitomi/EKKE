insert into categories (id, name) values (1, 'Informatika');
insert into categories (id, name) values (2, 'Regény');
insert into categories (id, name) values (3, 'Ismeretterjesztő');

insert into books (id, title, author, price, published_on, category_id, stock)
    values (1, 'SQL kezdőknek', 'Kiss Anna', 4500, TO_DATE('2022-03-10', 'YYYY-MM-DD'), 1, 8);
insert into books (id, title, author, price, published_on, category_id, stock)
    values (2, 'Adatbázisok világa', 'Nagy Péter', 6200, TO_DATE('2023-09-01', 'YYYY-MM-DD'), 1, 3);
insert into books (id, title, author, price, published_on, category_id, stock)
    values (3, 'C# alapok', 'Kiss Anna', 5800, TO_DATE('2024-02-15', 'YYYY-MM-DD'), 1, 0);
insert into books (id, title, author, price, published_on, category_id, stock)
    values (4, 'A régi ház', 'Tóth Éva', 3900, TO_DATE('2021-06-20', 'YYYY-MM-DD'), 2, 12);
insert into books (id, title, author, price, published_on, category_id, stock)
    values (5, 'Utazás északra', 'Szabó Ádám', 4500, TO_DATE('2023-11-05', 'YYYY-MM-DD'), 2, 5);
insert into books (id, title, author, price, published_on, category_id, stock)
    values (6, 'A világűr titkai', 'Varga Dóra', 6200, TO_DATE('2024-01-10', 'YYYY-MM-DD'), 3, 2);

commit;