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
    <style>
        :root {
            color-scheme: light;
            --bg: #f4f7fb;
            --panel: rgba(255, 255, 255, 0.88);
            --panel-border: rgba(15, 23, 42, 0.08);
            --text: #102033;
            --muted: #667085;
            --accent: #2563eb;
            --accent-strong: #1d4ed8;
            --danger: #dc2626;
            --success: #16a34a;
            --shadow: 0 18px 50px rgba(15, 23, 42, 0.12);
            --radius: 20px;
        }

        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            min-height: 100vh;
            padding: 40px 20px 56px;
            font-family: Inter, "Segoe UI", Roboto, Helvetica, Arial, sans-serif;
            color: var(--text);
            background:
                radial-gradient(circle at top left, rgba(37, 99, 235, 0.18), transparent 34%),
                radial-gradient(circle at top right, rgba(16, 185, 129, 0.12), transparent 28%),
                linear-gradient(180deg, #eef4ff 0%, #f7f9fc 42%, #eef2f7 100%);
        }

        h1,
        p,
        form,
        .task-list {
            width: min(100%, 760px);
            margin-left: auto;
            margin-right: auto;
        }

        h1 {
            margin: 0 auto 10px;
            padding: 24px 28px 0;
            font-size: clamp(2rem, 4vw, 3.25rem);
            line-height: 1.05;
            letter-spacing: -0.04em;
        }

        body > p:first-of-type {
            margin-top: 0;
            margin-bottom: 22px;
            padding: 0 28px;
            color: var(--muted);
            font-size: 1rem;
        }

        form {
            margin: 16px auto;
            padding: 24px 28px;
            background: var(--panel);
            border: 1px solid var(--panel-border);
            border-radius: var(--radius);
            box-shadow: var(--shadow);
            backdrop-filter: blur(10px);
        }

        form div {
            margin-bottom: 14px;
        }

        label {
            display: block;
            margin-bottom: 8px;
            font-size: 0.95rem;
            font-weight: 600;
            color: #24324a;
        }

        input[type="text"],
        select,
        input[type="password"] {
            width: 100%;
            padding: 12px 14px;
            border: 1px solid rgba(100, 116, 139, 0.28);
            border-radius: 14px;
            background: #fff;
            color: var(--text);
            font: inherit;
            outline: none;
            transition: border-color 0.2s ease, box-shadow 0.2s ease, transform 0.2s ease;
        }

        input[type="text"]:focus,
        select:focus,
        input[type="password"]:focus {
            border-color: rgba(37, 99, 235, 0.55);
            box-shadow: 0 0 0 4px rgba(37, 99, 235, 0.14);
        }

        button,
        .deleteBtn {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
            padding: 11px 16px;
            border: 0;
            border-radius: 999px;
            background: linear-gradient(135deg, var(--accent), var(--accent-strong));
            color: #fff;
            font: inherit;
            font-weight: 700;
            text-decoration: none;
            box-shadow: 0 10px 24px rgba(37, 99, 235, 0.22);
            cursor: pointer;
            transition: transform 0.2s ease, box-shadow 0.2s ease, filter 0.2s ease;
        }

        button:hover,
        .deleteBtn:hover {
            transform: translateY(-1px);
            box-shadow: 0 14px 28px rgba(37, 99, 235, 0.26);
            filter: brightness(1.03);
        }

        button:active,
        .deleteBtn:active {
            transform: translateY(0);
        }

        form[action="logout.php"] {
            margin-top: 0;
            margin-bottom: 18px;
            background: transparent;
            box-shadow: none;
            border: 0;
            padding: 0 28px;
        }

        form[action="logout.php"] button {
            background: linear-gradient(135deg, #0f172a, #334155);
            box-shadow: 0 10px 24px rgba(15, 23, 42, 0.22);
        }

        .task-list {
            list-style: none;
            padding: 0;
            margin-top: 22px;
        }

        .task-item {
            margin: 0 0 16px;
            padding: 22px 24px;
            background: var(--panel);
            border: 1px solid var(--panel-border);
            border-radius: var(--radius);
            box-shadow: var(--shadow);
            backdrop-filter: blur(10px);
        }

        .task-item > div:first-child {
            display: flex;
            align-items: center;
            gap: 14px;
            flex-wrap: wrap;
        }

        .task-item > div:last-child {
            display: flex;
            flex-wrap: wrap;
            gap: 10px 18px;
            margin-top: 14px;
            color: var(--muted);
            font-size: 0.95rem;
        }

        .doneform {
            width: auto;
            margin: 0;
            padding: 0;
            border: 0;
            box-shadow: none;
            background: transparent;
        }

        .doneform input[type="checkbox"] {
            width: 20px;
            height: 20px;
            margin: 0;
            accent-color: var(--accent);
            cursor: pointer;
        }

        .task_title {
            font-size: 1.05rem;
            line-height: 1.4;
        }

        .task-item p {
            width: auto;
            margin: 16px 0 0;
            padding: 0;
            color: var(--muted);
            font-size: 0.92rem;
        }

        .deleteBtn {
            padding: 9px 14px;
            background: linear-gradient(135deg, #ef4444, #b91c1c);
            box-shadow: 0 10px 24px rgba(220, 38, 38, 0.2);
        }

        .task-item:has(.doneform input[type="checkbox"]:checked) {
            opacity: 0.82;
            border-color: rgba(22, 163, 74, 0.22);
        }

        .task-item:has(.doneform input[type="checkbox"]:checked) .task_title {
            text-decoration: line-through;
            text-decoration-thickness: 2px;
            color: #5b6777;
        }

        @media (max-width: 640px) {
            body {
                padding: 22px 14px 40px;
            }

            h1,
            body > p:first-of-type,
            form[action="logout.php"] {
                padding-left: 18px;
                padding-right: 18px;
            }

            form,
            .task-item {
                padding: 18px;
                border-radius: 16px;
            }

            .task-item > div:first-child {
                align-items: flex-start;
            }
        }
    </style>
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