module Elso where

add :: Int -> Int -> Int
add x y = x + y

inc :: Int -> Int
inc x = x + 1

even' :: Int -> Bool
even' x = mod x 2 == 0

-- :load :l file betöltés
-- :reload :r betöltött file újra töltése
-- :t type lekérése
-- :i informaciok lekeres

-- Minden függvény meghívható pl 10 `add` 20 = add 10 20 vagy (+) 10 20