-- *********************************************
-- * SQL MySQL generation
-- *--------------------------------------------
-- * DB-MAIN version: 11.0.2
-- * Generator date: Sep 14 2021
-- * Generation date: Sat Aug 17 16:35:58 2024
-- * LUN file: ./doc/db/ReM.lun
-- * Schema: Logic/1
-- *********************************************


-- Database Section
-- ________________

DROP DATABASE IF EXISTS `ReM`;
CREATE DATABASE `ReM` DEFAULT CHARACTER SET `utf8mb4` COLLATE `utf8mb4_bin`;
USE `ReM`;

-- Tables Section
-- ______________

CREATE TABLE `USERS` (
     `UserId` INT UNSIGNED NOT NULL AUTO_INCREMENT,
     `username` VARCHAR(50) NOT NULL,
     `name` VARCHAR(30) NOT NULL,
     `surname` VARCHAR(30) NOT NULL,
     `email` VARCHAR(50) NOT NULL,
     `phone` VARCHAR(20) NOT NULL,
     `company` VARCHAR(30),
     `isEditor` CHAR(1) NOT NULL DEFAULT 'N',
     PRIMARY KEY (`UserId`),
     CHECK (`isEditor` IN ('Y', 'N')),
     CONSTRAINT `UNIQUE_USER_USERNAME`
          UNIQUE KEY `UniqueUsername` (`username`),
     CONSTRAINT `UNIQUE_USER_EMAIL`
          UNIQUE KEY `UniqueEmail` (`email`),
     CONSTRAINT `CHK_USER_EMAIL_NOT_EMPTY`
          CHECK (`email` <> ''
               AND `email` NOT LIKE ' %'
               AND `email` NOT LIKE '% '),
     CONSTRAINT `CHK_USER_NAME_NOT_EMPTY`
          CHECK (`name` <> ''
               AND `name` NOT LIKE ' %'
               AND `name` NOT LIKE '% '),
     CONSTRAINT `CHK_USER_SURNAME_NOT_EMPTY`
          CHECK (`surname` <> ''
               AND `surname` NOT LIKE ' %'
               AND `surname` NOT LIKE '% ')
) ENGINE InnoDB;

CREATE TABLE `RELEASES` (
     `ReleaseName` VARCHAR(50) NOT NULL,
     `description` VARCHAR(300) NOT NULL DEFAULT '',
     `timeCreation` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
     `nRequests` INT UNSIGNED NOT NULL DEFAULT 0,
     `nRequirements` INT UNSIGNED NOT NULL DEFAULT 0,
     `UserIdCreation` INT UNSIGNED NOT NULL,
     PRIMARY KEY (`ReleaseName`),
     CONSTRAINT `CHK_RELEASE_NAME_NOT_EMPTY`
          CHECK (`ReleaseName` <> ''
               AND `ReleaseName` NOT LIKE ' %'
               AND `ReleaseName` NOT LIKE '% ')
) ENGINE InnoDB;

CREATE TABLE `REQUESTS` (
     `RequestId` INT UNSIGNED NOT NULL AUTO_INCREMENT,
     `title` VARCHAR(50) NOT NULL,
     `description` VARCHAR(300) NOT NULL DEFAULT '',
     `body` MEDIUMBLOB,
     `type` ENUM('bug', 'functionality') NOT NULL,
     `isActive` CHAR(1) NOT NULL DEFAULT 'Y',
     `UserIdCreation` INT UNSIGNED NOT NULL,
     `timeCreation` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
     `UserIdEditing` INT UNSIGNED NOT NULL,
     `timeEditing` DATETIME NOT NULL,
     `UserIdApproval` INT UNSIGNED,
     `timeApproval` DATETIME,
     PRIMARY KEY (`RequestId`),
     CONSTRAINT `CHK_REQUEST_IS_ACTIVE_VALID`
          CHECK (`isActive` IN ('Y', 'N')),
     CONSTRAINT `CHK_REQUEST_APPROVAL_LEGAL`
          CHECK((`UserIdApproval` IS NOT NULL AND `timeApproval` IS NOT NULL)
               OR (`UserIdApproval` IS NULL AND `timeApproval` IS NULL)),
     CONSTRAINT `CHK_REQUEST_TITLE_NOT_EMPTY`
          CHECK (`title` <> ''
               AND `title` NOT LIKE ' %'
               AND `title` NOT LIKE '% ')
) ENGINE InnoDB;

