-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Апр 13 2021 г., 14:45
-- Версия сервера: 10.4.14-MariaDB
-- Версия PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `storage`
--

-- --------------------------------------------------------

--
-- Структура таблицы `postavka`
--

CREATE TABLE `postavka` (
  `pc` int(11) NOT NULL,
  `pr` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `postavka`
--

INSERT INTO `postavka` (`pc`, `pr`) VALUES
(1, 2),
(1, 3),
(1, 5),
(2, 1),
(2, 3);

-- --------------------------------------------------------

--
-- Структура таблицы `postavshik`
--

CREATE TABLE `postavshik` (
  `pc` int(11) NOT NULL,
  `pc_name` text NOT NULL,
  `phone` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `postavshik`
--

INSERT INTO `postavshik` (`pc`, `pc_name`, `phone`) VALUES
(1, 'Ensebaev', 2147483647),
(2, 'PostavshikBebri', 333333);

-- --------------------------------------------------------

--
-- Структура таблицы `product`
--

CREATE TABLE `product` (
  `pr` int(11) NOT NULL,
  `pr_name` varchar(50) DEFAULT NULL,
  `price` bigint(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `product`
--

INSERT INTO `product` (`pr`, `pr_name`, `price`) VALUES
(1, 'Potato', 120),
(2, 'Carrot', 56),
(3, 'Lemon', 47),
(4, 'Sugar', 71),
(5, 'Tomato', 38);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `postavka`
--
ALTER TABLE `postavka`
  ADD PRIMARY KEY (`pc`,`pr`),
  ADD KEY `pr` (`pr`);

--
-- Индексы таблицы `postavshik`
--
ALTER TABLE `postavshik`
  ADD PRIMARY KEY (`pc`);

--
-- Индексы таблицы `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`pr`);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `postavka`
--
ALTER TABLE `postavka`
  ADD CONSTRAINT `postavka_ibfk_1` FOREIGN KEY (`pr`) REFERENCES `product` (`pr`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `postavka_ibfk_2` FOREIGN KEY (`pc`) REFERENCES `postavshik` (`pc`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
