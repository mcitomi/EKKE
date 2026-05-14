<?php
    require_once("db.php");
    require_once("auth.php");

    CheckLogged();

    $bookId = (int) ($_POST["book_id"] ?? 0);

    if($bookId > 0) {
        $conn->begin_transaction();

        $query = $conn->prepare(
            "SELECT available FROM books WHERE id = ?"
        );

        $query->bind_param("i", $bookId);

        $query->execute();

        $bok = $query->get_result()->fetch_assoc();

        if($bok && $bok["available"] == 1) {
            $kolcsonzes = $conn->prepare(
                "INSERT INTO loans (user_id, book_id) VALUES (?,?)"
            );

            $kolcsonzes->bind_param("ii", $_SESSION["u_id"], $bookId);

            $kolcsonzes->execute();

            $frissites = $conn->prepare("UPDATE books SET available = 0 WHERE id = ?");

            $frissites->bind_param("i", $bookId);

            $frissites->execute();

        }

        $conn->commit();
    }

    header("Location: index.php");
    exit;
?>