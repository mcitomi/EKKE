<?php
session_start();

function Bejelentkezve(): bool {
    return isset($_SESSION['u_id']);
}

function Admin(): bool {
    return isset($_SESSION['is_admin']) && $_SESSION['is_admin'] == 1;
}

function CheckLogged(): void {
    if(!Bejelentkezve()) {
        header("Location: login.php");
        exit;
    }
}

function CheckAdmin(): void {
    if(!Admin()) {
        header("Location: index.php");
        exit;
    }
}


?>