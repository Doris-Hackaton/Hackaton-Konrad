-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 08/27/2016 09:36:56

-- Generated from EDMX file: C:\Users\Daniel\Desktop\Hackaton-Konrad\Kima\Kima\KimaModel.edmx
-- Target version: 3.0.0.0

-- --------------------------------------------------


DROP DATABASE IF EXISTS `doroteos`;
CREATE DATABASE `doroteos`;
USE `doroteos`;


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;

SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


CREATE TABLE `Usuarios`(
	`id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`email` longtext NOT NULL, 
	`password` longtext NOT NULL, 
	`nombre` longtext NOT NULL, 
	`edad` longtext NOT NULL, 
	`domicilio` longtext NOT NULL, 
	`proced_quirurgico` longtext NOT NULL, 
	`cedula` longtext NOT NULL);

ALTER TABLE `Usuarios` ADD PRIMARY KEY (`id`);





CREATE TABLE `CentroSaluds`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`nombre` longtext NOT NULL, 
	`seccion` longtext NOT NULL);

ALTER TABLE `CentroSaluds` ADD PRIMARY KEY (`Id`);





CREATE TABLE `Enfermedads`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`nombre` longtext NOT NULL, 
	`fecha_diagnostico` longtext NOT NULL, 
	`ultimo_evento` longtext NOT NULL, 
	`tipo` longtext NOT NULL, 
	`Usuario_id` int NOT NULL);

ALTER TABLE `Enfermedads` ADD PRIMARY KEY (`Id`);





CREATE TABLE `Medicinas`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`nombre` longtext NOT NULL, 
	`detalles` longtext NOT NULL, 
	`dosis` longtext NOT NULL, 
	`frecuencia` longtext NOT NULL, 
	`tipo` longtext NOT NULL, 
	`info_compra` longtext NOT NULL, 
	`Usuario_id` int NOT NULL);

ALTER TABLE `Medicinas` ADD PRIMARY KEY (`Id`);





CREATE TABLE `Eventoes`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`color` longtext NOT NULL, 
	`doctor` longtext NOT NULL, 
	`anotaciones` longtext NOT NULL, 
	`fecha` longtext NOT NULL, 
	`Usuario_id` int NOT NULL, 
	`CentroSalud_Id` int NOT NULL, 
	`Enfermedad_Id` int NOT NULL, 
	`Medicina_Id` int NOT NULL);

ALTER TABLE `Eventoes` ADD PRIMARY KEY (`Id`);





CREATE TABLE `EnfermedadMedicinas`(
	`Enfermedads_Id` int NOT NULL, 
	`Medicinas_Id` int NOT NULL);

ALTER TABLE `EnfermedadMedicinas` ADD PRIMARY KEY (`Enfermedads_Id`, `Medicinas_Id`);







-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------


-- Creating foreign key on `Usuario_id` in table 'Enfermedads'

ALTER TABLE `Enfermedads`
ADD CONSTRAINT `FK_UsuarioEnfermedad`
    FOREIGN KEY (`Usuario_id`)
    REFERENCES `Usuarios`
        (`id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioEnfermedad'

CREATE INDEX `IX_FK_UsuarioEnfermedad`
    ON `Enfermedads`
    (`Usuario_id`);



-- Creating foreign key on `Usuario_id` in table 'Medicinas'

ALTER TABLE `Medicinas`
ADD CONSTRAINT `FK_UsuarioMedicinas`
    FOREIGN KEY (`Usuario_id`)
    REFERENCES `Usuarios`
        (`id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioMedicinas'

CREATE INDEX `IX_FK_UsuarioMedicinas`
    ON `Medicinas`
    (`Usuario_id`);



-- Creating foreign key on `Enfermedads_Id` in table 'EnfermedadMedicinas'

ALTER TABLE `EnfermedadMedicinas`
ADD CONSTRAINT `FK_EnfermedadMedicinas_Enfermedad`
    FOREIGN KEY (`Enfermedads_Id`)
    REFERENCES `Enfermedads`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;



-- Creating foreign key on `Medicinas_Id` in table 'EnfermedadMedicinas'

ALTER TABLE `EnfermedadMedicinas`
ADD CONSTRAINT `FK_EnfermedadMedicinas_Medicinas`
    FOREIGN KEY (`Medicinas_Id`)
    REFERENCES `Medicinas`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_EnfermedadMedicinas_Medicinas'

CREATE INDEX `IX_FK_EnfermedadMedicinas_Medicinas`
    ON `EnfermedadMedicinas`
    (`Medicinas_Id`);



-- Creating foreign key on `Usuario_id` in table 'Eventoes'

ALTER TABLE `Eventoes`
ADD CONSTRAINT `FK_UsuarioEvento`
    FOREIGN KEY (`Usuario_id`)
    REFERENCES `Usuarios`
        (`id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioEvento'

CREATE INDEX `IX_FK_UsuarioEvento`
    ON `Eventoes`
    (`Usuario_id`);



-- Creating foreign key on `CentroSalud_Id` in table 'Eventoes'

ALTER TABLE `Eventoes`
ADD CONSTRAINT `FK_CentroSaludEvento`
    FOREIGN KEY (`CentroSalud_Id`)
    REFERENCES `CentroSaluds`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_CentroSaludEvento'

CREATE INDEX `IX_FK_CentroSaludEvento`
    ON `Eventoes`
    (`CentroSalud_Id`);



-- Creating foreign key on `Enfermedad_Id` in table 'Eventoes'

ALTER TABLE `Eventoes`
ADD CONSTRAINT `FK_EnfermedadEvento`
    FOREIGN KEY (`Enfermedad_Id`)
    REFERENCES `Enfermedads`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_EnfermedadEvento'

CREATE INDEX `IX_FK_EnfermedadEvento`
    ON `Eventoes`
    (`Enfermedad_Id`);



-- Creating foreign key on `Medicina_Id` in table 'Eventoes'

ALTER TABLE `Eventoes`
ADD CONSTRAINT `FK_MedicinasEvento`
    FOREIGN KEY (`Medicina_Id`)
    REFERENCES `Medicinas`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_MedicinasEvento'

CREATE INDEX `IX_FK_MedicinasEvento`
    ON `Eventoes`
    (`Medicina_Id`);



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
