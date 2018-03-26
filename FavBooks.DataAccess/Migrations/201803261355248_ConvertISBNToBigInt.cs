namespace FavBooks.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertISBNToBigInt : DbMigration
    {
        public override void Up()
        {
            //Test data, no need to migrate
            Sql("DELETE FROM Favourites");
            Sql("DELETE FROM Books");

            DropForeignKey("dbo.Favourites", "ISBN", "dbo.Books");
            DropIndex("dbo.Favourites", new[] { "ISBN" });
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Favourites");
            AlterColumn("dbo.Books", "ISBN", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Favourites", "ISBN", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Books", "ISBN");
            AddPrimaryKey("dbo.Favourites", new[] { "UserId", "ISBN" });
            CreateIndex("dbo.Favourites", "ISBN");
            AddForeignKey("dbo.Favourites", "ISBN", "dbo.Books", "ISBN");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "ISBN", "dbo.Books");
            DropIndex("dbo.Favourites", new[] { "ISBN" });
            DropPrimaryKey("dbo.Favourites");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Favourites", "ISBN", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 13));
            AddPrimaryKey("dbo.Favourites", new[] { "UserId", "ISBN" });
            AddPrimaryKey("dbo.Books", "ISBN");
            CreateIndex("dbo.Favourites", "ISBN");
            AddForeignKey("dbo.Favourites", "ISBN", "dbo.Books", "ISBN");
        }
    }
}
