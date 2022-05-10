-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 27, 2022 at 09:35 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `biblioteka_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `autoriai`
--

CREATE TABLE `autoriai` (
  `id` int(11) NOT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `pavarde` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `autoriai`
--

INSERT INTO `autoriai` (`id`, `vardas`, `pavarde`) VALUES
(0, 'Sandro', 'Veronesi'),
(1, 'Alberas', 'Kamiu'),
(2, 'Astrid', 'Lindgren'),
(3, 'Joanne', 'Rowling'),
(4, 'John', 'Green'),
(5, 'Jurgen', 'Banscherus'),
(6, 'Gayle', 'Forman'),
(7, 'Waris', 'Darie'),
(8, 'Jonas', 'Biliūnas'),
(9, 'Salomėja', 'Nėris'),
(10, 'Kristijonas', 'Donelaitis'),
(11, 'Balys', 'Sruoga'),
(12, 'Antanas', 'Baranauskas'),
(13, 'Juozas', 'Aputis'),
(14, 'Francas', 'Kafka'),
(15, 'Jurgis', 'Kunčinas'),
(16, 'Šatrijos', 'Ragana'),
(17, 'William', 'Shakespeare'),
(18, 'Stephenie', 'Meyer'),
(19, 'Clice Staple', 'Lewis'),
(20, 'Kristina', 'Sabaliauskaitė'),
(21, 'Pierre', 'Delye'),
(22, 'Christelle', 'Dabos'),
(23, 'Mark', 'Twain'),
(24, 'Eglė', 'Ramoškaitė');

-- --------------------------------------------------------

--
-- Table structure for table `bibliotekos`
--

CREATE TABLE `bibliotekos` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `adresas` varchar(255) DEFAULT NULL,
  `telefonas` int(11) DEFAULT NULL,
  `el_pastas` varchar(255) DEFAULT NULL,
  `darbo_laikas` varchar(255) DEFAULT NULL,
  `fk_tipasid_tipas` int(11) NOT NULL,
  `fk_miestasid_miestas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `bibliotekos`
--

