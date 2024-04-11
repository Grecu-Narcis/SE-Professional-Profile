USE professional_profile
GO

-- QUERIES FOR USERS

CREATE TABLE Users (
  UserId INT PRIMARY KEY IDENTITY,  -- Auto-incrementing ID as primary key
  FirstName NVARCHAR(50) NOT NULL,
  LastName NVARCHAR(50) NOT NULL,
  Email NVARCHAR(100) UNIQUE NOT NULL,  -- Unique email for user identification
  Password NVARCHAR(MAX) NOT NULL,  -- Store password securely (hashed)
  Phone NVARCHAR(20),
  Summary NVARCHAR(MAX),
  DateOfBirth DATE,
  DarkTheme BIT,
  Address NVARCHAR(MAX),
  WebsiteURL NVARCHAR(MAX)
);

ALTER TABLE Users ADD Picture NVARCHAR(MAX);

CREATE OR ALTER PROCEDURE DeleteUser @UserId INT
AS
  DELETE FROM Users WHERE UserId = @UserId;

CREATE OR ALTER PROCEDURE TruncateUsers
AS
	TRUNCATE TABLE Users;

CREATE OR ALTER PROCEDURE InsertUser
  @FirstName NVARCHAR(50),
  @LastName NVARCHAR(50),
  @Email NVARCHAR(100),
  @Password NVARCHAR(MAX),
  @Phone NVARCHAR(20),
  @Summary NVARCHAR(MAX),
  @DateOfBirth DATE,
  @DarkTheme BIT,
  @Address NVARCHAR(MAX),
  @WebsiteURL NVARCHAR(MAX),
  @Picture NVARCHAR(MAX)
AS
  INSERT INTO Users (FirstName, LastName, Email, Password, Phone, Summary, DateOfBirth, DarkTheme, Address, WebsiteURL, Picture)
  VALUES (@FirstName, @LastName, @Email, @Password, @Phone, @Summary, @DateOfBirth, @DarkTheme, @Address, @WebsiteURL, @Picture);

CREATE OR ALTER PROCEDURE UpdateUser 
  @UserId INT,
  @FirstName NVARCHAR(50),
  @LastName NVARCHAR(50),
  @Email NVARCHAR(100),  -- Consider allowing update only if new email doesn't conflict
  @Password NVARCHAR(MAX),
  @Phone NVARCHAR(20),
  @Summary NVARCHAR(MAX),
  @DateOfBirth DATE,
  @DarkTheme BIT,
  @Address NVARCHAR(MAX),
  @WebsiteURL NVARCHAR(MAX),
  @Picture NVARCHAR(MAX)
AS
  UPDATE Users
  SET FirstName = @FirstName,
      LastName = @LastName,
      Email = @Email,  -- Update with caution (check for existing email)
      Password = @Password,
      Phone = @Phone,
      Summary = @Summary,
      DateOfBirth = @DateOfBirth,
      DarkTheme = @DarkTheme,
      Address = @Address,
      WebsiteURL = @WebsiteURL,
	  Picture = @Picture
  WHERE UserId = @UserId;

CREATE PROCEDURE GetUserById 
  @UserId INT

AS
  SELECT * FROM Users WHERE UserId = @UserId;

CREATE PROCEDURE GetAllUsers
AS
  SELECT * FROM Users;

 -- QUERIES FOR CERTIFICATIONS
 CREATE OR ALTER TABLE Certificates (
  CertificateId INT PRIMARY KEY IDENTITY,  -- Auto-incrementing ID as primary key
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table with cascade delete
  Name NVARCHAR(100) NOT NULL,
  Description NVARCHAR(MAX),
  IssuedBy NVARCHAR(100),
  IssuedDate DATE,
  ExpirationDate DATE
);

CREATE OR ALTER PROCEDURE GetCertificateById 
  @CertificateId INT
AS
  SELECT * FROM Certificates WHERE CertificateId = @CertificateId;

CREATE OR ALTER PROCEDURE GetAllCertificates
AS
  SELECT * FROM Certificates;

CREATE OR ALTER PROCEDURE InsertCertificate 
  @UserId INT,  -- Foreign key to Users table
  @Name NVARCHAR(100),
  @Description NVARCHAR(MAX),
  @IssuedBy NVARCHAR(100),
  @IssuedDate DATE,
  @ExpirationDate DATE
AS
  INSERT INTO Certificates (UserId, Name, Description, IssuedBy, IssuedDate, ExpirationDate)
  VALUES (@UserId, @Name, @Description, @IssuedBy, @IssuedDate, @ExpirationDate);

