-- create database workoutDB;
-- use workoutDB;

-----------------------------------------------------------------------
--                           CREATE TABLES
-----------------------------------------------------------------------

CREATE TABLE [user] (
  u_name VARCHAR(100) UNIQUE NOT NULL CHECK(DATALENGTH(u_name) > 3),
  u_password VARCHAR(150) NOT NULL CHECK(DATALENGTH(u_password) > 5),
  u_age TINYINT NOT NULL CHECK(u_age > 5 AND u_age < 120),
  u_height SMALLINT NOT NULL CHECK(u_height > 50 AND u_height < 300),
  u_weight TINYINT NOT NULL CHECK(u_weight > 14),
  PRIMARY KEY (u_name));
  
CREATE TABLE workout (
  w_id TINYINT IDENTITY(1,1),
  w_name VARCHAR(150) NOT NULL,
  PRIMARY KEY (w_id));
  
CREATE TABLE exercise(
  e_id SMALLINT IDENTITY(1,1),
  e_name VARCHAR(150) NOT NULL,
  PRIMARY KEY (e_id));
  
CREATE TABLE workoutsteps(
  ws_id INT IDENTITY(1,1),
  ws_e_exercise SMALLINT NOT NULL CHECK(ws_e_exercise > 0),
  ws_w_workout TINYINT NOT NULL CHECK(ws_w_workout > 0),
  PRIMARY KEY(ws_id),
  CONSTRAINT ws_e_exerciseconstr
    FOREIGN KEY (ws_e_exercise)
    REFERENCES exercise (e_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT ws_w_workoutconstr
    FOREIGN KEY (ws_w_workout)
    REFERENCES workout (w_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE workoutplanentry (
  wpe_id BIGINT IDENTITY(1,1),
  wpe_w_workout TINYINT NOT NULL CHECK(wpe_w_workout > 0),
  wpe_creationdate DATE NOT NULL,
  wpe_scheduledate DATE NOT NULL CHECK(wpe_scheduledate >= GETDATE()),
  wpe_repeat BIT NOT NULL,
  wpe_u_user VARCHAR(100) NOT NULL,
  PRIMARY KEY (wpe_id),
  CONSTRAINT wpe_w_workoutconstr
    FOREIGN KEY (wpe_w_workout)
    REFERENCES workout (w_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT wpe_u_userconstr
    FOREIGN KEY (wpe_u_user)
    REFERENCES [user] (u_name)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE stepsdone (
  sd_id BIGINT IDENTITY(1,1),
  sd_e_exercise SMALLINT NOT NULL CHECK(sd_e_exercise > 0),
  sd_wpe_workoutplanentry BIGINT NOT NULL CHECK(sd_wpe_workoutplanentry > 0),
  PRIMARY KEY (sd_id),
  CONSTRAINT sd_e_exerciseconstr
    FOREIGN KEY (sd_e_exercise)
    REFERENCES exercise (e_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT sd_wpe_workoutplanentryconstr
    FOREIGN KEY (sd_wpe_workoutplanentry)
    REFERENCES workoutplanentry (wpe_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);