CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(200),
    username VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    password VARCHAR(1000)
);