module Practice2 where

add:: Int -> Int -> Int
add x y  = x + y
-- add = (+1);

odd' :: Int -> Bool
odd' x = x `mod` 2 /= 0 -- A /= a tagadás, nem a !-jel.

divides :: Int -> Int -> Bool
divides x y = x `mod` y == 0    -- Használható függvényként meghívva is, pl x y = mod x y == 0

area :: Int -> Int -> Int
area x y = x * y

triangleSides :: Int -> Int -> Int -> Bool
triangleSides a b c = a + b > c && a + c > b && b + c > a

pythagoreanTriple :: Int -> Int -> Int -> Bool
-- pyth a b c = a^2 + b^2 == c^2
-- pythagoreanTriple a b c = pyth a b c || pyth a c b || pyth c b a

pythagoreanTriple a b c = a2 + b2 == c2 ||  a2 + c2 == b2 || c2 + b2 == a2 
    where
        a2 = a ^ 2
        b2 = b ^ 2
        c2 = c ^ 2  

isLeapYear :: Int -> Bool
isLeapYear x = (x `divides` 4 && not (x `divides` 100)) || x `divides` 400

addx :: (Int, Int) -> (Int, Int) -> (Int, Int)  -- tuple típusok összeadása, tört logika, közös nevezőre hozva
addx (n, d) (n', d') = (n * d' + n' * d, d * d')

mul :: (Int, Int) -> (Int, Int) -> (Int, Int)   -- tört szorzás tuplelel
mul (n, d) (n', d') = (n* n', d * d')

modDiv :: Int -> Int -> (Int, Int)
modDiv n d = (n `mod` d, n `div` d)

-- dominó illeszthető e? ha két szám gyenlő
matches :: (Int, Int) -> (Int, Int) -> Bool
matches (n, d) (n', d') = n == n' || n == d' || d == n' || d == d'
