<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lotto</title>
</head>

<body>
    <?php
    if (count($_GET) != 5) {
        echo "Adj meg 5 tippet";
        echo "Tippjeid parameterbe add meg ... ?t1=67&t2=69&t3=42...";
    }

    $tippek = [];

    foreach ($_GET as $tipp) {
        if (!in_array($tipp, $tippek)) {
            $tippek[] = $tipp;
        } else {
            echo "A " . $tipp . " szám kétszer szerepel, adjon meg újat!";
            return;
        }
    }

    $nyeroszamok = [];

    while (count($nyeroszamok) < 5) {
        $szam = rand(1, 90 + 1);

        if (!in_array($szam, $nyeroszamok)) {
            $nyeroszamok[] = $szam;
        }
    }

    $talalat = 0;

    foreach ($tippek as $tipp) {
        if (in_array($tipp, $nyeroszamok)) {
            $talalat++;
        }
    }

    echo $talalat . "db találatod van";

    print_r($nyeroszamok);
    echo "<br>";
    print_r($tippek);

    ?>
</body>

</html>