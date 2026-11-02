-- isPrime 2
-- not (isPrime 6)

test :: Bool
test = and [isPrime 2, isPrime 11, take 5 primes == [2,3,5,7,11]]

isPrime :: Integer -> Bool
isPrime n = [x | x <- [1..n], mod n x == 0] == [1, n]

primes :: [Integer]
primes = [x | x <- [2.. ], isPrime x]

dominoes :: [(Int, Int)]
dominoes = [(a, b) | a <- [0..6], b <- [a..6]]

allPositive :: [Int] -> Bool
allPositive l = null [n | n <- l, n <= 0]

pairs :: [(Int, Int)]
pairs = [(a, n-a) | n <- [0..], a <- [0..n]]
-- pairs = [(a, b) | a <- [0..], b <- [0..]]

alphabet :: [(Int, Char)]
alphabet = zip [0..] ['a'..'z']
-- alphabet = [(i, a) | a <-['a'..'z'], i <- [0 .. length ['a'..'z'] ]] -- így mégsem lehet

-- unzip' :: [(Int, Int)] -> ([Int], [Int])
unzip' :: [(a, b)] -> ([a], [b]) -- tipus parameter
-- unzip' [(x,y)] = ([x], [y])
unzip' l = ([x | (x, _) <- l], [y | (_, y) <- l])

-- polimorf típusok, műveletekkel nem működnek de pakolgatni lehet listába