INSERT INTO `bibliotekos` (`id`, `pavadinimas`, `adresas`, `telefonas`, `el_pastas`, `darbo_laikas`, `fk_tipasid_tipas`, `fk_miestasid_miestas`) VALUES
(0, 'G. Petkevičaitės-Bitės', 'Respublikos g. 14, 35184', 845501650, 'petkevicaitesbiblioteka@gmail.com', '10:00-19:00', 3, 5),
(1, 'Girstupio', 'Kovo 11-osios g. 24, 51349', 837457465, 'girstupiobiblioteka@gmail.com', '9:00-19:00', 3, 2),
(2, 'Berželio', 'Taikos pr. 113b, 50023', 837452404, 'berzeliobiblioteka@gmail.com', '10:00-19:00', 3, 2),
(3, 'Kauno apskrities viešoji biblioteka vaikų literatūros skyrius', 'Lydos g. 4, 44213', 837324259, 'kaunoapskirtiesbiblioteka@gmail.com', '10:00-18:00', 2, 2),
(4, 'Saulutė', 'Žirmūnų g. 2, 09214', 852730605, 'saulutebiblioteka@gmail.com', '10:00-18:00', 2, 1),
(5, 'Mykolo Romerio universiteto biblioteka', 'Ateities g. 20, 08303', 852714599, 'romeriobiblioteka@gmail.com', '9:00-19:00', 4, 1),
(6, 'Imanuelio Kanto viešoji biblioteka', 'Kretingos g. 61, 92304', 846314726, 'kantobiblioteka@gmail.com', '10:00-18:00', 3, 3),
(7, 'Spindulys', 'Spindulio g. 5, 76163', 841545013, 'spindulysbiblioteka@gmail.com', '10:00-17:00', 3, 4),
(8, 'Žinurėlis', 'Parko g. 49, 37303', 845526873, 'zinureliobiblioteka@gmail.com', '10:00-18:00', 2, 5),
(9, 'Panevėžio viešoji biblioteka', 'Kniaudiškių g. 34, 37118', 845420379, 'suaugusiujubiblioteka@gmail.com', '9:00-19:00', 1, 5),
(10, 'Lietuvos nacionalinė Martyno Mažvydo', 'Gedimino pr. 51, 01109', 852497028, 'mazvydobiblioteka@gmail.com', '8:00-21:00', 0, 1),
(11, 'Jurgio Kunčino', 'Seirijų g. 2, 62116', 831532446, 'kuncinobiblioteka@gmail.com', '9:00-19:00', 3, 6),
(12, 'Petro Kriaučiūno', 'Vytauto g. 22, 68298', 834352637, 'kriauciunobiblioteka@gmail.com', '10:00-18:00', 3, 7),
(13, 'Viktoro Miliūno', 'Pamario g. 53, 93124', 846952506, 'miliunobiblioteka@gmail.com', '11:00-18:00', 3, 17),
(14, 'Vlado Šlaito', 'Vytauto g. 30, 20107', 865934830, 'slaitobiblioteka@gmail.com', '9:00-18:00', 3, 14),
(15, 'Žydų', 'Gedimino pr. 24, 01103', 852444121, 'zydubiblioteka@gmail.com', '11:00-18:00', 4, 1),
(16, 'Vinco Kudirkos', 'Laisvės al. 57, 44305', 837206414, 'kudirkosbiblioteka@gmail.com', '9:00-19:00', 0, 0),
(17, 'Petrašiūnų', 'Ekskavatorininkų g. 8, 52372', 837370223, 'petrasiunubiblioteka@gmail.com', '10:00-18:00', 0, 2),
(18, 'Eigulių', 'Šiaurės pr. 95, 49219', 837386972, 'eiguliubiblioteka@gmail.com', '11:00-19:00', 3, 2),
(19, 'Panemunės', 'Vaidoto g. 115, 45390', 837346298, 'panemunesbiblioteka@gmail.com', '10:00-19:00', 3, 2),
(20, 'Karolinos Praniauskaitės', 'Respublikos g. 18, 87333', 844445785, 'praniauskaitesbiblioteka@gmail.com', '10:00-18:00', 3, 13);

-- --------------------------------------------------------

--
-- Table structure for table `busenos`
--

