-- listák
-- 1 : 2 : 3 : 4 : []
-- l = 1 : 2 : 3 : 4 : []
-- l:4

-- l -> 4 -- kivesz

-- [1..10] -- range

-- take 5 [1..] -- végtelen listából első 5-öt veszi ki

-- [10..1] -- visszafele nem mgey, üres lista

-- [2, 3..10] -- kettőtől lepi a szamokat
-- [2, 5..10] -- harmassaval lepked

-- [10-2, 9-3..0] -- -> [8,6,4,2,0] -- mégis lépked vissazfele csak trükkel

import Data.Char

headInt :: [Int] -> Int
headInt (h : _) = h

tailInt :: [Int] -> [Int]
tailInt (_ : t) = t

-- headTuple [('a', 1), ('b', 2)] == 1
headTuple :: [(Char, Int)] -> Int
-- headTuple [(_, x), (_, _)] = x
headTuple ((_, x) : _) = x

nullInt :: [Int] -> Bool
nullInt [] = True
nullInt _ = False -- minden másra false (_ pattern mindent elfogad)

unittest :: Bool
unittest = 
    and [ -- listára is működik az 'and'
        tailInt [1, 2, 3] == [2, 3],
        headTuple [('a', 1), ('b', 2)] == 1,
        nullInt [] == True,
        not (isSingleton []),
        isSingleton [5],
        not (isSingleton [6, 8]),
        not (isSingleton [5..])
    ]
-- bentebb kell kezdeni a [] zárójelet

isSingleton :: [Int] -> Bool
isSingleton [_] = True
isSingleton _ = False

toUpperFirst :: [Char] -> [Char]
toUpperFirst (c:cs) = toUpper c : cs    -- szétszedjük, majd újra hozzáadjuk a lista elejéhez (a cs lista maradt, a c nem)

isLetter' :: Char -> Bool
isLetter' x = elem x ['A'..'z'] -- elem függvény = megnézi hogy az x elem benne van e a listában

