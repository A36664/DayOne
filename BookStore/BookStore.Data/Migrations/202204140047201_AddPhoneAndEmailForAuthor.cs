namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneAndEmailForAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "PhoneNumber", c => c.String(maxLength: 11));
            AddColumn("dbo.Authors", "Email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Email");
            DropColumn("dbo.Authors", "PhoneNumber");
        }
    }
}
