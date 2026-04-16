<?php
require_once("db.php");
require_once("auth.php");

csakBejelentekzve();

$taskId = (int)$_GET["id"] ?? 0;
$userId = $_SESSION["user_id"];
$newValue = isset($_POST["is_done"]) ? 1 : 0;

if($taskId > 0) {
    $lekerdezes = $conn->prepare(
        "UPDATE tasks SET is_done = ? WHERE id = ? AND user_id = ?"
    );
    $lekerdezes->bind_param("iii", $newValue, $taskId, $userId);
    $lekerdezes->execute();
}

header("Location: index.php");
exit;   

?>
