create or replace NONEDITIONABLE PACKAGE BODY      PckgPersons AS

   PROCEDURE GetPersons (personsCursor IN OUT SYS_REFCURSOR) AS
      BEGIN
         OPEN personsCursor FOR select person_id, first_name, last_name from persons;           
      END GetPersons;

   PROCEDURE InsertPerson (first_name VARCHAR2, last_name VARCHAR2) AS
      BEGIN
         INSERT INTO CWEB.persons (first_name, last_name) VALUES (first_name, last_name);            
      END InsertPerson;

   PROCEDURE DeletePerson (personid NUMBER) AS
      BEGIN
         DELETE FROM CWEB.persons WHERE person_id = personid;
      END DeletePerson;      

   PROCEDURE UpdatePerson (firstName VARCHAR2, lastName VARCHAR, personid NUMBER) AS
      BEGIN
         UPDATE CWEB.persons 
            SET first_name = firstName, 
                last_name = lastName 
         WHERE person_id = personid;
      END UpdatePerson;        

END PckgPersons;