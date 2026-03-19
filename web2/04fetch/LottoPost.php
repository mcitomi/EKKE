<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <form method="POST" action="">
        <label>1. tipp: <input type="number" min='1' max='90' name="t1"> </label>
        <label>2. tipp: <input type="number" min='1' max='90' name="t2"> </label>
        <label>3. tipp: <input type="number" min='1' max='90' name="t3"> </label>
        <label>4. tipp: <input type="number" min='1' max='90' name="t4"> </label>
        <label>5. tipp: <input type="number" min='1' max='90' name="t5"> </label>

        <button type="submit">Posztolás :p</button>
    </form>
    <?php
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        if (
            isset($_POST["t1"], $_POST["t2"], $_POST["t3"], $_POST["t4"], $_POST["t5"])
            && $_POST["t1"] !== "" && $_POST["t2"] !== "" && $_POST["t3"] !== ""
            && $_POST["t4"] !== "" && $_POST["t5"] !== ""
        ) {
            $tippek = [
                (int)$_POST["t1"],
                (int)$_POST["t2"],
                (int)$_POST["t3"],
                (int)$_POST["t4"],
                (int)$_POST["t5"],
            ];

            $nyeroszamok = [];

            while (count($nyeroszamok) < 5) {
                $szam = rand(1, 90);

                if (!in_array($szam, $nyeroszamok)) {
                    $nyeroszamok[] = $szam;
                }
            }

            $talalatok = 0;
            foreach ($tippek as $tipp) {
                if (in_array($tipp, $nyeroszamok)) {
                    $talalatok++;
                }
            }

            echo "<h2>Eredmények:<h2>";
            echo "Tippjeid: " . print_r($tippek);
            echo "Nyerőszámok:" . print_r($nyeroszamok);
            echo $talalatok . "db találatod van";
        } else {
            echo "Tölts ki minden mezőt!";
        }
    }
    ?>
</body>

</html>