CREATE TABLE `busenos` (
  `id_busenos` int(11) NOT NULL,
  `name` char(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `busenos`
--

INSERT INTO `busenos` (`id_busenos`, `name`) VALUES
(0, 'nera'),
(1, 'yra');

-- --------------------------------------------------------

--
-- Table structure for table `darbuotojai`
--

CREATE TABLE `darbuotojai` (
  `tabelio_nr` int(11) NOT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `pavarde` varchar(255) DEFAULT NULL,
  `telefonas` int(11) DEFAULT NULL,
  `val_atlyginimas` double DEFAULT NULL,
  `atlyginimas` double DEFAULT NULL,
  `banko_saskaita` varchar(255) DEFAULT NULL,
  `fk_bibliotekaid_biblioteka` int(11) NOT NULL,
  `fk_pareigosid_pareigos` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `darbuotojai`
--

INSERT INTO `darbuotojai` (`tabelio_nr`, `vardas`, `pavarde`, `telefonas`, `val_atlyginimas`, `atlyginimas`, `banko_saskaita`, `fk_bibliotekaid_biblioteka`, `fk_pareigosid_pareigos`) VALUES
(100, 'Vida', 'Plaušienė', 868717414, 7, 1000, 'LT944010042400050387', 18, 1),
(101, 'Jurgita', 'Jurgaitė', 867717414, 6, 700, 'LT944010042400050000', 18, 4),
(102, 'Rūta', 'Lopšienė', 865557414, 6, 700, 'LT944011142400050387', 18, 4),
(103, 'Evaldas', 'Karosas', 867713334, 6, 650, ' LT94411142400050387', 0, 4),
(104, 'Rokas', 'Šiurpšys', 867719914, 7, 900, ' LT944010042400050383', 0, 1),
(105, 'Karolina', 'Sinkutė', 867717445, 6, 500, ' LT944010888400050387', 0, 0),
(106, 'Paulius', 'Palionis', 865552896, 5, 400, 'LT944010042409950387', 11, 0),
(107, 'Kristupas', 'Šiaukus', 865552897, 6, 650, 'LT944010042406660387', 11, 4),
(108, 'Saulė', 'Olinkienė', 865552196, 5, 400, 'LT944017742400050387', 15, 0),
(109, 'Ieva', 'Norvilienė', 865552296, 7, 800, 'LT944010042400099387', 11, 1),
(110, 'Margarita', 'Mikšionienė', 865553396, 7, 650, 'LT944010042433399387', 15, 4),
(111, 'Ona', 'Ruškienė', 867808477, 6, 580, 'LT944010042406699387', 17, 4),
(112, 'Erikas', 'Virilis', 867801177, 6, 500, 'LT949910042400099387', 17, 4),
(113, 'Rytis', 'Naujelis', 867836877, 8, 990, 'LT944010042400011387', 17, 1),
(114, 'Mantas', 'Karpis', 867801237, 7, 750, 'LT944010042408099387', 4, 3),
(115, 'Nedas', 'Markutis', 867638477, 6, 630, 'LT944010042400299387', 4, 4),
(116, 'Zita', 'Kalminskienė', 867808256, 7, 890, 'LT944010042444099387', 4, 1),
(117, 'Neda', 'Maminskaitė', 867884577, 5, 653, 'LT944330042400099387', 7, 0),
(118, 'Giedrė', 'Juknaitė', 867808267, 6, 670, 'LT944010042400045387', 7, 4),
(119, 'Rusnė', 'Onškienė', 867808512, 8, 950, 'LT944010042403268387', 7, 1);

-- --------------------------------------------------------

--
-- Table structure for table `kategoriju_tipai`
--

CREATE TABLE `kategoriju_tipai` (
  `id_kategoriju_tipai` int(11) NOT NULL,
  `name` char(17) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kategoriju_tipai`
--

INSERT INTO `kategoriju_tipai` (`id_kategoriju_tipai`, `name`) VALUES
(0, 'vaikas'),
(1, 'mokinys/studentas'),
(2, 'suaugusis'),
(3, 'senjoras');

-- --------------------------------------------------------

--
-- Table structure for table `knygos`
--

CREATE TABLE `knygos` (
  `ISBN` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `puslapiu_skaicius` int(11) DEFAULT NULL,
  `leidimo_metai` date DEFAULT NULL,
  `kalba` varchar(255) DEFAULT NULL,
  `kiekis` int(11) DEFAULT NULL,
  `busena` int(11) DEFAULT NULL,
  `fk_zanrasid_zanras` int(11) NOT NULL,
  `fk_autoriusid_autorius` int(11) NOT NULL,
  `fk_leidyklaid_leidykla` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `knygos`
--

INSERT INTO `knygos` (`ISBN`, `pavadinimas`, `puslapiu_skaicius`, `leidimo_metai`, `kalba`, `kiekis`, `busena`, `fk_zanrasid_zanras`, `fk_autoriusid_autorius`, `fk_leidyklaid_leidykla`) VALUES
(1111, 'Pepė Ilgakojinė', 296, '2021-02-10', 'švedų', 15, 1, 11, 2, 7),
(1112, 'Brėkštanti aušra', 648, '2012-01-09', 'anglų', 20, 1, 6, 18, 1),
(1113, 'Silva rerum', 285, '2013-09-14', 'lietuvių', 10, 1, 4, 20, 2),
(1114, 'Petro imperatorė', 320, '2019-06-11', 'lietuvių', 5, 1, 4, 20, 2),
(1115, 'Kur tas Micius?', 18, '2021-01-04', 'lietuvių', 3, 1, 11, 21, 5),
(1116, 'Ką tau skauda?', 16, '2021-05-14', 'lietuvių', 7, 1, 11, 21, 5),
(1117, 'Žiemos sužadėtiniai', 472, '2021-02-10', 'lietuvių', 4, 1, 8, 22, 5),
(1118, 'Princas ir elgeta', 320, '2021-01-04', 'lietuvių', 11, 1, 8, 23, 4),
(1119, 'If I stay', 240, '2014-07-31', 'anglų', 6, 1, 8, 6, 8),
(1120, 'Where She Went', 300, '2015-03-03', 'anglų', 5, 1, 8, 6, 9),
(1121, 'The Anthropocene Reviewed', 304, '2021-05-18', 'anglų', 16, 1, 8, 4, 8),
(1122, 'Turtles All the Way Down', 303, '2018-09-18', 'anglų', 3, 1, 8, 4, 11),
(1123, 'Paper Towns', 320, '2013-09-14', 'anglų', 1, 1, 6, 4, 10),
(1124, 'Fantastiniai gyvūnai ir kur juos rasti: originalus scenarijus', 296, '2021-02-27', 'lietuvių', 6, 1, 2, 3, 1),
(1125, 'Haris Poteris ir Mirties relikvijos', 598, '2020-04-25', 'lietuvių', 11, 1, 2, 3, 1),
(1126, 'Dievų miškas', 447, '2013-11-15', 'lietuvių', 6, 1, 4, 11, 2),
(1127, 'Romeo ir Džuljeta', 192, '2020-01-28', 'lietuvių', 3, 1, 9, 17, 4),
(1128, 'Hamletas', 240, '2020-04-25', NULL, 7, 1, 9, 17, 4),
(1129, 'Novelės', 78, '2012-04-07', 'lietuvių', 8, 1, 9, 13, 12),
(1130, 'Metamorphosis', 320, '2016-05-26', NULL, 6, 1, 20, 14, 11),
(1131, 'Dėl mūsų likimo ir žvaigždės kaltos', 272, '2013-03-23', 'lietuvių', 5, 1, 22, 4, 1),
(1132, 'Draugystė mainais', 120, '2022-01-11', 'lietuvių', 2, 1, 11, 24, 5);

-- --------------------------------------------------------

--
-- Table structure for table `leidyklos`
--

CREATE TABLE `leidyklos` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `adresas` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `leidyklos`
--

INSERT INTO `leidyklos` (`id`, `pavadinimas`, `adresas`) VALUES
(0, 'Aušra', 'Sp. z o.o. ul. Mickiewicza 23, 16-515 Puńsk POLAND'),
(1, 'Alma littera', 'Ulonų g. 2, Vilnius 08245'),
(2, 'Baltos lankos', 'A. Jakšto g. 5, Vilnius 01105'),
(3, 'Briedis', 'Parodų g. 4, Vilnius 04133'),
(4, 'Obuolys', 'Maironio g. 6-1, LT-44302 Kaunas'),
(5, 'Nieko rimto', 'Dūmų g. 3A, LT-11119, Vilnius'),
(6, 'Eglės leidykla', 'Labrenciškės g. 18, Klaipėda 92287'),
(7, 'Garnelis', 'Vilniaus g. 39, LT-01119 Vilnius'),
(8, 'Random House Children\'s', '1745 Broadway in Manhattan'),
(9, 'LARGE PRINT DISTRIBUTION', 'Argyll St, London W1B 2ER'),
(10, 'Bloomsbury Publishing', ' 1385 Broadway, Fifth Floor, New York, NY 10018 USA'),
(11, 'Penguin Books Ltd (UK)', '20 Vauxhall Bridge Road London, SW1V 2SA'),
(12, 'Žaltvykslė', 'A. Vivulskio g. 7-208, LT-03221 Vilnius'),
(13, 'Aktėja', 'M. Marcinkevičiaus g. 11 LT-08433 Vilnius'),
(14, 'Eugrimas', 'Žalgirio g. 88–303 LT-09303 Vilnius'),
(15, 'Simon & Schuster', '1230 Avenue of the Americas New York'),
(16, 'Pearson Education', 'A. Juozapavičiaus g. 6, Vilnius 09310'),
(17, 'Šviesa', 'Vytauto pr. 29, Kauno m., Kauno m. sav., LT-44352'),
(18, 'Technologija', 'Studentų g. 54, Kaunas'),
(19, 'Lapas', 'K. Kalinausko g. 10-3, Vilnius 03107');

-- --------------------------------------------------------

--
-- Table structure for table `markes`
--

CREATE TABLE `markes` (
  `id` int(11) NOT NULL,
  `pavadinimas` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `markes`
--

INSERT INTO `markes` (`id`, `pavadinimas`) VALUES
(0, 'Skoda'),
(0, 'Opel');

-- --------------------------------------------------------

--
-- Table structure for table `miestas`
--

CREATE TABLE `miestas` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `miestas`
--

INSERT INTO `miestas` (`id`, `pavadinimas`) VALUES
(0, 'Kupiškis'),
(1, 'Vilnius'),
(2, 'Kaunas'),
(3, 'Klaipėda'),
(4, 'Šiauliai'),
(5, 'Panevėžys'),
(6, 'Alytus'),
(7, 'Marijampolė'),
(8, 'Mažeikiai'),
(9, 'Jonava'),
(10, 'Utena'),
(11, 'Kėdainiai'),
(12, 'Tauragė'),
(13, 'Telšiai'),
(14, 'Ukmergė'),
(15, 'Visaginas'),
(16, 'Plungė'),
(17, 'Kretinga'),
(18, 'Palanga'),
(19, 'Radviliškis'),
(20, 'Šilutė');

-- --------------------------------------------------------

--
-- Table structure for table `pareigos`
--

CREATE TABLE `pareigos` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pareigos`
--

INSERT INTO `pareigos` (`id`, `pavadinimas`) VALUES
(0, 'Praktikantas'),
(1, 'Vadovas/direktorius'),
(2, 'Pavaduotoja'),
(3, 'Administratorė'),
(4, 'Bibliotekininkė');

-- --------------------------------------------------------

--
-- Table structure for table `paslaugu_tipai`
--

CREATE TABLE `paslaugu_tipai` (
  `id_paslaugu_tipai` int(11) NOT NULL,
  `name` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `paslaugu_tipai`
--

INSERT INTO `paslaugu_tipai` (`id_paslaugu_tipai`, `name`) VALUES
(0, 'pasiimimas'),
(1, 'grazinimas'),
(2, 'pratesimas');

-- --------------------------------------------------------

--
-- Table structure for table `skaitytojai`
--

CREATE TABLE `skaitytojai` (
  `id` int(11) NOT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `pavarde` varchar(255) DEFAULT NULL,
  `gimimo_data` date DEFAULT NULL,
  `telefonas` int(11) DEFAULT NULL,
  `el_pastas` varchar(255) DEFAULT NULL,
  `adresas` varchar(255) DEFAULT NULL,
  `kategorija` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `skaitytojai`
--

INSERT INTO `skaitytojai` (`id`, `vardas`, `pavarde`, `gimimo_data`, `telefonas`, `el_pastas`, `adresas`, `kategorija`) VALUES
(0, 'Kotryna', 'Martinaitė', '2016-02-11', 862512334, 'kotryna.martinaite@gmail.com', 'Kniaudiškių 56 g., 25-11', 1),
(1, 'Simona', 'Ragauskaitė', '2000-12-20', 865215915, 'simona.ragauskaite@gmail.com', 'Kovo 11-osios, 20-21, Kaunas', 2),
(2, 'Lina', 'Ličkutė', '2015-06-30', 865555915, 'lina.lickute@gmail.com', 'Laivų g. 52, 3, Nida', 1),
(3, 'Ieva', 'Mackevičienė', '1990-11-08', 865219995, 'ieva.mackeviciene@gmail.com', 'Užupio 72 g., 5, Vilnius', 3),
(4, 'Jonas', 'Ramanauskas', '2001-12-12', 862255915, 'jonas.ramanauskas@gmail.com', 'Beržų g., 7-81, Panevėžys', 2),
(5, 'Matas', 'Mikaitis', '1970-08-09', 865299999, 'matas.mikaitis@gmail.com', 'Lokių g., 8, Radviliškis', 3),
(6, 'Luka', 'Lukšaitė', '2006-12-20', 865211115, 'luka.luksaite@gmail.com', 'Liepų g. 16-17, Klaipėda', 2),
(7, 'Kipras', 'Plekšra', '2018-08-02', 865559915, 'kipras.pleksra@gmail.com', NULL, 1),
(8, 'Tadas', 'Pauliukonis', '2017-02-09', 862512541, 'tadas.pauliukonis@gmail.com', 'Sakūrų 76g, 23-5', 1),
(9, 'Vidmantas', 'Krantonis', '1950-02-20', 862512594, 'vidmantas.krantonis@gmail.com', 'Lukšio 5 g., 63', 3),
(10, 'Ugnė', 'Ribikauskaitė', '1992-08-03', 862566694, 'ugne.ribikauskaite@gmail.com', 'Pagiežu 5 g., 6', 3),
(11, 'Domas', 'Litkus', '1982-08-03', 861111194, 'domas.litkus@gmail.com', 'Grybų g. 7', 3),
(12, 'Ainis', 'Krikščiūnas', '1991-11-11', 862222594, 'ainis.kriksciunas@gmail.com', 'Vilniaus g. 5', 3),
(13, 'Lukrecija', 'Plukstienė', '1950-02-20', 862512444, 'lukrecija.plukstiene@gmail.com', 'Smėlynės 81 g. 15-6', 3),
(14, 'Marija', 'Vaišvilaitė', '2001-05-27', 862512599, 'marija.vaisvilaite@gmail.com', 'Upytės g. 52', 2),
(15, 'Kornelija', 'Linavičiūtė', '2017-02-09', 862594355, 'kornelija.linaviciute@gmail.com', 'Plukšio 72g., 9-9', 1),
(16, 'Aurelija', 'Mitkuvienė', '1982-07-06', 862599995, 'aurelija.mitkuviene@gmail.com', 'Musių 72 g., 5-1', 3),
(17, 'Lukas', 'Mariukevičius', '1996-05-19', 862224355, 'lukas.mariukevicius@gmail.com', 'Liepų 95 g.', 3),
(18, 'Arnas', 'Prašnionis', '2015-12-20', 863334355, 'arnas.prasnionis@gmail.com', 'Kurpių 72 g.', 1),
(19, 'Kasparas', 'Linkus', '2002-08-28', 862594111, 'kasparas.linkus@gmail.com', 'Breslaujos 56 g., 20-11', 2),
(20, 'Nojus', 'Paškevičius', '2016-03-01', 869860175, 'nojus.paskevicius@gmail.com', 'Vilkaviskio 82-6, Vilnius', 0),
(21, 'Matilda', 'Liaubšienė', '1950-05-09', 869658975, 'matilda.liaubsiene@gmail.com', 'Kanklių 72 g. Panevėžys', 3);

-- --------------------------------------------------------

--
-- Table structure for table `tipai`
--

CREATE TABLE `tipai` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tipai`
--

INSERT INTO `tipai` (`id`, `pavadinimas`) VALUES
(0, 'Universalioji'),
(1, 'Suaugusių'),
(2, 'Vaikų'),
(3, 'Viešoji'),
(4, 'Specialioji');

-- --------------------------------------------------------

--
-- Table structure for table `zanrai`
--

CREATE TABLE `zanrai` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `zanrai`
--

INSERT INTO `zanrai` (`id`, `pavadinimas`) VALUES
(0, 'Filosofijos'),
(1, 'Detektyvas'),
(2, 'Fantastika'),
(3, 'Distopijos ir utopijos'),
(4, 'Istoriniai romanai'),
(5, 'Siaubo romanai'),
(6, 'Romantika, meilės romanai'),
(7, 'Trileriai'),
(8, 'Šiuolaikinė grožinė literatūra'),
(9, 'Klasika'),
(10, 'Grafinės novelės - komiksai'),
(11, 'Vaikų literatūra'),
(12, 'Biografijos ir autobiografijos'),
(13, 'Maisto gamybos'),
(14, 'Istorijos'),
(15, 'Saviugdos'),
(16, 'Meno'),
(17, 'Kelionių'),
(18, 'Religijos'),
(19, 'Sveikatos'),
(20, 'Psicholiginis'),
(21, 'Realistinė literatūra'),
(22, 'Jaunimo literatūra');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `autoriai`
--
ALTER TABLE `autoriai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `bibliotekos`
--
ALTER TABLE `bibliotekos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `yra` (`fk_tipasid_tipas`),
  ADD KEY `randasi` (`fk_miestasid_miestas`);

--
-- Indexes for table `busenos`
--
ALTER TABLE `busenos`
  ADD PRIMARY KEY (`id_busenos`);

--
-- Indexes for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD PRIMARY KEY (`tabelio_nr`),
  ADD KEY `dirba` (`fk_bibliotekaid_biblioteka`),
  ADD KEY `atlieka` (`fk_pareigosid_pareigos`);

--
-- Indexes for table `kategoriju_tipai`
--
ALTER TABLE `kategoriju_tipai`
  ADD PRIMARY KEY (`id_kategoriju_tipai`);

--
-- Indexes for table `knygos`
--
ALTER TABLE `knygos`
  ADD PRIMARY KEY (`ISBN`),
  ADD KEY `busena` (`busena`),
  ADD KEY `turi` (`fk_zanrasid_zanras`),
  ADD KEY `paraso` (`fk_autoriusid_autorius`),
  ADD KEY `isleidzia` (`fk_leidyklaid_leidykla`);

--
-- Indexes for table `leidyklos`
--
ALTER TABLE `leidyklos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `miestas`
--
ALTER TABLE `miestas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `pareigos`
--
ALTER TABLE `pareigos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `paslaugu_tipai`
--
ALTER TABLE `paslaugu_tipai`
  ADD PRIMARY KEY (`id_paslaugu_tipai`);

--
-- Indexes for table `skaitytojai`
--
ALTER TABLE `skaitytojai`
  ADD PRIMARY KEY (`id`),
  ADD KEY `kategorija` (`kategorija`);

--
-- Indexes for table `tipai`
--
ALTER TABLE `tipai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `zanrai`
--
ALTER TABLE `zanrai`
  ADD PRIMARY KEY (`id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bibliotekos`
--
ALTER TABLE `bibliotekos`
  ADD CONSTRAINT `randasi` FOREIGN KEY (`fk_miestasid_miestas`) REFERENCES `miestas` (`id`),
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_tipasid_tipas`) REFERENCES `tipai` (`id`);

--
-- Constraints for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD CONSTRAINT `atlieka` FOREIGN KEY (`fk_pareigosid_pareigos`) REFERENCES `pareigos` (`id`),
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_bibliotekaid_biblioteka`) REFERENCES `bibliotekos` (`id`);

--
-- Constraints for table `knygos`
--
ALTER TABLE `knygos`
  ADD CONSTRAINT `isleidzia` FOREIGN KEY (`fk_leidyklaid_leidykla`) REFERENCES `leidyklos` (`id`),
  ADD CONSTRAINT `knygos_ibfk_1` FOREIGN KEY (`busena`) REFERENCES `busenos` (`id_busenos`),
  ADD CONSTRAINT `paraso` FOREIGN KEY (`fk_autoriusid_autorius`) REFERENCES `autoriai` (`id`),
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_zanrasid_zanras`) REFERENCES `zanrai` (`id`);

--
-- Constraints for table `skaitytojai`
--
ALTER TABLE `skaitytojai`
  ADD CONSTRAINT `skaitytojai_ibfk_1` FOREIGN KEY (`kategorija`) REFERENCES `kategoriju_tipai` (`id_kategoriju_tipai`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
