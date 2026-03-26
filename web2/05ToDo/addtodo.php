<?php
require_once("db.php");
require_once("auth.php");

csakBejelentekzve();

if ($task !== "") {
    $task = $_POST["task"] ?? "";
    $category = $_POST["category"] ?? "";
    $priority = $_POST["priority"] ?? "";

    $user_id = $_SESSION["user_id"];

    $lekerdezes = $conn->prepare("INSERT INTO tasks (user_id, task, category, priority) VALUES (?,?,?,?)");
    $lekerdezes->bind_param("isss", $user_id, $task, $category, $priority);
    $lekerdezes->execute();
}

header("Location: index.php");
exit;
?>