CREATE OR ALTER PROCEDURE UpdateCertificate 
  @CertificateId INT,
  @UserId INT,  -- Foreign key to Users table
  @Name NVARCHAR(100),
  @Description NVARCHAR(MAX),
  @IssuedBy NVARCHAR(100),
  @IssuedDate DATE,
  @ExpirationDate DATE
AS
  UPDATE Certificates
  SET UserId = @UserId,
      Name = @Name,
      Description = @Description,
      IssuedBy = @IssuedBy,
      IssuedDate = @IssuedDate,
      ExpirationDate = @ExpirationDate
  WHERE CertificateId = @CertificateId;

CREATE OR ALTER PROCEDURE DeleteCertificate @CertificateId INT
AS
  DELETE FROM Certificates WHERE CertificateId = @CertificateId;

CREATE OR ALTER PROCEDURE TruncateCertificates
AS
  TRUNCATE TABLE Certificates;  

  -- QUERIES FOR EDUCATION

CREATE TABLE Education (
  EducationId INT PRIMARY KEY IDENTITY,
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (cascade delete)
  Degree NVARCHAR(50) NOT NULL,
  Institution NVARCHAR(100) NOT NULL,
  FieldOfStudy NVARCHAR(100),
  GraduationDate DATE,
  GPA DECIMAL(5, 2),  -- Stores GPA with two decimal places
  CONSTRAINT Check_GPA CHECK (GPA >= 0.0 AND GPA <= 4.0)  -- Enforce GPA range between 0.0 and 4.0
);

CREATE OR ALTER PROCEDURE InsertEducation 
  @UserId INT,  -- Foreign key to Users table
  @Degree NVARCHAR(50),
  @Institution NVARCHAR(100),
  @FieldOfStudy NVARCHAR(100),
  @GraduationDate DATE,
  @GPA DECIMAL(5, 2)  -- Allow for GPA with two decimal places
AS
  INSERT INTO Education (UserId, Degree, Institution, FieldOfStudy, GraduationDate, GPA)
  VALUES (@UserId, @Degree, @Institution, @FieldOfStudy, @GraduationDate, @GPA);

  CREATE OR ALTER PROCEDURE UpdateEducation 
  @EducationId INT,
  @UserId INT,  -- Foreign key to Users table
  @Degree NVARCHAR(50) ,
  @Institution NVARCHAR(100),
  @FieldOfStudy NVARCHAR(100),
  @GraduationDate DATE,
  @GPA DECIMAL(5, 2)  -- Allow for GPA with two decimal places
AS
  UPDATE Education
  SET UserId = @UserId,
      Degree = @Degree,
      Institution = @Institution,
      FieldOfStudy = @FieldOfStudy,
      GraduationDate = @GraduationDate,
      GPA = @GPA
  WHERE EducationId = @EducationId;

CREATE OR ALTER PROCEDURE DeleteEducation 
  @EducationId INT
AS
  DELETE FROM Education WHERE EducationId = @EducationId;

CREATE OR ALTER PROCEDURE GetEducationById 
  @EducationId INT
AS
  SELECT * FROM Education WHERE EducationId = @EducationId;

CREATE OR ALTER PROCEDURE GetAllEducations
AS
	SELECT * FROM Education;

CREATE OR ALTER PROCEDURE TruncateEducation  -- Use with caution
AS
  TRUNCATE TABLE Education;

  -- QUERIES FOR VOLUNTEERING
  CREATE TABLE Volunteering (
  VolunteeringId INT PRIMARY KEY IDENTITY,
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (cascade delete)
  Organisation NVARCHAR(100) NOT NULL,
  Role NVARCHAR(50),
  Description NVARCHAR(MAX)
);

CREATE OR ALTER PROCEDURE InsertVolunteering 
  @UserId INT,  -- Foreign key to Users table
  @Organisation NVARCHAR(100),
  @Role NVARCHAR(50),
  @Description NVARCHAR(MAX)
AS
  INSERT INTO Volunteering (UserId, Organisation, Role, Description)
  VALUES (@UserId, @Organisation, @Role, @Description);

CREATE OR ALTER PROCEDURE UpdateVolunteering 
  @VolunteeringId INT,
  @UserId INT,  -- Foreign key to Users table
  @Organisation NVARCHAR(100),
  @Role NVARCHAR(50),
  @Description NVARCHAR(MAX)
AS
  UPDATE Volunteering
  SET UserId = @UserId,
      Organisation = @Organisation,
      Role = @Role,
      Description = @Description
  WHERE VolunteeringId = @VolunteeringId;

  CREATE OR ALTER PROCEDURE DeleteVolunteering 
  @VolunteeringId INT
