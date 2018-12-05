-- MySQL Script generated by MySQL Workbench
-- Tue Dec  4 20:19:35 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema bookstore
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema bookstore
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bookstore` DEFAULT CHARACTER SET utf8 COLLATE utf8_lithuanian_ci ;
USE `bookstore` ;

-- -----------------------------------------------------
-- Table `bookstore`.`clients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`clients` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `access_flag` TINYINT(2) UNSIGNED NOT NULL,
  `authorization_key` VARCHAR(255) NULL DEFAULT NULL,
  `username` CHAR(21) NOT NULL,
  `password` CHAR(64) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `updated_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;


-- -----------------------------------------------------
-- Table `bookstore`.`phone_numbers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`phone_numbers` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `client_id` INT(11) NOT NULL,
  `number` VARCHAR(64) NOT NULL,
  `label` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_phone_numbers_clients1`
    FOREIGN KEY (`client_id`)
    REFERENCES `bookstore`.`clients` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_phone_numbers_clients1_idx` ON `bookstore`.`phone_numbers` (`client_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`countries`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`countries` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `iso` CHAR(2) NOT NULL,
  `name` VARCHAR(80) NOT NULL,
  `nicename` VARCHAR(80) NOT NULL,
  `iso3` CHAR(3) NULL DEFAULT NULL,
  `numcode` SMALLINT(6) NULL DEFAULT NULL,
  `phonecode` INT(5) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 240
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;


-- -----------------------------------------------------
-- Table `bookstore`.`addresses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`addresses` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `client_id` INT(11) NOT NULL,
  `phone_id` INT(11) NOT NULL,
  `country_id` INT(11) NOT NULL,
  `label` VARCHAR(255) NOT NULL,
  `address` VARCHAR(255) NOT NULL,
  `city` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_addresses_phone_numbers1`
    FOREIGN KEY (`phone_id`)
    REFERENCES `bookstore`.`phone_numbers` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_addresses_clients1`
    FOREIGN KEY (`client_id`)
    REFERENCES `bookstore`.`clients` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_addresses_countries1`
    FOREIGN KEY (`country_id`)
    REFERENCES `bookstore`.`countries` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_addresses_phone_numbers1_idx` ON `bookstore`.`addresses` (`phone_id` ASC);

CREATE INDEX `fk_addresses_clients1_idx` ON `bookstore`.`addresses` (`client_id` ASC);

CREATE INDEX `fk_addresses_countries1_idx` ON `bookstore`.`addresses` (`country_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`authors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`authors` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `surname` VARCHAR(255) NOT NULL,
  `birth_date` DATE NULL DEFAULT NULL,
  `death_date` DATE NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;


-- -----------------------------------------------------
-- Table `bookstore`.`categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`categories` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `label` VARCHAR(255) NOT NULL,
  `parent_id` INT(11) NULL DEFAULT NULL,
  `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;


-- -----------------------------------------------------
-- Table `bookstore`.`books`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`books` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `category_id` INT(11) NOT NULL,
  `title` VARCHAR(255) NOT NULL,
  `cover_url` VARCHAR(255) NULL DEFAULT NULL,
  `price` DECIMAL(9,2) NOT NULL,
  `description` TEXT NOT NULL,
  `language` CHAR(3) NULL DEFAULT 'LT',
  `edition` VARCHAR(255) NULL DEFAULT NULL,
  `isbn` INT(11) NULL DEFAULT NULL,
  `isbn13` INT(16) NULL DEFAULT NULL,
  `pages` INT(11) NOT NULL,
  `updated_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_books_categories1`
    FOREIGN KEY (`category_id`)
    REFERENCES `bookstore`.`categories` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_books_categories1_idx` ON `bookstore`.`books` (`category_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`book_authors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`book_authors` (
  `author_id` INT(11) NOT NULL,
  `book_id` INT(11) NOT NULL,
  PRIMARY KEY (`author_id`, `book_id`),
  CONSTRAINT `fk_author_book`
    FOREIGN KEY (`book_id`)
    REFERENCES `bookstore`.`books` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_book_author`
    FOREIGN KEY (`author_id`)
    REFERENCES `bookstore`.`authors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_author_book` ON `bookstore`.`book_authors` (`book_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`cases`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`cases` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `client_id` INT(11) NOT NULL,
  `support_id` INT(11) NOT NULL,
  `status` TINYINT(3) NOT NULL,
  `updated_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_cases_clients1`
    FOREIGN KEY (`client_id`)
    REFERENCES `bookstore`.`clients` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_cases_clients2`
    FOREIGN KEY (`support_id`)
    REFERENCES `bookstore`.`clients` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_cases_clients1_idx` ON `bookstore`.`cases` (`client_id` ASC);

CREATE INDEX `fk_cases_clients2_idx` ON `bookstore`.`cases` (`support_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`case_message`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`case_message` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `case_id` INT(11) NOT NULL,
  `contents` TEXT NULL DEFAULT NULL,
  `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_case_message_cases`
    FOREIGN KEY (`case_id`)
    REFERENCES `bookstore`.`cases` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_case_message_cases_idx` ON `bookstore`.`case_message` (`case_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`case_attachment`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`case_attachment` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `case_message_id` INT(11) NOT NULL,
  `attachment_url` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_case_attachment_case_message1`
    FOREIGN KEY (`case_message_id`)
    REFERENCES `bookstore`.`case_message` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_case_attachment_case_message1_idx` ON `bookstore`.`case_attachment` (`case_message_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`orders` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `client_id` INT(11) NOT NULL,
  `address_id` INT(11) NOT NULL,
  `status` TINYINT(3) NOT NULL,
  `updated_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `created_at` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_orders_clients1`
    FOREIGN KEY (`client_id`)
    REFERENCES `bookstore`.`clients` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_orders_addresses1`
    FOREIGN KEY (`address_id`)
    REFERENCES `bookstore`.`addresses` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_lithuanian_ci;

CREATE INDEX `fk_orders_clients1_idx` ON `bookstore`.`orders` (`client_id` ASC);

CREATE INDEX `fk_orders_addresses1_idx` ON `bookstore`.`orders` (`address_id` ASC);


-- -----------------------------------------------------
-- Table `bookstore`.`profiles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bookstore`.`profiles` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `client_id` INT(11) NOT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  `surname` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_profile_clients1`
    FOREIGN KEY (`client_id`)
    REFERENCES `bookstore`.`clients` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `fk_profile_clients1_idx` ON `bookstore`.`profiles` (`client_id` ASC);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
