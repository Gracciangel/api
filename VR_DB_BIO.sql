-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 30-05-2024 a las 01:24:52
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `VR_DB`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `TEAM_BLUE`
--

CREATE TABLE `TEAM_BLUE` (
  `ID` int(11) NOT NULL,
  `COMPLETE` int(2) DEFAULT NULL,
  `NICK_1` varchar(255) DEFAULT NULL,
  `NICK_2` varchar(255) DEFAULT NULL,
  `NICK_3` varchar(255) DEFAULT NULL,
  `NICK_4` varchar(255) DEFAULT NULL,
  `NICK_5` varchar(255) DEFAULT NULL,
  `PARTIDA_ID` int(11) DEFAULT NULL,
  `TEAM` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `TEAM_BLUE`
--

INSERT INTO `TEAM_BLUE` (`ID`, `COMPLETE`, `NICK_1`, `NICK_2`, `NICK_3`, `NICK_4`, `NICK_5`, `PARTIDA_ID`, `TEAM`) VALUES
(1, 1, 'perla', NULL, NULL, NULL, NULL, 31, 'BLUE'),
(2, 1, 'julieta', NULL, NULL, NULL, NULL, 32, 'BLUE'),
(3, 1, 'valentina', NULL, NULL, NULL, NULL, 33, 'BLUE'),
(4, 1, 'angel1988', NULL, NULL, NULL, NULL, 34, 'BLUE'),
(5, 0, '', '', '', '', '', 35, 'BLUE');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `TEAM_GREEN`
--

CREATE TABLE `TEAM_GREEN` (
  `ID` int(11) NOT NULL,
  `COMPLETE` int(2) DEFAULT NULL,
  `NICK_1` varchar(250) DEFAULT NULL,
  `NICK_2` varchar(250) DEFAULT NULL,
  `NICK_3` varchar(250) DEFAULT NULL,
  `NICK_4` varchar(250) DEFAULT NULL,
  `NICK_5` varchar(250) DEFAULT NULL,
  `PARTIDA_ID` int(11) DEFAULT NULL,
  `TEAM` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `TEAM_GREEN`
--

INSERT INTO `TEAM_GREEN` (`ID`, `COMPLETE`, `NICK_1`, `NICK_2`, `NICK_3`, `NICK_4`, `NICK_5`, `PARTIDA_ID`, `TEAM`) VALUES
(1, 1, 'tomas', NULL, NULL, NULL, NULL, 31, 'GREEN'),
(2, 1, 'pipo', NULL, NULL, NULL, NULL, 32, 'GREEN'),
(3, 1, 'daniela', NULL, NULL, NULL, NULL, 33, 'GREEN'),
(4, 1, 'roberto', NULL, NULL, NULL, NULL, 34, 'GREEN'),
(5, 0, '', '', '', '', '', 35, 'GREEN');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `TEAM_ORANGE`
--

CREATE TABLE `TEAM_ORANGE` (
  `ID` int(11) NOT NULL,
  `COMPLETE` int(2) DEFAULT NULL,
  `NICK_1` varchar(250) DEFAULT NULL,
  `NICK_2` varchar(250) DEFAULT NULL,
  `NICK_3` varchar(250) DEFAULT NULL,
  `NICK_4` varchar(250) DEFAULT NULL,
  `NICK_5` varchar(250) DEFAULT NULL,
  `PARTIDA_ID` int(11) DEFAULT NULL,
  `TEAM` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `TEAM_ORANGE`
--

INSERT INTO `TEAM_ORANGE` (`ID`, `COMPLETE`, `NICK_1`, `NICK_2`, `NICK_3`, `NICK_4`, `NICK_5`, `PARTIDA_ID`, `TEAM`) VALUES
(1, 1, 'pepe', NULL, NULL, NULL, NULL, 31, 'ORANGE'),
(2, 1, 'perla', NULL, NULL, NULL, NULL, 32, 'ORANGE'),
(3, 1, 'pipo', NULL, NULL, NULL, NULL, 33, 'ORANGE'),
(4, 1, 'angel', NULL, NULL, NULL, NULL, 34, 'ORANGE'),
(5, 0, '', '', '', '', '', 35, 'ORANGE');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `TEAM_PINK`
--

CREATE TABLE `TEAM_PINK` (
  `ID` int(11) NOT NULL,
  `COMPLETE` int(2) DEFAULT NULL,
  `NICK_1` varchar(250) DEFAULT NULL,
  `NICK_2` varchar(250) DEFAULT NULL,
  `NICK_3` varchar(250) DEFAULT NULL,
  `NICK_4` varchar(250) DEFAULT NULL,
  `NICK_5` varchar(250) DEFAULT NULL,
  `TEAM` varchar(50) DEFAULT NULL,
  `PARTIDA_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `TEAM_PINK`
--

INSERT INTO `TEAM_PINK` (`ID`, `COMPLETE`, `NICK_1`, `NICK_2`, `NICK_3`, `NICK_4`, `NICK_5`, `TEAM`, `PARTIDA_ID`) VALUES
(1, 1, 'pepe', NULL, NULL, NULL, NULL, 'PINK', 31),
(2, 1, 'valentina', NULL, NULL, NULL, NULL, 'PINK', 32),
(3, 1, 'julieta', NULL, NULL, NULL, NULL, 'PINK', 33),
(4, 1, 'tomas', NULL, NULL, NULL, NULL, 'PINK', 34),
(5, 0, '', '', '', '', '', 'PINK', 35);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `TEAM_RED`
--

CREATE TABLE `TEAM_RED` (
  `ID` int(11) NOT NULL,
  `COMPLETE` int(2) DEFAULT NULL,
  `NICK_1` varchar(250) DEFAULT NULL,
  `NICK_2` varchar(250) DEFAULT NULL,
  `NICK_3` varchar(250) DEFAULT NULL,
  `NICK_4` varchar(250) DEFAULT NULL,
  `NICK_5` varchar(250) DEFAULT NULL,
  `TEAM` varchar(50) DEFAULT NULL,
  `PARTIDA_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `TEAM_RED`
--

INSERT INTO `TEAM_RED` (`ID`, `COMPLETE`, `NICK_1`, `NICK_2`, `NICK_3`, `NICK_4`, `NICK_5`, `TEAM`, `PARTIDA_ID`) VALUES
(1, 1, 'angel', 'pipo', NULL, NULL, NULL, 'RED', 31),
(2, 1, 'angel', NULL, NULL, NULL, NULL, 'RED', 32),
(3, 1, 'angel', NULL, NULL, NULL, NULL, 'RED', 33),
(4, 1, 'angel', NULL, NULL, NULL, NULL, 'RED', 34),
(5, 1, 'angel', NULL, NULL, NULL, NULL, 'RED', 35);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `TEAM_YELLOW`
--

CREATE TABLE `TEAM_YELLOW` (
  `ID` int(11) NOT NULL,
  `COMPLETE` int(2) DEFAULT NULL,
  `NICK_1` varchar(250) DEFAULT NULL,
  `NICK_2` varchar(250) DEFAULT NULL,
  `NICK_3` varchar(250) DEFAULT NULL,
  `NICK_4` varchar(250) DEFAULT NULL,
  `NICK_5` varchar(250) DEFAULT NULL,
  `PARTIDA_ID` int(11) DEFAULT NULL,
  `TEAM` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `TEAM_YELLOW`
--

INSERT INTO `TEAM_YELLOW` (`ID`, `COMPLETE`, `NICK_1`, `NICK_2`, `NICK_3`, `NICK_4`, `NICK_5`, `PARTIDA_ID`, `TEAM`) VALUES
(1, 1, 'ubaldo', NULL, NULL, NULL, NULL, 31, 'YELLOW'),
(2, 1, 'daniela', NULL, NULL, NULL, NULL, 32, 'YELLOW'),
(3, 1, 'angel', NULL, NULL, NULL, NULL, 33, 'YELLOW'),
(4, 1, 'ubaldo', NULL, NULL, NULL, NULL, 34, 'YELLOW'),
(5, 0, '', '', '', '', '', 35, 'YELLOW');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `VR_DATOS_USUARIOS`
--

CREATE TABLE `VR_DATOS_USUARIOS` (
  `NICKNAME` varchar(150) NOT NULL,
  `DOCUMENTO` varchar(20) DEFAULT NULL,
  `NOMBRE` varchar(100) DEFAULT NULL,
  `APELLIDO` varchar(100) DEFAULT NULL,
  `EDAD` int(2) DEFAULT NULL,
  `MAIL` varchar(255) DEFAULT NULL,
  `COLEGIO` varchar(255) DEFAULT NULL,
  `FACEBOOK` varchar(255) DEFAULT NULL,
  `INSTAGRAM` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `VR_DATOS_USUARIOS`
--

INSERT INTO `VR_DATOS_USUARIOS` (`NICKNAME`, `DOCUMENTO`, `NOMBRE`, `APELLIDO`, `EDAD`, `MAIL`, `COLEGIO`, `FACEBOOK`, `INSTAGRAM`) VALUES
('aelos', ' 344952911', 'pedro', 'paz', 14, 'paz@gmail.com', 'no', 'no', 'no'),
('alberto', '', '', '', 0, '', '', '', ''),
('alguien', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('angel', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('angel1988', '1234567890', 'angel#!', 'mugracci', 14, 'angel@gmail.com', 'noanoadncw', 'naocnsiovsvs', 'nancalclkacn'),
('angelito', '', '', '', 0, '', '', '', ''),
('angelq', '', '', '', 0, '', '', '', ''),
('angl001', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('ariel', '', '', '', 0, '', '', '', ''),
('axel', '', '', '', 0, '', '', '', ''),
('carlos009', '', '', '', 0, '', '', '', ''),
('claudio', '', '', '', 0, '', '', '', ''),
('daniela', '', '', '', 0, '', '', '', ''),
('fede', '', '', '', 0, '', '', '', ''),
('federico', '', '', '', 0, '', '', '', ''),
('felipe', '', '', '', 0, '', '', '', ''),
('joaquin', '', '', '', 0, '', '', '', ''),
('juan', '', '', '', 0, '', '', '', ''),
('juan carlos', '', '', '', 0, '', '', '', ''),
('julian', '', '', '', 0, '', '', '', ''),
('julieta', '', '', '', 0, '', '', '', ''),
('lorena', '', '', '', 0, '', '', '', ''),
('mariano', '', '', '', 0, '', '', '', ''),
('martin', '3391356', 'Angel', 'Mugracci', 13, 'angelgracci14@gmail.com', 'no', 'no', 'no'),
('matias', '', '', '', 0, '', '', '', ''),
('nirle', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('pablo', '', '', '', 0, '', '', '', ''),
('pepe', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('perla', '', '', '', 0, '', '', '', ''),
('perto', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('pipo', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('porta', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' '),
('roberto', '', '', '', 0, '', '', '', ''),
('rodlfo', '', '', '', 0, '', '', '', ''),
('rodolfo', '', '', '', 0, '', '', '', ''),
('string', 'string', 'string', 'string', 0, 'string', 'string', 'string', 'string'),
('tomas', '', '', '', 0, '', '', '', ''),
('tomas_0031', '', '', '', 0, '', '', '', ''),
('tomi', ' 33913914', 'tomas', 'perez', 13, 'tomi@gmail.com', 'no', 'no', 'no'),
('tomi_001', '', '', '', 0, '', '', '', ''),
('ubaldo', '', '', '', 0, '', '', '', ''),
('ublado', '', '', '', 0, '', '', '', ''),
('ublado_001', '', '', '', 0, '', '', '', ''),
('valentina', '', '', '', 0, '', '', '', ''),
('yirteb', ' ', ' ', ' ', 0, ' ', ' ', ' ', ' ');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `VR_PARTIDA`
--

CREATE TABLE `VR_PARTIDA` (
  `ID_PARTIDA` int(11) NOT NULL,
  `STATE` int(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `VR_PARTIDA`
--

INSERT INTO `VR_PARTIDA` (`ID_PARTIDA`, `STATE`) VALUES
(31, 2),
(32, 2),
(33, 2),
(34, 2),
(35, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `VR_SCORING_USUARIO`
--

CREATE TABLE `VR_SCORING_USUARIO` (
  `SCORING` int(5) DEFAULT NULL,
  `NICKNAME` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `VR_SCORING_USUARIO`
--

INSERT INTO `VR_SCORING_USUARIO` (`SCORING`, `NICKNAME`) VALUES
(0, 'angel1988'),
(0, 'nirle'),
(0, 'aelos'),
(0, 'angel'),
(0, 'pipo'),
(0, 'pepe'),
(0, 'angl001'),
(0, 'perto'),
(0, 'yirteb'),
(0, 'porta'),
(0, 'alguien'),
(0, 'string'),
(0, 'martin'),
(0, 'federico'),
(0, 'tomas'),
(0, 'felipe'),
(0, 'perla'),
(0, 'matias'),
(0, 'angelq'),
(0, 'juan'),
(0, 'tomi'),
(0, 'carlos009'),
(0, 'roberto'),
(0, 'mariano'),
(0, 'daniela'),
(0, 'julieta'),
(0, 'valentina'),
(0, 'axel'),
(0, 'julian'),
(0, 'fede'),
(0, 'lorena'),
(0, 'alberto'),
(0, 'rodolfo'),
(0, 'juan carlos'),
(0, 'rodlfo'),
(0, 'joaquin'),
(0, 'tomi_001'),
(0, 'ublado'),
(0, 'ubaldo'),
(0, 'ublado_001'),
(0, 'ariel'),
(0, 'pablo'),
(0, 'angelito'),
(0, 'claudio'),
(0, 'tomas_0031');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `TEAM_BLUE`
--
ALTER TABLE `TEAM_BLUE`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `PARTIDA_ID` (`PARTIDA_ID`);

--
-- Indices de la tabla `TEAM_GREEN`
--
ALTER TABLE `TEAM_GREEN`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `PARTIDA_ID` (`PARTIDA_ID`);

--
-- Indices de la tabla `TEAM_ORANGE`
--
ALTER TABLE `TEAM_ORANGE`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `PARTIDA_ID` (`PARTIDA_ID`);

--
-- Indices de la tabla `TEAM_PINK`
--
ALTER TABLE `TEAM_PINK`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `PARTIDA_ID` (`PARTIDA_ID`);

--
-- Indices de la tabla `TEAM_RED`
--
ALTER TABLE `TEAM_RED`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FK_PARTIDA_ID` (`PARTIDA_ID`);

--
-- Indices de la tabla `TEAM_YELLOW`
--
ALTER TABLE `TEAM_YELLOW`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `PARTIDA_ID` (`PARTIDA_ID`);

--
-- Indices de la tabla `VR_DATOS_USUARIOS`
--
ALTER TABLE `VR_DATOS_USUARIOS`
  ADD PRIMARY KEY (`NICKNAME`);

--
-- Indices de la tabla `VR_PARTIDA`
--
ALTER TABLE `VR_PARTIDA`
  ADD PRIMARY KEY (`ID_PARTIDA`);

--
-- Indices de la tabla `VR_SCORING_USUARIO`
--
ALTER TABLE `VR_SCORING_USUARIO`
  ADD UNIQUE KEY `NICK_NAME` (`NICKNAME`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `TEAM_BLUE`
--
ALTER TABLE `TEAM_BLUE`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `TEAM_GREEN`
--
ALTER TABLE `TEAM_GREEN`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `TEAM_ORANGE`
--
ALTER TABLE `TEAM_ORANGE`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `TEAM_PINK`
--
ALTER TABLE `TEAM_PINK`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `TEAM_RED`
--
ALTER TABLE `TEAM_RED`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `TEAM_YELLOW`
--
ALTER TABLE `TEAM_YELLOW`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `VR_PARTIDA`
--
ALTER TABLE `VR_PARTIDA`
  MODIFY `ID_PARTIDA` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `TEAM_BLUE`
--
ALTER TABLE `TEAM_BLUE`
  ADD CONSTRAINT `team_blue_ibfk_1` FOREIGN KEY (`PARTIDA_ID`) REFERENCES `VR_PARTIDA` (`ID_PARTIDA`);

--
-- Filtros para la tabla `TEAM_GREEN`
--
ALTER TABLE `TEAM_GREEN`
  ADD CONSTRAINT `team_green_ibfk_1` FOREIGN KEY (`PARTIDA_ID`) REFERENCES `VR_PARTIDA` (`ID_PARTIDA`);

--
-- Filtros para la tabla `TEAM_ORANGE`
--
ALTER TABLE `TEAM_ORANGE`
  ADD CONSTRAINT `team_orange_ibfk_1` FOREIGN KEY (`PARTIDA_ID`) REFERENCES `VR_PARTIDA` (`ID_PARTIDA`);

--
-- Filtros para la tabla `TEAM_PINK`
--
ALTER TABLE `TEAM_PINK`
  ADD CONSTRAINT `team_pink_ibfk_1` FOREIGN KEY (`PARTIDA_ID`) REFERENCES `VR_PARTIDA` (`ID_PARTIDA`);

--
-- Filtros para la tabla `TEAM_RED`
--
ALTER TABLE `TEAM_RED`
  ADD CONSTRAINT `FK_PARTIDA_ID` FOREIGN KEY (`PARTIDA_ID`) REFERENCES `VR_PARTIDA` (`ID_PARTIDA`);

--
-- Filtros para la tabla `TEAM_YELLOW`
--
ALTER TABLE `TEAM_YELLOW`
  ADD CONSTRAINT `team_yellow_ibfk_1` FOREIGN KEY (`PARTIDA_ID`) REFERENCES `VR_PARTIDA` (`ID_PARTIDA`);

--
-- Filtros para la tabla `VR_SCORING_USUARIO`
--
ALTER TABLE `VR_SCORING_USUARIO`
  ADD CONSTRAINT `vr_scoring_usuario_ibfk_1` FOREIGN KEY (`NICKNAME`) REFERENCES `VR_DATOS_USUARIOS` (`NICKNAME`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
