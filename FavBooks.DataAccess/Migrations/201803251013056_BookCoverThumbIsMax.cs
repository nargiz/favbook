namespace FavBooks.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookCoverThumbIsMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "CoverThumb", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "CoverThumb", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
