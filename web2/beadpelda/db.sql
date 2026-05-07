CREATE DATABASE IF NOT EXISTS php_konyvtar
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

USE php_konyvtar;

CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    is_admin TINYINT(1) NOT NULL DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS books (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(150) NOT NULL,
    author VARCHAR(150) NOT NULL,
    publish_year INT NOT NULL,
    available TINYINT(1) NOT NULL DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY unique_book (title, author)
);

CREATE TABLE IF NOT EXISTS loans (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    book_id INT NOT NULL,
    loaned_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    returned_at TIMESTAMP NULL DEFAULT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (book_id) REFERENCES books(id) ON DELETE CASCADE
);

INSERT IGNORE INTO users (username, password, is_admin) VALUES
('admin', '$2y$10$0t9pWq4iK.qP525ZN6QG3u8XFDXG/lmLEGGzMaPT/aHGkkQB5HpWS', 1);

INSERT IGNORE INTO books (title, author, publish_year) VALUES
('Egri csillagok', 'Gárdonyi Géza', 1901),
('A Pál utcai fiúk', 'Molnár Ferenc', 1907),
('Abigél', 'Szabó Magda', 1970);

-- Alap admin: admin / admin
-- Admin jog adása más regisztrált felhasználónak:
-- UPDATE users SET is_admin = 1 WHERE username = "admin";