DROP TABLE IF EXISTS games CASCADE;

CREATE TYPE user_role AS enum(
    'GAMER',
    'PUBLISHER'
);

CREATE TYPE game_genre AS enum(
    'RPG',
    'Action',
    'Strategy'
);

CREATE TABLE user_info (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    username VARCHAR(255) NOT NULL,
    email varchar(255) NOT NULL,
    password varchar(255) NOT NULL,
    role user_role NOT NULL DEFAULT 'GAMER',
    CONSTRAINT unique_username UNIQUE (username),
    CONSTRAINT unique_email UNIQUE (email)
);

CREATE TABLE publisher (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    name varchar(255) NOT NULL,
    email varchar(255) NOT NULL,
    user_id BIGINT NOT NULL,
    CONSTRAINT publisher_user_fk FOREIGN key (user_id) REFERENCES user_info (id)
);

CREATE TABLE game (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    name VARCHAR(255) NOT NULL,
    price NUMERIC(8, 2) NOT NULL,
    genre game_genre NOT NULL,
    publisher_id BIGINT NOT NULL,
    release_date DATE NOT NULL DEFAULT NOW(),
    CONSTRAINT publisher_game_fk FOREIGN key (
        publisher_id
    ) REFERENCES publisher (id)
);

CREATE TABLE purchase (
    id BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    game_id BIGINT NOT NULL,
    user_id BIGINT NOT NULL,
    purchase_date TIMESTAMPtz NOT NULL DEFAULT NOW(),
    CONSTRAINT payment_user_fk FOREIGN key (user_id) REFERENCES user_info (id),
    CONSTRAINT payment_game_fk FOREIGN key (game_id) REFERENCES game (id),
    CONSTRAINT unique_game_user UNIQUE (
        game_id,
        user_id
    )
);
