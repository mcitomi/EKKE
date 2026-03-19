<?php
$conn = new mysqli(
    hostname:"localhost", 
    username: "root",
    password: "root",
    database: "php_auth_web2"
);

if($conn->connect_error) {
    die("Kapcsolódási hiba");
}

$conn -> set_charset("utf8mb4");


?>