CREATE PROCEDURE [dbo].[GET_STUDENTS_WITH_GRADES_GREATER_THAN]
@betyg INT=92
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT CONCAT(elev.lastname, ' ', elev.firstname) AS namn
    FROM   ([dbo].[Elev] AS elev
            INNER JOIN
            [dbo].[Elev_Betyg] AS betyg
            ON elev.id = betyg.elev_id)
    WHERE  betyg.betyg > @betyg;
END