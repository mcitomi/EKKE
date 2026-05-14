<?php
require_once("auth.php");
require_once("db.php");

CheckLogged();

if ($_SERVER["REQUEST_METHOD"] === "POST" && $_POST["action"] == "logout") {
    Logout();
}

$konyvQuery = $conn->prepare(
    "SELECT id, title, author, publish_year, available FROM books ORDER BY title ASC"
);

$konyvQuery->execute();

$books = $konyvQuery->get_result();

$kolcsonQuery = $conn->prepare(
    "SELECT loans.id, loans.loaned_at, books.title, books.author FROM loans 
    INNER JOIN books ON books.id = loans.book_id
    WHERE loans.user_id = ? AND loans.returned_at IS NULL
    ORDER BY loans.loaned_at DESC"
);

$kolcsonQuery->bind_param("i", $_SESSION["u_id"]);



?>

<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Könyvtár</title>
</head>

<body>
    <h1>Könyvtár</h1>

    <h3>Üdv <?= $_SESSION['username'] ?></h3>

    <?php if(Admin()): ?>
        <a href="admin.php">Admin panel</a>
    <?php endif;?>

    <form method="post" action="logout" class="m-0">
        <button type="submit" class="dropdown-item text-danger">Logout</button>
    </form>

    <h2>Könyvek</h2>

    <?php if($books->num_rows > 0): ?>
        <ul>
            <?php while($book = $books->fetch_assoc()): ?>
                <li>
                    <div>
                        <strong> <?= htmlspecialchars($book["title"]) ?> </strong>
                        <p><?= htmlspecialchars($book["author"]) ?></p>
                        <p><?= htmlspecialchars($book["publish_year"]) ?></p>
                    </div>

                    <?php if($book["available"]): ?>
                        <form action="borrow.php" method="post">
                            <input type="hidden" name="book_id" value="<?= $book["id"] ?>">
                            <button type="submit">Kölcsönzés</button>
                        </form>
                    <?php else: ?>
                        <p>Jelenleg nem elérhető</p>
                    <?php endif; ?>
                </li>
            <?php endwhile; ?>
        </ul>
    <?php else: ?>
        <p>Nincs megjeleníthető könyv</p>
    <?php endif; ?>
    
</body>

</html>