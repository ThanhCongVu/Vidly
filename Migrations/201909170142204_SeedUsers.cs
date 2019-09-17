namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6cb2b2d6-1b89-4dcc-aef8-6a069a0e2c96', N'guest@vidly.com', 0, N'AA7jBbE8jcf0RuFdfyef+ueASWicQHMRuV2Kd1Qt9chKQtRMvQJQbdIh9SEoJhutPw==', N'a219c299-153f-40dc-9345-dc07c7a731e9', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cdbeb345-cc37-4422-8ef4-3e4c29fe5cec', N'admin@vidly.com', 0, N'AGEHgVU/kgI+j4BrOhBS8d97JkiU7uqqrFvwYs7UqoGp8tt2Kf3HMuarHNF2GbW9aQ==', N'304db688-83c6-4242-834a-041b16fb2a52', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee47bb2c-a41d-4768-8b49-3e6d4e4e1ef1', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cdbeb345-cc37-4422-8ef4-3e4c29fe5cec', N'ee47bb2c-a41d-4768-8b49-3e6d4e4e1ef1')

");
        }
        
        public override void Down()
        {
        }
    }
}