AS
  DELETE FROM Volunteering WHERE VolunteeringId = @VolunteeringId;

CREATE OR ALTER PROCEDURE GetAllVolunteerings
AS
  SELECT * FROM Volunteering;

CREATE OR ALTER PROCEDURE GetVolunteeringById 
  @VolunteeringId INT
AS
  SELECT * FROM Volunteering WHERE VolunteeringId = @VolunteeringId;

CREATE OR ALTER PROCEDURE TruncateVolunteering
AS
	TRUNCATE TABLE Volunteering;
 
  -- QUERIES FOR WORKEXPERIENCE
  CREATE TABLE WorkExperience (
  WorkId INT PRIMARY KEY IDENTITY,
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (cascade delete)
  JobTitle NVARCHAR(100) NOT NULL,
  Company NVARCHAR(100) NOT NULL,
  Location NVARCHAR(100),
  EmploymentPeriod NVARCHAR(50),
  Responsibilities NVARCHAR(MAX),
  Achievements NVARCHAR(MAX),
  Description NVARCHAR(MAX),
);

CREATE OR ALTER PROCEDURE InsertWorkExperience
@UserId INT,
@JobTitle NVARCHAR(100),
@Company NVARCHAR(100) ,
@Location NVARCHAR(100),
@EmploymentPeriod NVARCHAR(50),
@Responsibilities NVARCHAR(MAX),
@Achievements NVARCHAR(MAX),
@Description NVARCHAR(MAX)
AS
BEGIN
  INSERT INTO WorkExperience (UserId, JobTitle, Company, Location, EmploymentPeriod, Responsibilities, Achievements, Description)
  VALUES (@UserId, @JobTitle, @Company, @Location, @EmploymentPeriod, @Responsibilities, @Achievements, @Description);
END;

CREATE OR ALTER PROCEDURE UpdateWorkExperience
@WorkId INT,
@UserId INT,
@JobTitle NVARCHAR(100),
@Company NVARCHAR(100),
@Location NVARCHAR(100),
@EmploymentPeriod NVARCHAR(50),
@Responsibilities NVARCHAR(MAX),
@Achievements NVARCHAR(MAX),
@Description NVARCHAR(MAX)
AS
BEGIN
  UPDATE WorkExperience
  SET UserId = @UserId,
      JobTitle = @JobTitle,
      Company = @Company,
      Location = @Location,
      EmploymentPeriod = @EmploymentPeriod,
      Responsibilities = @Responsibilities,
      Achievements = @Achievements,
      Description = @Description
  WHERE WorkId = @WorkId;
END;

CREATE OR ALTER PROCEDURE GetAllWorkExperiences
AS
BEGIN
  SELECT * FROM WorkExperience;
END;

CREATE OR ALTER PROCEDURE DeleteWorkExperience
@WorkId INT
AS
BEGIN
  DELETE FROM WorkExperience WHERE WorkId = @WorkId;
END;

CREATE OR ALTER PROCEDURE GetWorkExperienceById
@WorkId INT
AS
BEGIN
  SELECT * FROM WorkExperience WHERE WorkId = @WorkId;
END;


CREATE OR ALTER PROCEDURE TruncateWorkExperience
AS
BEGIN
  TRUNCATE TABLE WorkExperience;
END;

  -- QUERIES FOR PROJECTS
  CREATE TABLE Projects (
  ProjectId INT PRIMARY KEY IDENTITY,
  ProjectName NVARCHAR(100) NOT NULL,
  Description NVARCHAR(MAX),
  Technologies NVARCHAR(MAX),
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE SET NULL,  -- Foreign key to Users table (optional - set to NULL on delete)
);

-- Insert Procedure

CREATE OR ALTER PROCEDURE InsertProject
@ProjectName NVARCHAR(100) ,
@Description NVARCHAR(MAX),
@Technologies NVARCHAR(MAX),
@UserId INT
AS
BEGIN
  INSERT INTO Projects (ProjectName, Description, Technologies, UserId)
  VALUES (@ProjectName, @Description, @Technologies, @UserId);
END;

-- Update Procedure

CREATE OR ALTER PROCEDURE UpdateProject
@ProjectId INT,
@ProjectName NVARCHAR(100),
@Description NVARCHAR(MAX),
@Technologies NVARCHAR(MAX),
@UserId INT
AS
BEGIN
  UPDATE Projects
  SET ProjectName = @ProjectName,
      Description = @Description,
      Technologies = @Technologies,
      UserId = @UserId
  WHERE ProjectId = @ProjectId;
END;

-- Delete Procedure

CREATE OR ALTER PROCEDURE DeleteProject
@ProjectId INT
AS
BEGIN
  DELETE FROM Projects WHERE ProjectId = @ProjectId;
