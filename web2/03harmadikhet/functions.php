<?php

function MegegyezikE($szam1, $szam2, $tipusStrict)
{
    if ($tipusStrict == true) {
        if ($szam1 === $szam2) {
            return true;
        }
    } else {
        if ($szam1 == $szam2) {
            return true;
        }
    }
    return false;
}

echo MegegyezikE(12, 12, true);

echo "<br>";

function Osszead(int | float $a, int | float $b): int | float
{
    return $a + $b;
}

echo Osszead(3, 4);

echo "<br>";

$Szoroz = function($a, $b) {
    return $a * $b;
};  // ide kell a pontosvesszo mert ez valtozo

echo $Szoroz(3, 3);

function Metodus() : void {
    echo "Ez egy void lol";
}

function br() : void {
    echo "<br>";
}

br();

Metodus();
