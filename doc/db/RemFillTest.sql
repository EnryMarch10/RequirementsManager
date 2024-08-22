-- Ensure you're using the correct database
USE `ReM`;

INSERT INTO `USERS`
    (`username`, `name`, `surname`, `email`,
     `phone`, `company`, `isEditor`)
VALUES
    ('user_1', 'John', 'Doe', 'johndoe1@example.com', '555-0101', 'Company A', 'N'),
    ('user_2', 'Jane', 'Smith', 'janesmith2@example.com', '555-0102', 'Company B', 'Y'),
    ('user_3', 'Alice', 'Johnson', 'alicejohnson3@example.com', '555-0103', 'Company C', 'N'),
    ('user_4', 'Bob', 'Brown', 'bobbrown4@example.com', '555-0104', 'Company D', 'Y');

INSERT INTO `REQUESTS`
    (`title`, `description`, `type`, `UserIdCreation`,
     `UserIdEditing`, `timeEditing`)
VALUES
    ('Request 1', 'Fix critical bug', 'bug', 1, 1, NOW()),
    ('Request 2', 'Add new feature', 'functionality', 3, 3, NOW());

INSERT INTO `REQUIREMENTS`
    (`title`, `description`, `type`, `UserIdCreation`,
     `UserIdEditing`, `timeEditing`, `progressPercentage`,
     `estimatedHours`, `takenHours`, `RequestId`, `ParentRequirementId`)
VALUES
    ('Requirement 1', 'Functional requirement', 'functional', 2, 2, NOW(), 50, 20.0, 15.0, 1, NULL),
    ('Requirement 2', 'Non-functional requirement', 'non-functional', 4, 4, NOW(), 30, 10.0, 5.0, 2, NULL);
