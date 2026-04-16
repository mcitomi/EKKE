<?php
require_once("db.php");
require_once("auth.php");

csakBejelentekzve();

$userId = $_SESSION["user_id"];
$taskId = (int)$_GET["id"] ?? 0;

if($taskId > 0) {
    $lekerdezes = $conn->prepare("DELETE FROM tasks WHERE id = ? AND user_id = ?");
    $lekerdezes->bind_param("ii", $taskId, $userId);
    $lekerdezes->execute();
}

header("Location: index.php");
exit;


?>