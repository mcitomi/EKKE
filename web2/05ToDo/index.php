<?php
require_once("db.php");
require_once("auth.php");

csakBejelentekzve();

$userId = $_SESSION["user_id"];
$username = $_SESSION["username"];

$lekerdezes = $conn->prepare(
    "SELECT id, task, category, priority, is_done, created_at 
    FROM tasks 
    WHERE user_id = ? ORDER BY is_done ASC, id DESC"
);

$lekerdezes->bind_param("i", $userId);
$lekerdezes->execute();

$result = $lekerdezes->get_result();



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
    <?php if ($result->num_rows > 0) : ?>
        <ul class="task-list">
            <?php while($row = $result->fetch_assoc()) : ?>
                <li class="task-item" <?=  $row["is_done"] ? "done" : "nop"  ?>> 
                    <div>
                    <form method="post" action="done.php?id=<?= $row["id"] ?> class="doneform">
                        <input type="hidden" name="taskId" value="<?= $row["id"] ?>"/>
                        <input 
                            type="checkbox"
                            name="is_done"
                            onchange="this.form.submit()"
                            <?= $row["is_done"] ? "checked" : "" ?>
                        />
                    </form>
                    <strong class = "task_title"><?= htmlspecialchars($row["task"]) ?></strong>
                    <a class="deleteBtn" href="deleteTodo.php?id=<?= $row["id"] ?>>">Törlés</a>
                    </div>
                    <div>
                        <span>kategória: <?= htmlspecialchars($row["category"]) ?></span>
                        <span>fontosság: <?= htmlspecialchars($row["priority"]) ?></span>
                    </div>
                    <p>Létrehozva: <?= htmlspecialchars($row["created_at"]) ?></p>
                </li>
            <?php endwhile; ?>
        </ul>
    <?php else: ?>
        <p>Nincs megjeleníthető adat</p>
    <?php endif; ?>
</body>

</html>