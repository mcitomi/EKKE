# Pont helyzete egy körhöz képest

# kérjük be az adatokat
a = int(input("Középpont (a) koordinátája: "))
b = int(input("Középpont (b) koordinátája: "))
r = int(input("Sugár (r): "))
x = int(input("Pont x koodrinátája: "))
y = int(input("Pont y koodrinátája: "))

distance_squared = (x - a)**2 + (y - b)**2
radius_squared = r * r

if (distance_squared < radius_squared):
    print("A pont a kör belsejében van")
else:
    if (distance_squared == radius_squared):
        print("A pont a körön van")
    else:
        print("A pont a körön kívül van")


