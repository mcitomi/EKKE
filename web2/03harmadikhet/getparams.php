<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Lelkitaplalek</title>
</head>
<body>
    <?php
    if(!empty($_GET)) {
        print_r($_GET);

        $szemely = $_GET;

        echo "Szia " . $szemely["nev"] . "!";

        echo "<br>";

        if(isset($_GET["nev"]) && isset($_GET["kor"])) {
            echo "Szia " . $_GET["nev"] . "! Te " . $_GET["kor"] . "éves vagy.";
        }
    } else {
        echo "Üres adatok";
    }
    ?>
</body>
</html>