# hackingpolitics

## Data Requirements

Каталог органа јавне власти je koriscen za automatsko popunjavanje izvora, kada se kao izvor koristi neki organ vlasti ili neka drzavna ustanova.

Link ka katalogu je: [Katalog](http://www.data.poverenik.rs/dataset/katalog/resource/85f49574-e799-4cf6-8e80-b4e8eb18cdc8)

Iako postoji api za pretragu datih ustanova, baza koja se koristi za skladistenje (najverovatnije postgresql) ne tokenizuje dobro web i email adrese. Cela adresa se cuva kao jedan token, pa se ne moze pretraziti preko dela email ili web adrese.

Za ove potrebe je iskoriscen modifikovani upit: http://data.poverenik.rs/api/action/datastore_search_sql?sql=SELECT * FROM \"85f49574-e799-4cf6-8e80-b4e8eb18cdc8\" WHERE _full_text @@ to_tsquery('{0}') OR \"Veb adresa\" LIKE '%{0}%' LIMIT 50

Savet za unapredjenje je da se proveri logika tokenizacije stringova za full text search u datoj bazi.
