namespace ExampleCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatetabletblUserProfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Image = c.String(nullable: false, maxLength: 128),
                        Telephone = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblUserProfiles");
        }
    }
}
