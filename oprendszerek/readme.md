# Operációs rendszerek I.
### Apró Anikó

Drive: https://drive.google.com/drive/folders/1cctD-IT1wfLj41rCDndrrQnGFowJwnVR

R.Kitti: http://tinyurl.com/rkop1sub1

### Linux alap parancsok:

`whoami` : Saját usernév lekérdezése

`ls` : Kilistázza a mappában lévő fájlokat

`ls -l` : részletes info

`ls -la` : részletes info + rejtett fájlok

`cd` : Mappába váltás

`mkdir` : "Új mappa létrehozása"

`cp` : Fájl másolása valahonnan valahova

`history` : terminál előzmények listázása

`history > test.txt` : Az előzmények tartalmát kiírjuk a test.txt fájlba. (az előzmények helyett bármit kiírhatunk a fájlba ezzel a kapcsolóval)

`>>` : Hozzáfűzni a fájlhoz az új kimenetet

`>` : Felülírja a fájlt

`2>` : Hibaüzenetekhez ezzel írhatunk bele fájlba

`2>>` : Hiba hozzáfűzése 

pl : `ls nemletezo_file 2> err.txt`

`cat test.txt` : A test.txt fájl tartalmának konzolra írása. 

Fájlból parancsba irányítás: `wc -l < err.txt`

Pipe: `|` : Több parancsot futtathatunk egymás után, és az első parancs kimenetét átadja a másik bemenetének. pl: `ls -l | grep .txt`

pl több parancs: `cat log.txt | grep error | sort | unique -c`

`cut -d',' -f1,3 nevek.txt`: Szétvág a vessző mentén és csak a 1. és 3. fieldeket adja vissza (1-től kezd)

`head -n 5` : Első 5 sor megjelenítése

`tail -n 5` : Utolsó 5 sor megjelenítése

(Alapból 10 sort jelenítenek meg -n nélkül)

`tr 'a' 'b' < nevek.txt` a betűk b-re cserélése

`grep "2023" nevek.txt | tee evszam.txt` : tee: A megadott bemenetet kiírja egy fájlba és a konzolba is

`tac` : ugyan az mint a cat csak fordítva írja ki

### Windows alap parancsok:

`dir` : Fájlok listázása (mint linuxon az ls)

`cd` : Mappába való belépés

`md` : Új mappa létrehozása

`copy` : Fájl másolása

`ipconfig` : Hálózati infó pl ip lekérdezése

`ping` : Hálózati kapcsolat tesztelése

`tasklist` : Futó folyamatok listázása

`taskkill` : Futó folyamatok leállítása

