import Data.Char

g :: Int -> Int
g x = x + 1

f:: (Int -> Int) -> Int -> Int  -- a g függvény szignatura si bele van írva, plát lehet adni a g függvényt, vagy egy megegyező szign. lambdat
f g a = g a                     --  f (\x -> x*3) 10

map' :: (a -> b) -> [a] -> [b]  -- map: a tömb minden elemére alkalmazza a megadott függvényt és vissza adja az átalakított listat
map' _ [] = []
--map' f l = [f x |  x <- l]
map' f (x:xs) = f x : map' f xs

filter' :: (a -> Bool) -> [a] -> [a] -- filter: majdnem olyan mint a map, de nem alakítja át az elemeket csak kiszűri a nem megfelelőket, ezért maradhat az a tipus vegig
filter' _ [] = []
filter' f l = [x | x <- l, f x]

-- filter' f (x:xs) 
--     | f x = x : filter' f xs
--     | otherwise = filter' f xs

takeWhile' :: (a -> Bool) -> [a] -> [a]
takeWhile' _ [] = []
takeWhile' f (x:xs) | f x = x : takeWhile' f xs | otherwise = []

all' :: (a -> Bool) -> [a] -> Bool  -- összesre igaz
all' _ [] = True
all' f (x:xs) = f x && all' f xs

any' :: (a -> Bool) -> [a] -> Bool  -- akár egyikre is igaz
any' _ [] = False
any' f (x:xs) = f x || any' f xs

-- zh:
-- tipusszignatura keszites
-- rekurziv fuggveny, ha keri a feleadat akkor csak azzal ne listaval
-- lambda
-- zip, unzip, any, all, faktorialis, while és | if függvényben pipeline, pattern matching az üres lista esetekre
-- kb minden temakörben 1 feladat.
-- tesztelőt kell majd írni hozzá
-- van pót zh, nincs ai, kérdezni lehet
-- l@(a:as) => az l tartalmazza az a és as-t is, lista elnevezés