END;

-- Get All Procedure

CREATE OR ALTER PROCEDURE GetAllProjects
AS
BEGIN
  SELECT * FROM Projects;
END;

-- Get by ID Procedure

CREATE OR ALTER PROCEDURE GetProjectById
@ProjectId INT
AS
BEGIN
  SELECT * FROM Projects WHERE ProjectId = @ProjectId;
END;

-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateProject
AS
BEGIN
  TRUNCATE TABLE Projects;
END;

  -- QUERIES FOR SKILLS
  CREATE TABLE Skills (
  SkillId INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(100) NOT NULL,
);
ALTER TABLE Skills DROP COLUMN SkillLevel;

-- Insert Procedure

CREATE OR ALTER PROCEDURE InsertSkill
@Name NVARCHAR(100) 
AS
BEGIN
  INSERT INTO Skills (Name)
  VALUES (@Name);
END;

-- Update Procedure

CREATE OR ALTER PROCEDURE UpdateSkill
@SkillId INT,
@Name NVARCHAR(100) 
AS
BEGIN
  UPDATE Skills
  SET Name = @Name
  WHERE SkillId = @SkillId;
END;

-- Delete Procedure

CREATE OR ALTER PROCEDURE DeleteSkill
@SkillId INT
AS
BEGIN
  DELETE FROM Skills WHERE SkillId = @SkillId;
END;

-- Get All Procedure

CREATE OR ALTER PROCEDURE GetAllSkills
AS
BEGIN
  SELECT * FROM Skills;
END;

-- Get by ID Procedure

CREATE OR ALTER PROCEDURE GetSkillById
@SkillId INT
AS
BEGIN
  SELECT * FROM Skills WHERE SkillId = @SkillId;
END;

-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateSkill
AS
BEGIN
  TRUNCATE TABLE Skills;
END;


-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateSkill
AS
BEGIN
  TRUNCATE TABLE Skills;
END;


  -- QUERIES FOR NOTIFICATIONS
  CREATE TABLE Notifications (
  NotificationId INT PRIMARY KEY IDENTITY,
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (cascade delete)
  Activity NVARCHAR(255),
  Timestamp DATETIME2 NOT NULL DEFAULT (GETUTCDATE()),  -- Stores timestamp with automatic default to current UTC time
  Details NVARCHAR(MAX),
  IsRead BIT NOT NULL DEFAULT (0),  -- Stores read status as a bit (0 for unread, 1 for read)
);

-- Insert Procedure

CREATE OR ALTER PROCEDURE InsertNotification
@UserId INT,
@Activity NVARCHAR(255),
@Details NVARCHAR(MAX)
AS
BEGIN
  INSERT INTO Notifications (UserId, Activity, Details)
  VALUES (@UserId, @Activity, @Details);
END;

-- Update Procedure

CREATE OR ALTER PROCEDURE UpdateNotification
@NotificationId INT,
@UserId INT,
@Activity NVARCHAR(255),
@Details NVARCHAR(MAX),
@IsRead BIT
AS
BEGIN
  UPDATE Notifications
  SET UserId = @UserId,
      Activity = @Activity,
      Details = @Details,
      IsRead = @IsRead
  WHERE NotificationId = @NotificationId;
END;

-- Delete Procedure

CREATE OR ALTER PROCEDURE DeleteNotification
@NotificationId INT
AS
BEGIN
  DELETE FROM Notifications WHERE NotificationId = @NotificationId;
END;

-- Get All Procedure (Unread optional)

CREATE OR ALTER PROCEDURE GetAllNotifications
@IsReadFilter BIT = NULL  -- Optional parameter to filter by read status (0 for unread, 1 for read)
AS
BEGIN
  IF (@IsReadFilter IS NULL)
  BEGIN
    SELECT * FROM Notifications;
  END
  ELSE
  BEGIN
    SELECT * FROM Notifications WHERE IsRead = @IsReadFilter;
  END;
END;

-- Get by ID Procedure

CREATE OR ALTER PROCEDURE GetNotificationById
@NotificationId INT
AS
BEGIN
  SELECT * FROM Notifications WHERE NotificationId = @NotificationId;
END;

-- Mark All Read Procedure

CREATE OR ALTER PROCEDURE MarkAllNotificationsRead
AS
BEGIN
  UPDATE Notifications SET IsRead = 1;
END;  -- Sets all notifications to read

-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateNotification
AS
BEGIN
  TRUNCATE TABLE Notifications;