CREATE TABLE `REQUIREMENTS` (
     `RequirementId` INT UNSIGNED NOT NULL AUTO_INCREMENT,
     `title` VARCHAR(50) NOT NULL,
     `description` VARCHAR(300) NOT NULL DEFAULT '',
     `body` MEDIUMBLOB,
     `type` ENUM('functional', 'non-functional') NOT NULL,
     `isActive` CHAR(1) NOT NULL DEFAULT 'Y',
     `UserIdCreation` INT UNSIGNED NOT NULL,
     `timeCreation` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
     `UserIdEditing` INT UNSIGNED NOT NULL,
     `timeEditing` DATETIME NOT NULL,
     `progressPercentage` INT UNSIGNED NOT NULL DEFAULT 0,
     `estimatedHours` FLOAT NOT NULL DEFAULT 0.0,
     `takenHours` FLOAT NOT NULL DEFAULT 0.0,
     `RequestId` INT UNSIGNED NOT NULL,
     `ParentRequirementId` INT UNSIGNED,
     PRIMARY KEY (`RequirementId`),
     CONSTRAINT `CHK_REQUIREMENT_IS_ACTIVE_VALID`
          CHECK (`isActive` IN ('Y', 'N')),
     CONSTRAINT `CHK_REQUIREMENT_ESTIMATED_HOURS_POSITIVE`
          CHECK (`estimatedHours` >= 0),
     CONSTRAINT `CHK_REQUIREMENT_TAKEN_HOURS_POSITIVE`
          CHECK (`takenHours` >= 0),
     CONSTRAINT `CHK_REQUIREMENT_TITLE_NOT_EMPTY`
          CHECK (`title` <> ''
               AND `title` NOT LIKE ' %'
               AND `title` NOT LIKE '% ')
) ENGINE InnoDB;

CREATE TABLE `HISTORIC_REQUESTS` (
     `RequestId` INT UNSIGNED NOT NULL,
     `RequestVersion` INT UNSIGNED NOT NULL,
     `title` VARCHAR(50) NOT NULL,
     `description` VARCHAR(300) NOT NULL DEFAULT '',
     `body` MEDIUMBLOB,
     `type` ENUM('bug', 'functionality') NOT NULL,
     `isActive` CHAR(1) NOT NULL DEFAULT 'N',
     `UserIdEditing` INT UNSIGNED NOT NULL,
     `timeEditing` DATETIME NOT NULL,
     `timeApproval` DATETIME NOT NULL,
     `ReleaseName` VARCHAR(50) NOT NULL,
     PRIMARY KEY (`RequestId`, `RequestVersion`),
     CONSTRAINT `CHK_H_REQUEST_IS_ACTIVE_VALID`
          CHECK (`isActive` IN ('Y', 'N')),
     CONSTRAINT `CHK_H_REQUEST_TITLE_NOT_EMPTY`
          CHECK (`title` <> ''
               AND `title` NOT LIKE ' %'
               AND `title` NOT LIKE '% ')
) ENGINE InnoDB;

