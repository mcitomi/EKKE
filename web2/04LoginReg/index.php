<?php
require_once("auth.php");

csakBejelentekzve();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
   <p> cool <?= htmlspecialchars($_SESSION["username"]) ?></p>

   <form action="logout.php" method="post">
    <button>kijelentkezes</button>
   </form>
</body>
</html>