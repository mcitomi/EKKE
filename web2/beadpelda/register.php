<?php
require_once("db.php");

$hiba = "";
$siker = "";

$username = trim($_POST['username']) ?? "";
$password = trim($_POST['password']) ?? "";
$is_admin = isset($_POST['is_admin']) ? 1 : 0;

if($username == "" || $password == "") {
    $hiba = "Minden mező kitöltése kötelező!";
} else {
    $hash = password_hash($password, PASSWORD_DEFAULT);

    $lekerdezes = $conn->prepare("INSERT INTO users (username, password, is_admin) VALUES (?, ?, ?)");
    $lekerdezes->bind_param("ssi", $username, $hash, $is_admin);

    if($lekerdezes->execute()) {
        $siker = "Sikeres regisztráció!";
    } else {
        $hiba = "Regisztráció sikertelen!";
    }
}

?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Regisztráció</title>
</head>
<body>
    <h1>Regisztráció</h1>

    <form method="post">
        <label >Felhasználónév:
            <input type="text" name="username" required>
        </label>

        <label >Jelszó:
            <input type="password" name="password" required>
        </label>

        <label> Admin:
            <input type="checkbox" name="is_admin" value="1">
        </label>

        <button type="submit">Regisztráció</button>
    </form>

    <p style="color: red;"><?= $hiba ?></p>
    <p style="color: green;"><?= $siker ?></p>

    <p><a href="login.php">Bejelentkezés</a><p>
</body>
</html>
