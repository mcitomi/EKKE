<?php
require_once("auth.php");
require_once("db.php");

CheckLogged();
CheckAdmin();

$editId = (int) $_GET["edit"] ?? 0;

$editBook = null;

if($editId > 0) {
    $lekerdezes = $conn->prepare("SELECT id, title, author, publish_year FROM books WHERE id = ?");
    $lekerdezes->bind_param("i", $editId);
    $lekerdezes->execute();
    $editBook = $lekerdezes->get_result()->fetch_assoc();
    

}

$lekerdezes = $conn->prepare("SELECT books.id, books.title, books.author, books.publish_year, books.available, user.username 
FROM books 
LEFT JOIN loans ON loans.book_id = books.id AND loans.returned_at IS NULL
LEFT JOIN users user ON loans.user_id = user.id 
ORDER BY books.id DESC");

$lekerdezes->execute();

$books = $lekerdezes->get_result();



?>