END;


  -- QUERIES FOR ENDORSEMENTS
  CREATE TABLE Endorsements (
  EndorsementId INT PRIMARY KEY IDENTITY,
  EndorserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE SET NULL,  -- Foreign key to Users (endorser) - set to NULL on delete
  RecipientId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE SET NULL,  -- Foreign key to Users (recipient) - set to NULL on delete
  SkillId INT FOREIGN KEY REFERENCES Skills(SkillId) ON DELETE SET NULL,  -- Foreign key to Skills table (optional - set to NULL on delete)
  CONSTRAINT Check_Unique_Endorsement UNIQUE (EndorserId, RecipientId, SkillId)  -- Enforces unique endorsements per skill (endorser, recipient)
);

-- Insert Procedure

CREATE OR ALTER PROCEDURE InsertEndorsement
@EndorserId INT,
@RecipientId INT,
@SkillId INT
AS
BEGIN
  INSERT INTO Endorsements (EndorserId, RecipientId, SkillId)
  VALUES (@EndorserId, @RecipientId, @SkillId);
END;

-- Update Procedure

CREATE OR ALTER PROCEDURE UpdateEndorsement
@EndorsementId INT,
@EndorserId INT,
@RecipientId INT,
@SkillId INT
AS
BEGIN
  UPDATE Endorsements
  SET EndorserId = @EndorserId,
      RecipientId = @RecipientId,
      SkillId = @SkillId
  WHERE EndorsementId = @EndorsementId;
END;

-- Delete Procedure

CREATE OR ALTER PROCEDURE DeleteEndorsement
@EndorsementId INT
AS
BEGIN
  DELETE FROM Endorsements WHERE EndorsementId = @EndorsementId;
END;

-- Get All Procedure

CREATE OR ALTER PROCEDURE GetAllEndorsements
AS
BEGIN
  SELECT * FROM Endorsements;
END;

-- Get by ID Procedure

CREATE OR ALTER PROCEDURE GetEndorsementById
@EndorsementId INT
AS
BEGIN
  SELECT * FROM Endorsements WHERE EndorsementId = @EndorsementId;
END;

-- Get Endorsements by Recipient (optional)

CREATE OR ALTER PROCEDURE GetEndorsementsByRecipientId
@RecipientId INT
AS
BEGIN
  SELECT * FROM Endorsements WHERE RecipientId = @RecipientId;
END;

-- Get Endorsements by Endorser (optional)

CREATE OR ALTER PROCEDURE GetEndorsementsByEndorserId
@EndorserId INT
AS
BEGIN
  SELECT * FROM Endorsements WHERE EndorserId = @EndorserId;
END;

-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateEndorsement
AS
BEGIN
  TRUNCATE TABLE Endorsements;
END;


  -- QUERIES FOR BUSSINESSCARD

CREATE TABLE BusinessCard (
  BCId INT PRIMARY KEY IDENTITY,
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (cascade delete)
  Summary NVARCHAR(255),
  UniqueUrl NVARCHAR(100)
);

CREATE OR ALTER PROCEDURE InsertBusinessCard
@UserId INT,
@Summary NVARCHAR(255),
@UniqueUrl NVARCHAR(100)
AS
  INSERT INTO BusinessCard (UserId, Summary, UniqueUrl)
  VALUES (@UserId, @Summary, @UniqueUrl);

CREATE OR ALTER PROCEDURE UpdateBusinessCard
@BCId INT,
@UserId INT,
@Summary NVARCHAR(255),
@UniqueUrl NVARCHAR(100)
AS
  UPDATE BusinessCard
  SET UserId = @UserId,
      Summary = @Summary,
      UniqueUrl = @UniqueUrl
  WHERE BCId = @BCId;

CREATE OR ALTER PROCEDURE DeleteBusinessCard
@BCId INT
AS
  DELETE FROM BusinessCard WHERE BCId = @BCId;

CREATE OR ALTER PROCEDURE GetAllBusinessCards
AS
  SELECT * FROM BusinessCard;

CREATE OR ALTER PROCEDURE GetBusinessCardById
	@BCId INT
AS
  SELECT * FROM BusinessCard WHERE BCId = @BCId;

CREATE OR ALTER PROCEDURE TruncateBusinessCard
AS
	TRUNCATE TABLE BusinessCard;


  -- QURIES FOR BussinesCardSkills 

  -- QURIES FOR AssesmentTest
 CREATE TABLE AssessmentTest (
  AssessmentTestId INT PRIMARY KEY IDENTITY,
  TestName NVARCHAR(100) NOT NULL,
  Description NVARCHAR(MAX),
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (optional - set to NULL on delete)
  SkillId INT FOREIGN KEY REFERENCES Skills(SkillId) ON DELETE CASCADE,  -- Foreign key to Skills table (optional - set to NULL on delete)
);

