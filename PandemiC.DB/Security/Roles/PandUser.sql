﻿CREATE ROLE [PandUser]
GO

GRANT SELECT, EXECUTE ON SCHEMA::PandUser To PandUser
GO

ALTER ROLE [PandUser]
ADD MEMBER [RegUser]
GO
