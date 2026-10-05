f __ x = x * 2

and' :: Bool -> Bool -> Bool
and' True True = True
and' _ _ = False    -- Az alulvonások helyére bármi behelyettesülhet

or' :: Bool -> Bool -> Bool
or' False False = False
or' _ _ = True

xor' :: Bool -> Bool -> Bool
xor' True False = True
xor' False True = True
xor' _ _ = False

add :: Int -> Int -> (Int, Int) -- bináris összeadás (egész, maradék)
add 1 1 = (0, 1)
add 0 0 = (0, 0)
add 1 0 = (1, 0)
add 0 1 = (1, 0)

paren :: Char -> Char -> Bool
paren '(' ')' = True
paren '[' ']' = True
paren '{' '}' = True
paren _ _ = False

calc :: (Int, Char, Int) -> Int
calc (a, '+', b) = a + b
calc (a, '-', b) = a - b
calc (a, '*', b) = a * b
calc (a, '/', b) = a `div` b
-- infix   

-- infix: A két paraméter közé kerül
-- prefix: A paraméterek elé kerül

isSpace :: Char -> Bool
isSpace ' ' = True
isSpace _ = False

-- fact 0 ?
-- fact _ ? => n - 1

fact :: Integer -> Integer  -- Integer: Haskell max memória méretű szám, Int kisebb, előre meghatározott
fact 0 = 1
fact n = n * fact(n - 1)    -- meghívja magát, csak az n-1 érétkével, viszont 0-nál megáll, mert 0* nem futtathatja

