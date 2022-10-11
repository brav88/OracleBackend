create or replace NONEDITIONABLE PACKAGE      PckgPersons AS
   PROCEDURE InsertPerson (first_name VARCHAR2, last_name VARCHAR2);
   PROCEDURE DeletePerson (personid NUMBER);
   PROCEDURE UpdatePerson (firstName VARCHAR2, lastName VARCHAR, personid NUMBER);
   PROCEDURE GetPersons (personsCursor IN OUT SYS_REFCURSOR);
END PckgPersons;