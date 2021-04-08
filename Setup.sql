USE castleapi;

-- CREATE TABLE castles
-- (
--     id INT AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL, 
--     king VARCHAR(255) NOT NULL,
--     villagers INT NOT NULL,
--     armysize INT NOT NULL,

--     PRIMARY KEY (id)
-- );


-- CREATE TABLE knights
-- (
--     id INT AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     height INT NOT NULL,
--     age INT NOT NULL,
--     gender VARCHAR(255) NOT NULL,
--     castleId INT NOT NULL,


--     PRIMARY KEY (id),

--     FOREIGN KEY (castleId)
--     REFERENCES castles (id)
--     ON DELETE CASCADE
-- );

CREATE TABLE wifes
(
    id INT AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    age INT NOT NULL,
    skills VARCHAR(255) NOT NULL,
    knightId INT NOT NULL,

    PRIMARY KEY (id),

    FOREIGN KEY (knightId)
    REFERENCES knights (id)
    ON DELETE CASCADE
)