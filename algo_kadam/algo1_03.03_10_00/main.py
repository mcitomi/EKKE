print("HEllOw ord")

a = 10
b = 3

print(a % b)
print(a ** b)

print(type("Asasm")) # string
print(type('Adam')) # string ez is

print('Asd "asd" asd') # idézőjelezt is kiírathatunk

x = int(input("Adj meg egy számot: ")) # típuskényszerítés
print(type(x))
print(x * 20)

szoveg = "Adam"
print(szoveg * 3) # 3x kiírja a szöveget
# print(szoveg + 3) # de pl összeadni szamot nem lehet szöveggel, nem konvertalja stringgé a szamot

nev = "Adam"
kor = 30
print("Az én nevem:", nev, "és korom:", kor, sep=" - ") # sep: vesszőknél ahol össze van rakva astring, oda ileeszti be

print("Az én nevem " + nev + " és a korom " + str(kor))

print(f"Az én nevem {nev} és a korom {kor}")

a, b = 10, False

print(2 > 1 and 7 > 6)

## && -> and
# || -> or

