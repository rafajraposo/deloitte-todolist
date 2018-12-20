namespace ToDoList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Items", "CreatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
