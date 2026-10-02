CREATE DATABASE IF NOT EXISTS lerntracker
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE lerntracker;

CREATE TABLE IF NOT EXISTS Aufgaben
(
    Id INT NOT NULL AUTO_INCREMENT,
    Titel VARCHAR(200) NOT NULL,
    Beschreibung TEXT NULL,
    Status TINYINT UNSIGNED NOT NULL DEFAULT 0,

    CONSTRAINT PK_Aufgaben PRIMARY KEY (Id),
    CONSTRAINT CK_Aufgaben_Status
        CHECK (Status IN (0, 1, 2))
);

-- Erstelle den eingeschränkten App-Benutzer entsprechend Lektion 16.04.
-- Speichere hier kein echtes Passwort.