-- Insert Procedure

CREATE OR ALTER PROCEDURE InsertAssessmentTest
@TestName NVARCHAR(100) ,
@Description NVARCHAR(MAX),
@UserId INT,
@SkillId INT
AS
BEGIN
  INSERT INTO AssessmentTest (TestName, Description, UserId, SkillId)
  VALUES (@TestName, @Description, @UserId, @SkillId);
END;

-- Update Procedure

CREATE OR ALTER PROCEDURE UpdateAssessmentTest
@AssessmentTestId INT,
@TestName NVARCHAR(100) ,
@Description NVARCHAR(MAX),
@UserId INT,
@SkillId INT
AS
BEGIN
  UPDATE AssessmentTest
  SET TestName = @TestName,
      Description = @Description,
      UserId = @UserId,
      SkillId = @SkillId
  WHERE AssessmentTestId = @AssessmentTestId;
END;

-- Delete Procedure

CREATE OR ALTER PROCEDURE DeleteAssessmentTest
@AssessmentTestId INT
AS
BEGIN
  DELETE FROM AssessmentTest WHERE AssessmentTestId = @AssessmentTestId;
END;

-- Get All Procedure

CREATE OR ALTER PROCEDURE GetAllAssessmentTests
AS
BEGIN
  SELECT * FROM AssessmentTest;
END;

-- Get by ID Procedure

CREATE OR ALTER PROCEDURE GetAssessmentTestById
@AssessmentTestId INT
AS
BEGIN
  SELECT * FROM AssessmentTest WHERE AssessmentTestId = @AssessmentTestId;
END;

-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateAssessmentTest
AS
BEGIN
  TRUNCATE TABLE AssessmentTest;
END;

	-- QUERIES FOR UserSkills
-- UserSkills Table
DROP TABLE UserSkills;
CREATE TABLE UserSkills (
  UserSkillId INT PRIMARY KEY IDENTITY,
  UserId INT FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (cascade delete)
  SkillId INT FOREIGN KEY REFERENCES Skills(SkillId) ON DELETE CASCADE,  -- Foreign key to Skills table (cascade delete)
  SkillLevel NVARCHAR(50),  -- Adjust data type if needed for different skill levels (e.g., ENUM)
  CONSTRAINT Unique_UserSkill UNIQUE (UserId, SkillId)  -- Enforces unique skill per user
);

-- Insert Procedure

CREATE OR ALTER PROCEDURE InsertUserSkill
@UserId INT,
@SkillId INT,
@SkillLevel NVARCHAR(50)
AS
BEGIN
  INSERT INTO UserSkills (UserId, SkillId, SkillLevel)
  VALUES (@UserId, @SkillId, @SkillLevel);
END;

-- Update Procedure

CREATE OR ALTER PROCEDURE UpdateUserSkill
@UserSkillId INT,
@UserId INT,
@SkillId INT,
@SkillLevel NVARCHAR(50)
AS
BEGIN
  UPDATE UserSkills
  SET UserId = @UserId,
      SkillId = @SkillId,
      SkillLevel = @SkillLevel
  WHERE UserSkillId = @UserSkillId;
END;

-- Delete Procedure

CREATE OR ALTER PROCEDURE DeleteUserSkill
@UserSkillId INT
AS
BEGIN
  DELETE FROM UserSkills WHERE UserSkillId = @UserSkillId;
END;

-- Get All Procedure

CREATE OR ALTER PROCEDURE GetAllUserSkills
AS
BEGIN
  SELECT us.*, s.Name AS SkillName   -- Selects all UserSkills + Skill Name from Skills table
  FROM UserSkills us
  INNER JOIN Skills s ON us.SkillId = s.SkillId  -- Joins with Skills table for skill name
  ORDER BY us.UserId, s.Name;  -- Orders by user and skill name
END;

-- Get Skills by User ID Procedure

CREATE OR ALTER PROCEDURE GetSkillsByUserId
@UserId INT
AS
BEGIN
  SELECT us.*, s.Name AS SkillName   -- Selects all UserSkills + Skill Name from Skills table
  FROM UserSkills us
  INNER JOIN Skills s ON us.SkillId = s.SkillId  -- Joins with Skills table for skill name
  WHERE us.UserId = @UserId
  ORDER BY s.Name;  -- Orders by skill name
END;

-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateUserSkill
AS
BEGIN
  TRUNCATE TABLE UserSkills;
END;


	--QUERIES FOR BussinessCardSkills
	-- BusinessCardSkills Table

