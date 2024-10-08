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
    `isEditor` ENUM('Y', 'N') NOT NULL DEFAULT 'N',
    PRIMARY KEY (`UserId`),
    CONSTRAINT `UNIQUE_USER_USERNAME`
        UNIQUE KEY `UniqueUsername` (`username`),
    CONSTRAINT `CHK_USER_USERNAME_NOT_EMPTY`
        CHECK (`username` <> ''
            AND `username` NOT LIKE ' %'
            AND `username` NOT LIKE '% '),
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
    `ReleaseId` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(50) NOT NULL,
    `description` VARCHAR(300) NOT NULL DEFAULT '',
    `timeCreation` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `nRequests` INT UNSIGNED NOT NULL DEFAULT 0,
    `nRequirements` INT UNSIGNED NOT NULL DEFAULT 0,
    `UserIdCreation` INT UNSIGNED NOT NULL,
    PRIMARY KEY (`ReleaseId`),
    CONSTRAINT `UNIQUE_RELEASE_NAME`
        UNIQUE KEY `UniqueName` (`name`),
    CONSTRAINT `CHK_RELEASE_NAME_NOT_EMPTY`
        CHECK (`name` <> ''
            AND `name` NOT LIKE ' %'
            AND `name` NOT LIKE '% ')
) ENGINE InnoDB;

CREATE TABLE `REQUESTS` (
    `RequestId` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `title` VARCHAR(50) NOT NULL,
    `description` VARCHAR(300) NOT NULL DEFAULT '',
    `body` MEDIUMBLOB,
    `type` ENUM('bug', 'functionality') NOT NULL,
    `isActive` ENUM('Y', 'N') NOT NULL DEFAULT 'Y',
    `UserIdCreation` INT UNSIGNED NOT NULL,
    `timeCreation` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `UserIdEditing` INT UNSIGNED NOT NULL,
    `timeEditing` DATETIME NOT NULL,
    `UserIdApproval` INT UNSIGNED,
    `timeApproval` DATETIME,
    PRIMARY KEY (`RequestId`),
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
    `isActive` ENUM('Y', 'N') NOT NULL DEFAULT 'Y',
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
    CONSTRAINT `CHK_REQUIREMENT_PERCENTAGE_VALID`
        CHECK (progressPercentage BETWEEN 0 AND 100),
    CONSTRAINT `CHK_REQUIREMENT_ESTIMATED_HOURS_POSITIVE`
        CHECK (`estimatedHours` >= 0),
    CONSTRAINT `CHK_REQUIREMENT_TAKEN_HOURS_POSITIVE`
        CHECK (`takenHours` >= 0),
    CONSTRAINT `CHK_REQUIREMENT_TITLE_NOT_EMPTY`
        CHECK (`title` <> ''
            AND `title` NOT LIKE ' %'
            AND `title` NOT LIKE '% ')
) ENGINE InnoDB;

-- NO checks on the following tables because they
-- should always be inserted programmatically and
-- not by the user

CREATE TABLE `HISTORIC_REQUESTS` (
    `RequestId` INT UNSIGNED NOT NULL,
    `RequestVersion` INT UNSIGNED NOT NULL,
    `title` VARCHAR(50) NOT NULL,
    `description` VARCHAR(300) NOT NULL,
    `body` MEDIUMBLOB,
    `type` ENUM('bug', 'functionality') NOT NULL,
    `isActive` ENUM('Y', 'N') NOT NULL,
    `UserIdEditing` INT UNSIGNED NOT NULL,
    `timeEditing` DATETIME NOT NULL,
    `UserIdApproval` INT UNSIGNED NOT NULL,
    `timeApproval` DATETIME NOT NULL,
    `ReleaseId` INT UNSIGNED NOT NULL,
    PRIMARY KEY (`RequestId`, `RequestVersion`)
) ENGINE InnoDB;

