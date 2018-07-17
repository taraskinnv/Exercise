#create database BD_local_file;
use BD_local_file;



/*CREATE TABLE Locate_language (
    id INT PRIMARY KEY AUTO_INCREMENT,
    languag VARCHAR(255) NOT NULL
);


CREATE TABLE Word (
    id INT PRIMARY KEY AUTO_INCREMENT,
    word_slovo VARCHAR(255) NOT NULL,
    id_loc INT REFERENCES Locate_language (id)
);

 
CREATE TABLE Translate (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_loc INT REFERENCES Locate_language (id),
    id_word INT REFERENCES Word (id),
    id_translate_word INT REFERENCES Word (id),
    count_trans INT
);
*/

# поиск Translate.id
/*DELIMITER $$
CREATE PROCEDURE Word_search_id(in word_search nvarchar(255))
BEGIN
select word.id
from word
where word.word_slovo = word_search;
END $$
DELIMITER ;
*/

# доделать
/*
DELIMITER $$
CREATE PROCEDURE Word_tr(id_word int, lang nvarchar(255))
BEGIN
select word.word_slovo
from word
join translate on translate.id_translate_word = word.id and translate.id_word = id_word
join locate_language on locate_language.id = word.id_loc and locate_language.languag = lang;
END $$
DELIMITER ;
*/

/*
DELIMITER $$
CREATE PROCEDURE language_id(in lang nvarchar(255))
BEGIN
select locate_language.id
from locate_language
where locate_language.languag = lang;
END $$
DELIMITER ;
*/

/*
DELIMITER $$
CREATE PROCEDURE Add_word( lang_id int, word nvarchar(255))
BEGIN
insert word(word.word_slovo,word.id_loc)
values(word,lang_id);
END $$
DELIMITER ;
*/

/*
DELIMITER $$
CREATE PROCEDURE Add_transl( lang_id int, word_id int, transl_id int)
BEGIN
insert translate(translate.id_loc, translate.id_word, translate.id_translate_word, translate.count_trans)
values(lang_id, word_id, transl_id, 1);
END $$
DELIMITER ;
*/

/*
DELIMITER $$
CREATE PROCEDURE search_trans_id(lang_lang nvarchar(255), id_word int, transl_id int)
BEGIN
select translate.id
from word
join translate on translate.id_translate_word = word.id and translate.id_word = id_word and translate.id_translate_word = transl_id
join locate_language on locate_language.id = word.id_loc and locate_language.languag = lang_lang;
END $$
DELIMITER ;
*/

/*
DELIMITER $$
CREATE PROCEDURE Add_count_trans(id int)
BEGIN
update translate
set translate.count_trans = translate.count_trans + 1
where translate.id = id;
END $$
DELIMITER ;
*/

#бобавление языков
/*
insert locate_language (languag)
value('en');
*/

sele