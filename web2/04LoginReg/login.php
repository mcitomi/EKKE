<h1>Bejelentkezés</h1>
<form method="post">
    <label>Felhaszálónev: <input type="text" name="username"></label>
    <label>Jelszo: <input type="password" name="password"></label>
    <button type="submit">Betejecskézés</button>
</form>
<p style="color: red"><?= $hiba ?></p>
<a href="register.php">Regisztrácio</a>