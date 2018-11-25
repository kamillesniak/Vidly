namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAgain : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7762cc1b-9602-490a-96aa-692685cf1cea', N'janusz@teste213234.com', 0, N'AM964JPCRszz40GqhIZ2RuYRjt5T5akqZbSsR95+te2zCZ1KZ/PqxctqStyVcaBhJA==', N'a359353f-c3ec-4d64-b8c4-51b3f89d31d2', NULL, 0, 0, NULL, 1, 0, N'janusz@teste213234.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e4163968-184e-43e0-ba3a-54ad8f2cdde9', N'admin@vidlytesthehe.pl', 0, N'AG+awhfOFJvFlEBuGQG+kVgmek0T0vY+oxTIe+Bm9PfUFff+F+Aa3fywMAhrvA9RGA==', N'0dd74f79-3f19-4a51-8079-096906ceefd1', NULL, 0, 0, NULL, 1, 0, N'admin@vidlytesthehe.pl')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'25fbc93a-ec86-42e2-ae8f-4404e9343e5b', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7762cc1b-9602-490a-96aa-692685cf1cea', N'25fbc93a-ec86-42e2-ae8f-4404e9343e5b')

");
        }
        
        public override void Down()
        {
        }
    }
}
