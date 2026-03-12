<?php

// Asszociativ tömb:
$auto1 = [
    "tipus" => "Opel",
    "model" => "Astra",
    "evjarat" => 2000
];

$auto2 = [
    "tipus" => "Suzuki",
    "model" => "Ignis",
    "evjarat" => 2005
];

$auto3 = [
    "tipus" => "Trabant",
    "model" => "601",
    "evjarat" => 1988
];

print_r($auto1);
echo "<br/>";

$auto1["szin"] = "Fekete";

print_r($auto1);
echo "<br/>";

$auto2["szin"] = "Flamingó rózsaszín";

$csalad = [
    "Lajos" => $auto2,
    "Nagyfater" => $auto3
];

$csalad["Nagyfater"]["szin"] = "Csibe sárga";

print_r($csalad["Nagyfater"]);

?>