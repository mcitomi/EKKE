<?php
require_once("auth.php");
require_once("db.php");

CheckLogged();
CheckAdmin();
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Főoldal as Admin</title>
</head>
<body>
    <h1>Üdv <?= $_SESSION['username'] ?></h1>
    <p>Admin panel</p>
    
</body>
</html>