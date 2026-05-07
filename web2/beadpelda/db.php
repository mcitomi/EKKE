<?php
$conn = new mysqli("127.0.0.1", "root", "root", "php_konyvtar");

if($conn->connect_error){
    die("Kapcsolódási hiba");
} else {
    
    $conn->set_charset("utf8mb4");

}
?>