CREATE TABLE BusinessCardSkills (
  BusinessCardSkillId INT PRIMARY KEY IDENTITY,
  BusinessCardId INT FOREIGN KEY REFERENCES BusinessCard(BCId) ON DELETE CASCADE,  -- Foreign key to BusinessCard table (cascade delete)
  SkillId INT FOREIGN KEY REFERENCES Skills(SkillId) ON DELETE CASCADE,  -- Foreign key to Skills table (cascade delete)
  CONSTRAINT Unique_BusinessCardSkill UNIQUE (BusinessCardId, SkillId)  -- Enforces unique skill per business card
);

-- Insert Procedure

CREATE OR ALTER PROCEDURE InsertBusinessCardSkill
@BusinessCardId INT,
@SkillId INT
AS
BEGIN
  INSERT INTO BusinessCardSkills (BusinessCardId, SkillId)
  VALUES (@BusinessCardId, @SkillId);
END;

-- Update Procedure

CREATE OR ALTER PROCEDURE UpdateBusinessCardSkill
@BusinessCardSkillId INT,
@BusinessCardId INT,
@SkillId INT
AS
BEGIN
  UPDATE BusinessCardSkills
  SET BusinessCardId = @BusinessCardId,
      SkillId = @SkillId
  WHERE BusinessCardSkillId = @BusinessCardSkillId;
END;

-- Delete Procedure

CREATE OR ALTER PROCEDURE DeleteBusinessCardSkill
@BusinessCardSkillId INT
AS
BEGIN
  DELETE FROM BusinessCardSkills WHERE BusinessCardSkillId = @BusinessCardSkillId;
END;

-- Get All Procedure

CREATE OR ALTER PROCEDURE GetAllBusinessCardSkills
AS
BEGIN
  SELECT * FROM BusinessCardSkills;
END;

-- Get Skills by Business Card ID Procedure

CREATE OR ALTER PROCEDURE GetSkillsByBusinessCardId
@BusinessCardId INT
AS
BEGIN
  SELECT bcs.*, s.Name AS SkillName   -- Selects all BusinessCardSkills + Skill Name from Skills table
  FROM BusinessCardSkills bcs
  INNER JOIN Skills s ON bcs.SkillId = s.SkillId  -- Joins with Skills table for skill name
  WHERE bcs.BusinessCardId = @BusinessCardId;
END;

-- Truncate Procedure (Use with Caution)

CREATE OR ALTER PROCEDURE TruncateBusinessCardSkill
AS
BEGIN
  TRUNCATE TABLE BusinessCardSkills;
END;

-- QUERIES FOR PRIVACY
-- Privacy Table

CREATE TABLE Privacy (
  UserId INT PRIMARY KEY FOREIGN KEY REFERENCES Users(UserId) ON DELETE CASCADE,  -- Foreign key to Users table (cascade delete)
  CanViewEducation BIT DEFAULT 1,  -- Default: Education visible (true)
  CanViewWorkExperience BIT DEFAULT 1,  -- Default: Work experience visible (true)
  CanViewVolunteering BIT DEFAULT 1,  -- Default: Volunteering visible (true)
  CanViewProjects BIT DEFAULT 1,  -- Default: Projects visible (true)
  CanViewCertificates BIT DEFAULT 1,  -- Default: Certificates visible (true)
  CanViewSkills BIT DEFAULT 1  -- Default: Skills visible (true)
);

-- Insert Procedure (Upsert - Insert or Update)

CREATE OR ALTER PROCEDURE InsertOrUpdatePrivacySettings
@UserId INT,
@CanViewEducation BIT,
@CanViewWorkExperience BIT,
@CanViewVolunteering BIT,
@CanViewProjects BIT,
@CanViewCertificates BIT,
@CanViewSkills BIT
AS
BEGIN
  MERGE Privacy AS target
  USING (SELECT @UserId AS UserId, 
                @CanViewEducation AS CanViewEducation, 
                @CanViewWorkExperience AS CanViewWorkExperience, 
                @CanViewVolunteering AS CanViewVolunteering, 
                @CanViewProjects AS CanViewProjects, 
                @CanViewCertificates AS CanViewCertificates, 
                @CanViewSkills AS CanViewSkills) AS source
  ON (target.UserId = source.UserId)
  WHEN MATched THEN
    UPDATE SET CanViewEducation = source.CanViewEducation,
              CanViewWorkExperience = source.CanViewWorkExperience,
              CanViewVolunteering = source.CanViewVolunteering,
              CanViewProjects = source.CanViewProjects,
              CanViewCertificates = source.CanViewCertificates,
              CanViewSkills = source.CanViewSkills
  WHEN NOT MATCHED THEN
    INSERT (UserId, CanViewEducation, CanViewWorkExperience, CanViewVolunteering, CanViewProjects, CanViewCertificates, CanViewSkills)
    VALUES (source.UserId, source.CanViewEducation, source.CanViewWorkExperience, source.CanViewVolunteering, source.CanViewProjects, source.CanViewCertificates, source.CanViewSkills);
