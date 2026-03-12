<?php
$szam1 = 21;
$szam2 = 67;

$szoveg = "Meow";

echo $szam1 . PHP_EOL;

echo $szoveg . PHP_EOL;

const ELETKOR = 18;

$felnotte = true;

if (ELETKOR > 18) {
    $felnotte = false;
} else {
    $felnotte = true;
}

echo $felnotte ? "Felnőtt" : "Kiskorú";


$x1 = 12;
$x2 = 36;

echo ($x1 <=> $x2) . PHP_EOL;

$hetNapja = "Pentek";

switch ($hetNapja) {
    case "Pentek":
        echo "Ma psg van";
        break;
    case "Szerda":
        echo "Ma házy attila kalkulus II van";
        break;
    case "Csütörtök":
        echo "Ma webprog2 van";
        break;
}

$szamtomb = [1, 2, 3, 4, 5, 6, 7];

foreach ($szamtomb as $szam) {
    if ($szam % 2 == 0) {
        $szam = "paros";
        echo "van paros szam";
    }
}

print_r($szamtomb);

foreach ($szamtomb as &$szam) { // memória cim kereses is
    if ($szam % 2 == 0) {
        $szam = "paros";
    }
}

print_r($szamtomb);

for ($i=0; $i < 5; $i++) { 
    echo $i . PHP_EOL;
}

$szamlalo = 0;
while ($szamlalo < 5) {
    $szamlalo++;

    echo "szam: $szamlalo" . PHP_EOL;
}

// linearis kereses algo

$lista = [2, 32, 45, 5, 4, 67, 3, 8, 97];

$keresettElem = 67;

$sorszam = 0;
$megtalaltuke = false;

for ($i=0; $i < count($lista); $i++) { 
    if($lista[$i] == $keresettElem) {
        $sorszam = $i;
        $megtalaltuke = true;
        break;
    }
}

if($megtalaltuke) {
    echo "\nA keresett elem a" . $sorszam + 1 . "helyen van";
}