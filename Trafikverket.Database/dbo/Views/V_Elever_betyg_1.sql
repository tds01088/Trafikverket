CREATE VIEW dbo.V_Elever_betyg
AS
SELECT        elev.firstname, elev.lastname, betyg.betyg, projekt.title
FROM            dbo.Elev AS elev FULL OUTER JOIN
                         dbo.Elev_Betyg AS betyg ON elev.id = betyg.elev_id FULL OUTER JOIN
                         dbo.Elev_projekt AS projekt ON elev.id = projekt.elev_id