CREATE TABLE `HISTORIC_REQUIREMENTS` (
    `RequirementId` INT UNSIGNED NOT NULL,
    `RequirementVersion` INT UNSIGNED NOT NULL,
    `title` VARCHAR(50) NOT NULL,
    `description` VARCHAR(300) NOT NULL,
    `body` MEDIUMBLOB,
    `type` ENUM('functional', 'non-functional') NOT NULL,
    `isActive` ENUM('Y', 'N') NOT NULL,
    `UserIdEditing` INT UNSIGNED NOT NULL,
    `timeEditing` DATETIME NOT NULL,
    `estimatedHours` FLOAT NOT NULL,
    `takenHours` FLOAT NOT NULL,
    `RequestId` INT UNSIGNED NOT NULL,
    `RequestVersion` INT UNSIGNED NOT NULL,
    `ParentRequirementId` INT UNSIGNED,
    `ParentRequirementVersion` INT UNSIGNED,
    `ReleaseId` INT UNSIGNED NOT NULL,
    PRIMARY KEY (`RequirementId`, `RequirementVersion`)
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
        FOREIGN KEY (`ReleaseId`)
        REFERENCES `RELEASES` (`ReleaseId`)
            ON DELETE CASCADE,
    ADD CONSTRAINT `FK_ORIGINAL_REQUEST`
        FOREIGN KEY (`RequestId`)
        REFERENCES `REQUESTS` (`RequestId`),
    ADD CONSTRAINT `FK_HISTORIC_EDITING_REQUEST`
        FOREIGN KEY (`UserIdEditing`)
        REFERENCES `USERS` (`UserId`),
    ADD CONSTRAINT `FK_HISTORIC_APPROVAL_REQUEST`
        FOREIGN KEY (`UserIdApproval`)
        REFERENCES `USERS` (`UserId`);

ALTER TABLE `HISTORIC_REQUIREMENTS`
    ADD CONSTRAINT `FK_RELEASE_REQUIREMENTS`
        FOREIGN KEY (`ReleaseId`)
        REFERENCES `RELEASES` (`ReleaseId`)
            ON DELETE CASCADE,
    ADD CONSTRAINT `FK_ORIGINAL_REQUIREMENT`
        FOREIGN KEY (`RequirementId`)
        REFERENCES `REQUIREMENTS` (`RequirementId`),
    ADD CONSTRAINT `FK_HISTORIC_DEVELOPMENT`
        FOREIGN KEY (`RequestId`, `RequestVersion`)
        REFERENCES `HISTORIC_REQUESTS` (`RequestId`, `RequestVersion`)
            ON DELETE CASCADE,
    ADD CONSTRAINT `FK_HISTORIC_EDITING_REQUIREMENT`
        FOREIGN KEY (`UserIdEditing`)
        REFERENCES `USERS` (`UserId`),
    ADD CONSTRAINT `FK_HISTORIC_KINSHIP`
        FOREIGN KEY (`ParentRequirementId`, `ParentRequirementVersion`)
        REFERENCES `HISTORIC_REQUIREMENTS` (`RequirementId`, `RequirementVersion`)
            ON DELETE CASCADE;

-- Triggers Section
-- ________________

delimiter //

-- username validation
CREATE TRIGGER `TRG_BEFORE_INSERT_USER` BEFORE INSERT ON `USERS`
FOR EACH ROW
BEGIN
    -- USER username must match pattern
    IF NEW.`username` NOT REGEXP '^[a-zA-Z][a-zA-Z0-9._-]*$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'username invalid format, only accepted ^[a-zA-Z][a-zA-Z0-9._-]*$';
    END IF;
END;//

CREATE TRIGGER `TRG_BEFORE_UPDATE_USER` BEFORE UPDATE ON `USERS`
FOR EACH ROW
BEGIN
    -- USER role must remain the same once inserted
    IF OLD.`isEditor` <> NEW.`isEditor` THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'isEditor cannot be modified after initial insertion.';
    END IF;

    -- USER username must match pattern
    IF NEW.`username` NOT REGEXP '^[a-zA-Z][a-zA-Z0-9._-]*$' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'username invalid format, only accepted ^[a-zA-Z][a-zA-Z0-9._-]*$';
    END IF;
END;//

-- n REQUESTS
CREATE TRIGGER `TRG_AFTER_INSERT_HISTORIC_REQUEST` AFTER INSERT ON `HISTORIC_REQUESTS`
FOR EACH ROW
BEGIN
    -- Number of Requests automatically matches
    UPDATE `RELEASES`
    SET `nRequests` = `nRequests` + 1
    WHERE `ReleaseId` = NEW.`ReleaseId`;
END;//

-- CREATE TRIGGER `TRG_AFTER_DELETE_HISTORIC_REQUEST` AFTER DELETE ON `HISTORIC_REQUESTS`
-- FOR EACH ROW
-- BEGIN
--     -- Number of Requests automatically matches
--     UPDATE `RELEASES`
--     SET `nRequests` = `nRequests` - 1
--     WHERE `ReleaseId` = OLD.`ReleaseId`;
-- END;//

-- n REQUIREMENTS
CREATE TRIGGER `TRG_AFTER_INSERT_HISTORIC_REQUIREMENT` AFTER INSERT ON `HISTORIC_REQUIREMENTS`
FOR EACH ROW
BEGIN
    -- Number of Requirements automatically matches
    UPDATE `RELEASES`
    SET `nRequirements` = `nRequirements` + 1
    WHERE `ReleaseId` = NEW.`ReleaseId`;
END;//

-- CREATE TRIGGER `TRG_AFTER_DELETE_HISTORIC_REQUIREMENT` AFTER DELETE ON `HISTORIC_REQUIREMENTS`
-- FOR EACH ROW
-- BEGIN
--     -- Number of Requirements automatically matches
--     UPDATE `RELEASES`
--     SET `nRequirements` = `nRequirements` - 1
--     WHERE `ReleaseId` = OLD.`ReleaseId`;
-- END;//

CREATE TRIGGER `TRG_BEFORE_INSERT_REQUIREMENT` BEFORE INSERT ON `REQUIREMENTS`
FOR EACH ROW
BEGIN
    -- REQUIREMENTS assert user to create or update to be editor
    DECLARE userCreationIsEditor ENUM('Y', 'N');
    DECLARE userEditingIsEditor ENUM('Y', 'N');
    
    -- Check if UserIdCreation references an editor
    SELECT `isEditor` INTO userCreationIsEditor
    FROM `USERS`
    WHERE `UserId` = NEW.`UserIdCreation`;
    
    IF userCreationIsEditor <> 'Y' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'UserIdCreation must reference a user with isEditor = Y';
    END IF;
    
    -- Check if UserIdEditing references an editor
    SELECT `isEditor` INTO userEditingIsEditor
    FROM `USERS`
    WHERE `UserId` = NEW.`UserIdEditing`;
    
    IF userEditingIsEditor <> 'Y' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'UserIdEditing must reference a user with isEditor = Y';
    END IF;

    -- REQUIREMENTS PARENT avoid reflective reference
    IF NEW.`RequirementId` = NEW.`ParentRequirementId` THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'RequirementId illegal, a requirement cannot be its own parent.';
    END IF;
END;//

CREATE TRIGGER `TRG_BEFORE_UPDATE_REQUIREMENT` BEFORE UPDATE ON `REQUIREMENTS`
FOR EACH ROW
BEGIN
    -- EDITING USER must be an editor
    DECLARE userEditingIsEditor ENUM('Y', 'N');
    SELECT `isEditor` INTO userEditingIsEditor
    FROM `USERS`
    WHERE `UserId` = NEW.`UserIdEditing`;
    IF userEditingIsEditor <> 'Y' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'UserIdEditing must reference a user with isEditor = Y';
    END IF;

    -- CREATION USER and TIME cannot be updated
    IF OLD.`UserIdCreation` <> NEW.`UserIdCreation` THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'UserIdCreation cannot be modified after initial insertion.';
    END IF;
    IF OLD.`timeCreation` <> NEW.`timeCreation` THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'timeCreation cannot be modified after initial insertion.';
    END IF;

    -- REQUIREMENTS PARENT avoid reflective reference
    IF NEW.`RequirementId` = NEW.`ParentRequirementId` THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'RequirementId illegal, a requirement cannot be its own parent.';
    END IF;
END;//

CREATE TRIGGER `TRG_BEFORE_INSERT_REQUEST` BEFORE INSERT ON `REQUESTS`
FOR EACH ROW
BEGIN
    -- APPROVAL USER must be an editor
    DECLARE userIsEditor ENUM('Y', 'N');

    IF NEW.`UserIdApproval` IS NOT NULL THEN
        SELECT `isEditor` INTO userIsEditor
        FROM `USERS`
        WHERE `UserId` = NEW.`UserIdApproval`;
        
        IF userIsEditor <> 'Y' THEN
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'UserIdApproval must reference a user with isEditor = Y';
        END IF;
    END IF;
END;//

CREATE TRIGGER `TRG_BEFORE_UPDATE_REQUEST` BEFORE UPDATE ON `REQUESTS`
FOR EACH ROW
BEGIN
    -- APPROVAL USER must be an editor
    DECLARE userIsEditor ENUM('Y', 'N');

    IF NEW.`UserIdApproval` IS NOT NULL THEN
        SELECT `isEditor` INTO userIsEditor
        FROM `USERS`
        WHERE `UserId` = NEW.`UserIdApproval`;
        
        IF userIsEditor <> 'Y' THEN
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'UserIdApproval must reference a user with isEditor = Y';
        END IF;
    END IF;

    -- CREATION USER cannot be updated
    IF OLD.`UserIdCreation` <> NEW.`UserIdCreation` THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'UserIdCreation cannot be modified after initial insertion.';
    END IF;

    -- CREATION TIME cannot be updated
    IF OLD.`timeCreation` <> NEW.`timeCreation` THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'timeCreation cannot be modified after initial insertion.';
    END IF;
END;//

CREATE TRIGGER `TRG_BEFORE_INSERT_RELEASE` BEFORE INSERT ON `RELEASES`
FOR EACH ROW
BEGIN
    -- USER that creates a Release must be an editor
    DECLARE userCreationIsEditor ENUM('Y', 'N');
    
    SELECT `isEditor` INTO userCreationIsEditor
    FROM `USERS`
    WHERE `UserId` = NEW.`UserIdCreation`;
    
    IF userCreationIsEditor <> 'Y' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'UserIdCreation must reference a user with isEditor = Y';
    END IF;
END;//

CREATE TRIGGER `TRG_BEFORE_UPDATE_RELEASE` BEFORE UPDATE ON `RELEASES`
FOR EACH ROW
BEGIN
    -- CREATION USER cannot be updated
    IF OLD.`UserIdCreation` <> NEW.`UserIdCreation` THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'UserIdCreation cannot be modified after initial insertion.';
    END IF;

    -- CREATION TIME cannot be updated
    IF OLD.`timeCreation` <> NEW.`timeCreation` THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'timeCreation cannot be modified after initial insertion.';
    END IF;
END;//

delimiter ;
