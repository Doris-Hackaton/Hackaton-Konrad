-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 08/27/2016 10:22:27

-- Generated from EDMX file: C:\Users\Daniel\Desktop\Hackaton-Konrad\Kima\Kima\KimaModel.edmx
-- Target version: 3.0.0.0

-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


--    ALTER TABLE `Enfermedads` DROP CONSTRAINT `FK_UsuarioEnfermedad`;

--    ALTER TABLE `Medicinas` DROP CONSTRAINT `FK_UsuarioMedicinas`;

--    ALTER TABLE `EnfermedadMedicinas` DROP CONSTRAINT `FK_EnfermedadMedicinas_Enfermedad`;

--    ALTER TABLE `EnfermedadMedicinas` DROP CONSTRAINT `FK_EnfermedadMedicinas_Medicinas`;

--    ALTER TABLE `Eventoes` DROP CONSTRAINT `FK_UsuarioEvento`;

--    ALTER TABLE `Eventoes` DROP CONSTRAINT `FK_CentroSaludEvento`;

--    ALTER TABLE `Eventoes` DROP CONSTRAINT `FK_EnfermedadEvento`;

--    ALTER TABLE `Eventoes` DROP CONSTRAINT `FK_MedicinasEvento`;


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;

    DROP TABLE IF EXISTS `Usuarios`;

    DROP TABLE IF EXISTS `CentroSaluds`;

    DROP TABLE IF EXISTS `Enfermedads`;

    DROP TABLE IF EXISTS `Medicinas`;

    DROP TABLE IF EXISTS `Eventoes`;

    DROP TABLE IF EXISTS `EnfermedadMedicinas`;

SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


CREATE TABLE `Usuarios`(
	`id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`email` longtext NOT NULL, 
	`password` longtext NOT NULL, 
	`nombre` longtext NOT NULL, 
	`edad` int NOT NULL, 
	`domicilio` longtext NOT NULL, 
	`proced_quirurgico` longtext, 
	`cedula` longtext NOT NULL);

ALTER TABLE `Usuarios` ADD PRIMARY KEY (`id`);





CREATE TABLE `CentroSaluds`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`nombre` longtext NOT NULL, 
	`seccion` longtext);

ALTER TABLE `CentroSaluds` ADD PRIMARY KEY (`Id`);





CREATE TABLE `Enfermedads`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`nombre` longtext NOT NULL, 
	`fecha_diagnostico` datetime, 
	`ultimo_evento` datetime, 
	`tipo` longtext NOT NULL, 
	`Usuario_id` int NOT NULL);

ALTER TABLE `Enfermedads` ADD PRIMARY KEY (`Id`);





CREATE TABLE `Medicinas`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`nombre` longtext NOT NULL, 
	`detalles` longtext, 
	`dosis` longtext NOT NULL, 
	`frecuencia` longtext NOT NULL, 
	`tipo` longtext NOT NULL, 
	`info_compra` longtext, 
	`Usuario_id` int NOT NULL);

ALTER TABLE `Medicinas` ADD PRIMARY KEY (`Id`);





CREATE TABLE `Eventoes`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`color` longtext, 
	`doctor` longtext, 
	`anotaciones` longtext, 
	`fecha` datetime, 
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
