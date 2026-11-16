module GY9 where 

repeat' :: n -> [n]
repeat' x = x : repeat' x

take' :: Int -> [a] -> [a]
take' 0 _ = []
take' x [] = []
take' n (x:xs) = x: take' (n-1) xs 

-- asd (x:xs) = x xs -- x = elsó karakter, xs = a lista maradek resze

drop' :: Int -> [a] -> [a]
drop' 0 l = l
drop' _ [] = []
drop' n (x:xs) = drop' (n-1) xs

-- hu-HU -> ("hu", "HU")
langAndRegion :: String -> (String, String)
langAndRegion x = (take' 2 x, drop' 3 x)

zip' [] _ = []
zip' _ [] = []
zip' (a:as) (b:bs) = (a, b) : zip' as bs

-- unzip' l = ([x | (x, _) <- l], [y | (_, y) <- l])

unzip' :: [(a, b)] -> ([a], [b])
unzip' [] = ([], [])
unzip' ((a,b):ps) = (a:as, b:bs)
    where 
        (as, bs) = unzip' ps

concat' :: [[a]] -> [a]
concat' [] = []
concat' (l:ls) = l ++ concat' ls

nub' :: (Eq x) => [x] -> [x]    -- az a tipusu elemben mostmár benne van az == operator
nub' [] = []
nub' (x:xs) = x : nub' [ x' | x' <- xs, x' /= x] -- csak akkor rakja bele a listaba ha igaz a feltetel


main = [
    take 3 (repeat' 'a') == "aaa",
    take 10 (repeat' 'a') ==  replicate 10 'a',
    take' 4 "hello world" == "hell"
    ]

