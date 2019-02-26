namespace InvestMent.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CoffeIngredients", "CoffeId", "dbo.Coffes");
            RenameTable(name: "dbo.Coffes", newName: "Pancakes");
            RenameTable(name: "dbo.CoffeIngredients", newName: "PancakeIngredients");
            DropIndex("dbo.PancakeIngredients", new[] { "CoffeId" });
            AddColumn("dbo.PancakeIngredients", "Pancake_Id", c => c.Long());
            CreateIndex("dbo.PancakeIngredients", "Pancake_Id");
            AddForeignKey("dbo.PancakeIngredients", "Pancake_Id", "dbo.Pancakes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PancakeIngredients", "Pancake_Id", "dbo.Pancakes");
            DropIndex("dbo.PancakeIngredients", new[] { "Pancake_Id" });
            DropColumn("dbo.PancakeIngredients", "Pancake_Id");
            CreateIndex("dbo.PancakeIngredients", "CoffeId");
            AddForeignKey("dbo.CoffeIngredients", "CoffeId", "dbo.Coffes", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.PancakeIngredients", newName: "CoffeIngredients");
            RenameTable(name: "dbo.Pancakes", newName: "Coffes");
        }
    }
}
