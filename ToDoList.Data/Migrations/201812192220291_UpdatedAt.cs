namespace ToDoList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Items", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
        }
    }
}
