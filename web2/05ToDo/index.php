<?php
require_once("db.php");
require_once("auth.php");

csakBejelentekzve();

?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ToDo App PHP BLEH</title>
</head>

<body>
    <h1>ToDo tudd a dolgod</h1>
    <p><?= htmlspecialchars($username) ?></p>
    <form action="logout.php" method="post">
        <button>KIjelentkezes</button>
    </form>

    <br>

    <form action="addtodo.php" method="post">
        <div>
            <label>Feladat:</label>
            <input type="text" name="task">
        </div>
        <br>
        <div>
            <label>Kategoria:</label>
            <select name="category">
                <option value="iskola">Iskola</option>
                <option value="munka">M*nka</option>
                <option value="otthon">Otthon</option>
            </select>
        </div>
        <br>
        <div>
            <label>Fontosság:</label>
            <select name="priority">
                <option value="alacsony">Alacsony</option>
                <option value="kozepes">Közepes</option>
                <option value="magas">Magas</option>
            </select>
        </div>

        <button type="submit">Kuldes</button>
    </form>
</body>

</html>