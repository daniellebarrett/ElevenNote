namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    CategoryName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.CategoryId);

        }

        public override void Down()
        {
            DropTable("dbo.Category");
        }
    }
}
