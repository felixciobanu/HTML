-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: finbil_v3
-- ------------------------------------------------------
-- Server version	5.7.26

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ansatte`
--

DROP TABLE IF EXISTS `ansatte`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ansatte` (
  `telefonnummer` int(11) NOT NULL,
  `navn` varchar(45) NOT NULL,
  `etternavn` varchar(45) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`telefonnummer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ansatte`
--

LOCK TABLES `ansatte` WRITE;
/*!40000 ALTER TABLE `ansatte` DISABLE KEYS */;
INSERT INTO `ansatte` VALUES (12345678,'Lars','Larsen','Larsilarsen@email.com'),(45515593,'Felix','Ciobanu','felixciobanu2002@gmail.com');
/*!40000 ALTER TABLE `ansatte` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bil`
--

DROP TABLE IF EXISTS `bil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bil` (
  `regnr` char(7) NOT NULL,
  `tittel` varchar(150) NOT NULL,
  `merke` int(11) NOT NULL,
  `aarstall` int(11) NOT NULL,
  `pris` int(11) NOT NULL,
  `lokale` int(11) NOT NULL,
  `beskrivelse` text,
  `km` int(11) NOT NULL,
  `salgsform` int(11) NOT NULL,
  `omraade` int(11) NOT NULL,
  `karroseri` int(11) NOT NULL,
  `drivstoff` int(11) NOT NULL,
  `girkasse` int(11) NOT NULL,
  `hjuldrift` int(11) NOT NULL,
  `motor` varchar(10) DEFAULT NULL,
  `hestekrefter` int(11) DEFAULT NULL,
  `seter` int(11) DEFAULT NULL,
  `farge` varchar(20) DEFAULT NULL,
  `bildeadresse` varchar(500) DEFAULT NULL,
  `opplastningsdato` datetime DEFAULT CURRENT_TIMESTAMP,
  `solgt` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`regnr`),
  KEY `fk_bil_merke1_idx` (`merke`),
  KEY `fk_bil_tilstand1_idx` (`salgsform`),
  KEY `fk_bil_omraade1_idx` (`omraade`),
  KEY `fk_bil_karroseri1_idx` (`karroseri`),
  KEY `fk_bil_drivstoff1_idx` (`drivstoff`),
  KEY `fk_bil_girkasse1_idx` (`girkasse`),
  KEY `fk_bil_hjulsdrift1_idx` (`hjuldrift`),
  KEY `fk_bil_person2_idx` (`lokale`),
  CONSTRAINT `fk_bil_drivstoff1` FOREIGN KEY (`drivstoff`) REFERENCES `drivstoff` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bil_girkasse1` FOREIGN KEY (`girkasse`) REFERENCES `girkasse` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bil_hjulsdrift1` FOREIGN KEY (`hjuldrift`) REFERENCES `hjulsdrift` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bil_karroseri1` FOREIGN KEY (`karroseri`) REFERENCES `karroseri` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bil_merke1` FOREIGN KEY (`merke`) REFERENCES `merke` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bil_omraade1` FOREIGN KEY (`omraade`) REFERENCES `omraade` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bil_person2` FOREIGN KEY (`lokale`) REFERENCES `lokale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bil_tilstand1` FOREIGN KEY (`salgsform`) REFERENCES `salgform` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bil`
--

LOCK TABLES `bil` WRITE;
/*!40000 ALTER TABLE `bil` DISABLE KEYS */;
INSERT INTO `bil` VALUES ('PR47029','2,0 TDI 190hk Black Edition quattro aut 19\'\'/LED/ACC/++',2,2018,499000,2,'A6 Avant demonstrerer en perfekt balanse av suverene egenskaper. Ikke bare er den sportslig og elegant, men også funksjonell og komfortabel. Lette, elegante former samt en presis linjeføring skaper en unik silhuett.',60000,6,2,9,7,3,6,'TDI 2.0',190,5,'svart','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-3/19/9/173/090/169_1393564116.jpg','2020-03-20 11:29:27','nei'),('RL35622','326HK/COMPETITION/RS/MATRIX/WEBASTO/DAB/ SKIBOKS/ADAPTIV',2,2019,719800,2,'Tiden har kommet for å selge vår nydelige 2019 Audi A6 Avant Sport 45 3,0TDI 231hk quattro demonstrasjonsbil! ',26500,6,2,9,7,3,6,'TDI 2.0',231,5,'svart','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-3/18/0/173/221/620_1619926621.jpg','2020-03-20 11:34:42','nei'),('TV94492','Avant 50 3,0 TDI 286hk BANG&OLUFSEN/ADABT LUFT/2XS-LINE',2,2019,949000,4,'Her er en beskrivelse',26500,6,2,9,7,3,6,'',286,5,'svart','https://images.finncdn.no/dynamic/1280w/2020/2/vertical-3/06/6/167/058/096_1715553904.jpg','2020-03-30 09:28:40','nei'),('VH81981','320D XDRIVE 2.0-190 D',9,2017,390000,3,'MW 320 xDrive med mye utstyr selges.\r\n\r\nBilen er norsk solgt og innehar full garanti med komplette sommer og vinterhjul. den er strøken i lakk og er bulke fri.\r\n\r\nHovedservice og EU er utført på BMW i Januar 2020.\r\n\r\nAv utstyr kan det nevnes M Sportspakke, Adaptivt M Sportsunderstell, Keyless Go, Adaptive Cruise Control m/ Stop & Go, HUD (Head-Up Display), Harman Kardon Sound System inkl DAB, Panorama tak, Utsvingbart hengerfeste, Ryggekamera, 19\" M-Sporthjul (antrasittpolert), Oppvarmet ratt, Privacy glass + mye mer!\r\n\r\nBilen er akkurat EU godkjent.\r\nHovedservice tatt i Januar 2020',45500,6,2,6,7,3,6,'2.0-190 D',190,5,'svart','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-0/27/2/173/954/662_854014266.jpg','2020-04-02 11:14:33','nei');
/*!40000 ALTER TABLE `bil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bilde`
--

DROP TABLE IF EXISTS `bilde`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bilde` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `regnr` char(7) NOT NULL,
  `bildeadresser` varchar(500) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_bilde_bil1_idx` (`regnr`),
  CONSTRAINT `fk_bilde_bil1` FOREIGN KEY (`regnr`) REFERENCES `bil` (`regnr`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bilde`
--

LOCK TABLES `bilde` WRITE;
/*!40000 ALTER TABLE `bilde` DISABLE KEYS */;
INSERT INTO `bilde` VALUES (1,'RL35622','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-3/18/0/173/221/620_1619926621.jpg'),(2,'PR47029','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-3/19/9/173/090/169_1393564116.jpg'),(3,'TV94492','https://images.finncdn.no/dynamic/1280w/2020/2/vertical-3/27/6/167/058/096_681947420.jpg'),(8,'TV94492','https://images.finncdn.no/dynamic/1280w/2020/2/vertical-3/27/6/167/058/096_1088677606.jpg'),(9,'TV94492','https://images.finncdn.no/dynamic/1280w/2020/2/vertical-3/27/6/167/058/096_1467987497.jpg'),(10,'TV94492','https://images.finncdn.no/dynamic/1280w/2020/2/vertical-3/27/6/167/058/096_42255179.jpg'),(12,'VH81981','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-0/27/2/173/954/662_854014266.jpg'),(13,'VH81981','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-0/27/2/173/954/662_1143568502.jpg'),(14,'VH81981','https://images.finncdn.no/dynamic/1280w/2020/3/vertical-0/27/2/173/954/662_84168569.jpg');
/*!40000 ALTER TABLE `bilde` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drivstoff`
--

DROP TABLE IF EXISTS `drivstoff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `drivstoff` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fuel` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drivstoff`
--

LOCK TABLES `drivstoff` WRITE;
/*!40000 ALTER TABLE `drivstoff` DISABLE KEYS */;
INSERT INTO `drivstoff` VALUES (6,'Bensin'),(7,'Diesel'),(8,'Hybrid'),(9,'Elektrisk'),(10,'Hydrogen');
/*!40000 ALTER TABLE `drivstoff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `girkasse`
--

DROP TABLE IF EXISTS `girkasse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `girkasse` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `girkasse` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `girkasse`
--

LOCK TABLES `girkasse` WRITE;
/*!40000 ALTER TABLE `girkasse` DISABLE KEYS */;
INSERT INTO `girkasse` VALUES (3,'Automat'),(4,'Manuell');
/*!40000 ALTER TABLE `girkasse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hjulsdrift`
--

DROP TABLE IF EXISTS `hjulsdrift`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hjulsdrift` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stil` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hjulsdrift`
--

LOCK TABLES `hjulsdrift` WRITE;
/*!40000 ALTER TABLE `hjulsdrift` DISABLE KEYS */;
INSERT INTO `hjulsdrift` VALUES (4,'Forhjulsdrift'),(5,'Bakhjulsdrift'),(6,'Firehjulsdrift');
/*!40000 ALTER TABLE `hjulsdrift` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jobber`
--

DROP TABLE IF EXISTS `jobber`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jobber` (
  `ansatte_telefonnummer` int(11) NOT NULL,
  `lokalet_id` int(11) NOT NULL,
  `stilling` varchar(45) NOT NULL,
  PRIMARY KEY (`ansatte_telefonnummer`,`lokalet_id`),
  KEY `fk_ansatte_has_lokale_lokale1_idx` (`lokalet_id`),
  KEY `fk_ansatte_has_lokale_ansatte1_idx` (`ansatte_telefonnummer`),
  CONSTRAINT `fk_ansatte_has_lokale_ansatte1` FOREIGN KEY (`ansatte_telefonnummer`) REFERENCES `ansatte` (`telefonnummer`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ansatte_has_lokale_lokale1` FOREIGN KEY (`lokalet_id`) REFERENCES `lokale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jobber`
--

LOCK TABLES `jobber` WRITE;
/*!40000 ALTER TABLE `jobber` DISABLE KEYS */;
INSERT INTO `jobber` VALUES (12345678,2,'dagligleder'),(45515593,4,'CEO');
/*!40000 ALTER TABLE `jobber` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `karroseri`
--

DROP TABLE IF EXISTS `karroseri`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `karroseri` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `karroseri` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `karroseri`
--

LOCK TABLES `karroseri` WRITE;
/*!40000 ALTER TABLE `karroseri` DISABLE KEYS */;
INSERT INTO `karroseri` VALUES (6,'Sedan'),(7,'Combi'),(8,'SUV'),(9,'Stasjonsvogn');
/*!40000 ALTER TABLE `karroseri` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lokale`
--

DROP TABLE IF EXISTS `lokale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lokale` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sted` varchar(45) NOT NULL,
  `email` varchar(45) DEFAULT NULL,
  `adresse` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lokale`
--

LOCK TABLES `lokale` WRITE;
/*!40000 ALTER TABLE `lokale` DISABLE KEYS */;
INSERT INTO `lokale` VALUES (2,'Oslo','Oslobilforhandler@email.com','Oslogata 1'),(3,'Forus','Forusbilforhandler@email.com','Forusgata 10'),(4,'Bergen','Bergensbil@email.com','Bergens gata 8');
/*!40000 ALTER TABLE `lokale` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `merke`
--

DROP TABLE IF EXISTS `merke`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `merke` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bilmerke` varchar(45) NOT NULL,
  `model` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `merke`
--

LOCK TABLES `merke` WRITE;
/*!40000 ALTER TABLE `merke` DISABLE KEYS */;
INSERT INTO `merke` VALUES (2,'Audi ','A6'),(7,'Audi','A5 '),(8,'BMW','serie 5'),(9,'BMW','serie 3'),(10,'Audi','A4'),(11,'Audi','A8'),(12,'Audi','A7'),(13,'Audi','A6 Allroad');
/*!40000 ALTER TABLE `merke` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nyheter`
--

DROP TABLE IF EXISTS `nyheter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nyheter` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tittel` varchar(45) NOT NULL,
  `innhold` text NOT NULL,
  `bildeadresse` varchar(500) DEFAULT NULL,
  `opplastningsdato` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nyheter`
--

LOCK TABLES `nyheter` WRITE;
/*!40000 ALTER TABLE `nyheter` DISABLE KEYS */;
INSERT INTO `nyheter` VALUES (1,'Nye biler kommer','Vi ønsker å gjøre det lettere for våre kunder å handle hos oss, og derfor ønsker vi å tilby et større utvalg av biler. Dette vil gjelde i våre lokaler og på nett.',NULL,'2020-03-19 12:48:13'),(6,'Ny audi kommer','Ny Audi vil komme ved begynnelsen av april. Mer info vil komme etterhvert.','','2020-03-19 12:51:31'),(7,'Audi E-tron ','Audi E-tron er bilen det selges flest av derfor skal vi satse mer på E-tron','https://www.elbilnyheter.no/wp-content/uploads/2020/02/1-scaled.jpg','2020-04-02 12:10:54');
/*!40000 ALTER TABLE `nyheter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `omraade`
--

DROP TABLE IF EXISTS `omraade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `omraade` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fylke` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `omraade`
--

LOCK TABLES `omraade` WRITE;
/*!40000 ALTER TABLE `omraade` DISABLE KEYS */;
INSERT INTO `omraade` VALUES (2,'Rogaland'),(3,'Agder'),(4,'Oslo'),(5,'Vestland'),(6,'Viken'),(7,'Trøndelag'),(8,'Troms og Finnmark'),(9,'Vestfold og Telemark'),(10,'Nordland'),(11,'Møre og Romsdal'),(12,'Innlandet');
/*!40000 ALTER TABLE `omraade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salgform`
--

DROP TABLE IF EXISTS `salgform`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salgform` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `salgsform` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salgform`
--

LOCK TABLES `salgform` WRITE;
/*!40000 ALTER TABLE `salgform` DISABLE KEYS */;
INSERT INTO `salgform` VALUES (4,'Ny bil'),(5,'Leasing'),(6,'Bruktbil');
/*!40000 ALTER TABLE `salgform` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-04-02 13:51:43
