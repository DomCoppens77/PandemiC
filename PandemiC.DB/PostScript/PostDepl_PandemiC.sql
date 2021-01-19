/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

exec [PandUser].[DCOSP_AddUser] @Email = 'zecoop@gmail.com', @NatRegNbr = '19771107139597', @Passwd = 'Test1234=', @FirstName = 'Dominique', @LastName = 'Coppens';
exec [PandUser].[DCOSP_AddUser] @Email = 'gigicoop@hotmail.com', @NatRegNbr = '19450618140589', @Passwd = 'Test1234=', @FirstName = 'Gilbert', @LastName = 'Coppens';
exec [PandUser].[DCOSP_AddUser] @Email = 'cocobobo@gmail.com', @NatRegNbr = '19471108150002', @Passwd = 'Test1234=', @FirstName = 'Colette', @LastName = 'Boumont';
exec [PandUser].[DCOSP_AddUser] @Email = 'cyanure17@gmail.com', @NatRegNbr = '19750817150001', @Passwd = 'Test1234=', @FirstName = 'Isabelle', @LastName = 'Loubris';

exec [PandUser].[DCOSP_UpdUser] @Id = 1 , @Email = 'zecoop@gmail.com', @NatRegNbr = '19771107139597', @LastName = 'Coppens',@FirstName = 'Dominique', @UserStatus =0;

exec [PandUser].[DCOSP_AddCtry] @ISO = N'BE', @Ctry = N'Belgium', @IsEU = 1;
exec [PandUser].[DCOSP_AddCtry] @ISO = N'FR', @Ctry = N'France',  @IsEU = 1;


exec [PandUser].[DCOSP_AddResto] 
	 @VAT       = N'A123456789'
	,@Name      = N'Athena'  
	,@Address1  = N''  
	,@Address2  = N''  
	,@Zip       = N'6000'  
	,@City      = N'Charleroi'  
	,@Country   = N'BE'  
	,@Email     = N''  
	,@Closed    = 0;
exec [PandUser].[DCOSP_AddResto] 
	 @VAT       = N'B123456789'
	,@Name      = N'Au vieux Spijtigen Duivel'  
	,@Address1  = N'Chaussee d Alsemberg 621'  
	,@Address2  = N''  
	,@Zip       = N'1180'  
	,@City      = N'Uccle'  
	,@Country   = N'BE'  
	,@Email     = N''  
	,@Closed    = 0;
exec [PandUser].[DCOSP_AddResto] 
	 @VAT       = N'C123456789'
	,@Name      = N'Schievelavabo Uccle'  
	,@Address1  = N'Egide Van Ophemstraat 20'  
	,@Address2  = N''  
	,@Zip       = N'1180'  
	,@City      = N'Uccle'  
	,@Country   = N'BE'  
	,@Email     = N''  
	,@Closed    = 0; 

exec [PandUser].[DCOSP_AddResto] 
	 @VAT       = N'D123456789'
	,@Name      = N'Délices de Sicile'  
	,@Address1  = N'Rue De Beaumont, 42'  
	,@Address2  = N''  
	,@Zip       = N'59870'  
	,@City      = N'Marchienne'  
	,@Country   = N'BE'  
	,@Email     = N''  
	,@Closed    = 0;

exec [PandUser].[DCOSP_AddTimeLine]
	 @UserId       = 1
	,@RestaurantId = 1
	,@DinerDate    = '2020-07-04'
	,@NbrGuests    = 2;

exec [PandUser].[DCOSP_AddTimeLine]
	 @UserId       = 1
	,@RestaurantId = 2
	,@DinerDate    = '2020-07-05'
	,@NbrGuests    = 6;

exec [PandUser].[DCOSP_AddTimeLine]
	 @UserId       = 4
	,@RestaurantId = 1
	,@DinerDate    = '2020-08-17'
	,@NbrGuests    = 5;