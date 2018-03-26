namespace FavBooks.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAutoIncrementFromBooksISBN : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favourites", "ISBN", "dbo.Books");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "ISBN", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Books", "ISBN");
            AddForeignKey("dbo.Favourites", "ISBN", "dbo.Books", "ISBN");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "ISBN", "dbo.Books");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "ISBN", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "ISBN");
            AddForeignKey("dbo.Favourites", "ISBN", "dbo.Books", "ISBN");
        }
    }
}