CREATE TABLE `HISTORIC_REQUIREMENTS` (
     `RequirementId` INT UNSIGNED NOT NULL,
     `RequirementVersion` INT UNSIGNED NOT NULL,
     `title` VARCHAR(50) NOT NULL,
     `description` VARCHAR(300) NOT NULL DEFAULT '',
     `body` MEDIUMBLOB,
     `type` ENUM('functional', 'non-functional') NOT NULL,
     `isActive` CHAR(1) NOT NULL DEFAULT 'N',
     `UserIdEditing` INT UNSIGNED NOT NULL,
     `timeEditing` DATETIME NOT NULL,
     `estimatedHours` FLOAT NOT NULL DEFAULT 0.0,
     `takenHours` FLOAT NOT NULL DEFAULT 0.0,
     `RequestId` INT UNSIGNED NOT NULL,
     `RequestVersion` INT UNSIGNED NOT NULL,
     `ParentRequirementId` INT UNSIGNED,
     `ParentRequirementVersion` INT UNSIGNED,
     `ReleaseName` VARCHAR(50) NOT NULL,
     PRIMARY KEY (`RequirementId`, `RequirementVersion`),
     CONSTRAINT `CHK_H_REQUIREMENT_IS_ACTIVE_VALID`
          CHECK (`isActive` IN ('Y', 'N')),
     CONSTRAINT `CHK_H_REQUIREMENT_KINSHIP_LEGAL`
          CHECK((`ParentRequirementId` IS NOT NULL AND `ParentRequirementVersion` IS NOT NULL)
               OR (`ParentRequirementId` IS NULL AND `ParentRequirementVersion` IS NULL)),
     CONSTRAINT `CHK_H_REQUIREMENT_ESTIMATED_HOURS_POSITIVE`
          CHECK (`estimatedHours` >= 0),
     CONSTRAINT `CHK_H_REQUIREMENT_TAKEN_HOURS_POSITIVE`
          CHECK (`takenHours` >= 0),
     CONSTRAINT `CHK_H_REQUIREMENT_TITLE_NOT_EMPTY`
          CHECK (`title` <> ''
               AND `title` NOT LIKE ' %'
               AND `title` NOT LIKE '% ')
) ENGINE InnoDB;

-- Constraints Section
-- ___________________

ALTER TABLE `RELEASES`
     ADD CONSTRAINT `FK_CREATION_RELEASE`
          FOREIGN KEY (`UserIdCreation`)
          REFERENCES `USERS` (`UserId`);

ALTER TABLE `REQUESTS`
     ADD CONSTRAINT `FK_CREATION_REQUEST`
          FOREIGN KEY (`UserIdCreation`)
          REFERENCES `USERS` (`UserId`),
     ADD CONSTRAINT `FK_EDITING_REQUEST`
          FOREIGN KEY (`UserIdEditing`)
          REFERENCES `USERS` (`UserId`),
     ADD CONSTRAINT `FK_APPROVAL_REQUEST`
          FOREIGN KEY (`UserIdApproval`)
          REFERENCES `USERS` (`UserId`);

ALTER TABLE `REQUIREMENTS`
     ADD CONSTRAINT `FK_CREATION_REQUIREMENT`
          FOREIGN KEY (`UserIdCreation`)
          REFERENCES `USERS` (`UserId`),
     ADD CONSTRAINT `FK_EDITING_REQUIREMENT`
          FOREIGN KEY (`UserIdEditing`)
          REFERENCES `USERS` (`UserId`),
     ADD CONSTRAINT `FK_DEVELOPMENT`
          FOREIGN KEY (`RequestId`)
          REFERENCES `REQUESTS` (`RequestId`),
     ADD CONSTRAINT `FK_KINSHIP`
          FOREIGN KEY (`ParentRequirementId`)
          REFERENCES `REQUIREMENTS` (`RequirementId`);

ALTER TABLE `HISTORIC_REQUESTS`
     ADD CONSTRAINT `FK_RELEASE_REQUESTS`
          FOREIGN KEY (`ReleaseName`)
          REFERENCES `RELEASES` (`ReleaseName`),
     ADD CONSTRAINT `FK_ORIGINAL_REQUEST`
          FOREIGN KEY (`RequestId`)
          REFERENCES `REQUESTS` (`RequestId`),
     ADD CONSTRAINT `FK_HISTORIC_EDITING_REQUEST`
          FOREIGN KEY (`UserIdEditing`)
          REFERENCES `USERS` (`UserId`);