END;

-- Update Procedure (Optional - can be replaced by InsertOrUpdatePrivacySettings)

CREATE OR ALTER PROCEDURE UpdatePrivacySettings
@UserId INT,
@CanViewEducation BIT,
@CanViewWorkExperience BIT,
@CanViewVolunteering BIT,
@CanViewProjects BIT,
@CanViewCertificates BIT,
@CanViewSkills BIT
AS
BEGIN
  UPDATE Privacy
  SET CanViewEducation = @CanViewEducation,
      CanViewWorkExperience = @CanViewWorkExperience,
      CanViewVolunteering = @CanViewVolunteering,
      CanViewProjects = @CanViewProjects,
      CanViewCertificates = @CanViewCertificates,
      CanViewSkills = @CanViewSkills
  WHERE UserId = @UserId;
END;

-- Get Privacy Settings by User ID Procedure

CREATE OR ALTER PROCEDURE GetPrivacySettingsByUserId
@UserId INT
AS
BEGIN
  SELECT * FROM Privacy WHERE UserId = @UserId;
END;


-- EXECUTE PROCEDURES
  
   -- USERS EXEC
EXEC InsertUser 
  @FirstName = 'testFirstName',
  @LastName = 'testLastName',
  @Email = 'test@testing.com',
  @Password = 'testPassword',
  @Phone = '1234567890',
  @Summary = 'Test',
  @DateOfBirth ='2003-05-27',
  @DarkTheme =1,
  @Address ='AtCostinsMom',
  @WebsiteURL = 'www.google.com',
  @Picture = 'test';
EXEC GetAllUsers;
EXEC GetUserById @UserId=2;
EXEC DeleteUser @UserId=2;
EXEC TruncateUsers;
-- CERTIFICATE EXEC
EXEC InsertCertificate @UserId=3, @Name='How To Get Bitches', @Description='test', @IssuedBy='test', @IssuedDate='2024-03-12', @Expirationdate='2022-03-03';
EXEC GetAllCertificates;
EXEC GetCertificateById @CertificateId=3; -- on cascade is working, certId 3 no more after deleting user w id3
EXEC TruncateCertificates; -- EXECUTE TO RESET THE TABLE
-- EDUCATION EXEC
EXEC GetAllEducations;
EXEC InsertEducation @UserId=4, @Degree='test', @Institution='test', @FieldOfStudy ='test', @GraduationDate='2022-03-03',@GPA=3
EXEC GetEducationById @EducationId=2;
-- VOLUNTEERING EXEC
EXEC GetAllVolunteering;
EXEC InsertVolunteering @UserId=4, @Organisation='test', @Role='test', @Description='test';
EXEC GetVolunteeringById @VolunteeringId=2;
-- SKILLS EXEC
EXEC InsertSkill @Name='Coding';
EXEC GetAllSkills;
-- Get Skill by ID (assuming a skill was inserted previously)
EXEC GetSkillById @SkillId=1;
-- USERSKILLS EXEC
EXEC InsertUserSkill @UserId=4, @SkillId=1, @SkillLevel='Expert';
EXEC GetAllUserSkills;
EXEC GetSkillsByUserId @UserId=4;
EXEC UpdateUserSkill @UserSkillId=3, @UserId=4, @SkillId=1, @SkillLevel='Beginner';
EXEC DeleteUserSkill @UserSkillId=1;
--PROJECT EXEC
EXEC InsertProject @ProjectName='Sample Project', @Description='Test description', @Technologies='Python, SQL', @UserId=4;
EXEC GetAllProjects;
EXEC GetProjectById @ProjectId=1;
--PRIVACY
EXEC InsertOrUpdatePrivacySettings @UserId=4, 
                                    @CanViewEducation=1,  -- You can adjust these values
                                    @CanViewWorkExperience=1,
                                    @CanViewVolunteering=1,
                                    @CanViewProjects=1,
                                    @CanViewCertificates=1,
                                    @CanViewSkills=1;
EXEC GetPrivacySettingsByUserId @UserId=4;
EXEC UpdatePrivacySettings @UserId=4, 
                            @CanViewEducation=0,  -- Now hides education
                            @CanViewWorkExperience=1,
                            @CanViewVolunteering=0,
                            @CanViewProjects=1,
                            @CanViewCertificates=1,
                            @CanViewSkills=0;

