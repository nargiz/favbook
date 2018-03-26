namespace FavBooks.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookNotRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "CoverThumb", c => c.String());
            AlterColumn("dbo.Books", "Description", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Books", "Subtitle", c => c.String(maxLength: 500));
            AlterColumn("dbo.Books", "Subjects", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Subjects", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Books", "Subtitle", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Books", "CoverThumb", c => c.String(nullable: false));
        }
    }
}
