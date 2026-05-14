<?php
require_once("auth.php");
require_once("db.php");

$hiba = "";

$username = trim($_POST['username']) ?? "";
$password = trim($_POST['password']) ?? "";

if($username == "" || $password == "") {
    $hiba = "Minden mező kitöltése kötelező!";

} else {    
    $lekerdezes = $conn->prepare("SELECT * FROM users WHERE username = ?");
    $lekerdezes->bind_param("s", $username);

    if($lekerdezes->execute()) {
        $res = $lekerdezes->get_result();
        $user = $res->fetch_assoc();

        if($user && password_verify($password, $user['password'])) {
            $_SESSION['u_id'] = $user['id'];
            $_SESSION['username'] = $user['username'];
            $_SESSION['is_admin'] = $user['is_admin'];

            header("Location: index.php");
            exit;
        }
    } else {
        $hiba = "Hibás felhasználónév vagy jelszó!";
    }
}

?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Bejelentkezés</title>
</head>
<body>
    <h1>Bejelentkezés</h1>

    <form method="post">
        <label >Felhasználónév:
            <input type="text" name="username" required>
        </label>

        <label >Jelszó:
            <input type="password" name="password" required>
        </label>

        <button type="submit">Bejelentkezés</button>
    </form>

    <p style="color: red;"><?= $hiba ?></p>

    <p><a href="register.php">Regisztráció</a><p>
</body>
</html>