ALTER TABLE `HISTORIC_REQUIREMENTS`
     ADD CONSTRAINT `FK_RELEASE_REQUIREMENTS`
          FOREIGN KEY (`ReleaseName`)
          REFERENCES `RELEASES` (`ReleaseName`),
     ADD CONSTRAINT `FK_ORIGINAL_REQUIREMENT`
          FOREIGN KEY (`RequirementId`)
          REFERENCES `REQUIREMENTS` (`RequirementId`),
     ADD CONSTRAINT `FK_HISTORIC_DEVELOPMENT`
          FOREIGN KEY (`RequestId`, `RequestVersion`)
          REFERENCES `HISTORIC_REQUESTS` (`RequestId`, `RequestVersion`),
     ADD CONSTRAINT `FK_HISTORIC_EDITING_REQUIREMENT`
          FOREIGN KEY (`UserIdEditing`)
          REFERENCES `USERS` (`UserId`),
     ADD CONSTRAINT `FK_HISTORIC_KINSHIP`
          FOREIGN KEY (`ParentRequirementId`, `ParentRequirementVersion`)
          REFERENCES `HISTORIC_REQUIREMENTS` (`RequirementId`, `RequirementVersion`);

-- Triggers Section
-- ________________

delimiter //

-- username validation
CREATE TRIGGER `TRG_VALIDATE_USER_USERNAME_BEFORE_INSERT` BEFORE INSERT ON `USERS`
FOR EACH ROW
BEGIN
    IF NEW.`username` NOT REGEXP '^[a-zA-Z][a-zA-Z0-9._-]*$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Invalid `USERS`.`username` format, only accepted ^[a-zA-Z][a-zA-Z0-9._-]*$';
    END IF;
END;//

CREATE TRIGGER `TRG_VALIDATE_USER_USERNAME_BEFORE_UPDATE` BEFORE UPDATE ON `USERS`
FOR EACH ROW
BEGIN
    IF NEW.`username` NOT REGEXP '^[a-zA-Z][a-zA-Z0-9._-]*$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Invalid `USERS`.`username` format, only accepted ^[a-zA-Z][a-zA-Z0-9._-]*$';
    END IF;
END;//

-- n REQUESTS
CREATE TRIGGER `TRG_INCREASE_RELEASE_REQUESTS_COUNTER` AFTER INSERT ON `HISTORIC_REQUESTS`
FOR EACH ROW
BEGIN
    UPDATE `RELEASES`
    SET `nRequests` = `nRequests` + 1
    WHERE `ReleaseName` = NEW.`ReleaseName`;
END;//

CREATE TRIGGER `TRG_DECREASE_RELEASE_REQUESTS_COUNTER` AFTER DELETE ON `HISTORIC_REQUESTS`
FOR EACH ROW
BEGIN
    UPDATE `RELEASES`
    SET `nRequests` = `nRequests` - 1
    WHERE `ReleaseName` = OLD.`ReleaseName`;
END;//

-- n REQUIREMENTS
CREATE TRIGGER `TRG_INCREASE_RELEASE_REQUIREMENTS_COUNTER` AFTER INSERT ON `HISTORIC_REQUIREMENTS`
FOR EACH ROW
BEGIN
    UPDATE `RELEASES`
    SET `nRequirements` = `nRequirements` + 1
    WHERE `ReleaseName` = NEW.`ReleaseName`;
END;//

CREATE TRIGGER `TRG_DECREASE_RELEASE_REQUIREMENTS_COUNTER` AFTER DELETE ON `HISTORIC_REQUIREMENTS`
FOR EACH ROW
BEGIN
    UPDATE `RELEASES`
    SET `nRequirements` = `nRequirements` - 1
    WHERE `ReleaseName` = OLD.`ReleaseName`;
END;//

-- REQUIREMENTS parent avoid recursive reference
CREATE TRIGGER `TRG_BEFORE_REQUIREMENT_INSERT`
BEFORE INSERT ON REQUIREMENTS
FOR EACH ROW
BEGIN
    IF NEW.`RequirementId` = NEW.`ParentRequirementId` THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: A requirement cannot be its own parent.';
    END IF;
END;//

CREATE TRIGGER `TRG_BEFORE_REQUIREMENT_UPDATE`
BEFORE UPDATE ON REQUIREMENTS
FOR EACH ROW
BEGIN
    IF NEW.`RequirementId` = NEW.`ParentRequirementId` THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: A requirement cannot be its own parent.';
    END IF;
END;//

delimiter ;
