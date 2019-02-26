namespace InvestMent.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CoffeIngredients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CoffeId = c.Long(nullable: false),
                        IngredientId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coffes", t => t.CoffeId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.CoffeId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Coffes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CoffeBrand_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.CoffeBrand_Id)
                .Index(t => t.CoffeBrand_Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        IngredientBrand_Id = c.Long(),
                        Type_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.IngredientBrand_Id)
                .ForeignKey("dbo.IngredientTypes", t => t.Type_Id)
                .Index(t => t.IngredientBrand_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.IngredientTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CoffeIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Ingredients", "Type_Id", "dbo.IngredientTypes");
            DropForeignKey("dbo.Ingredients", "IngredientBrand_Id", "dbo.Brands");
            DropForeignKey("dbo.CoffeIngredients", "CoffeId", "dbo.Coffes");
            DropForeignKey("dbo.Coffes", "CoffeBrand_Id", "dbo.Brands");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Ingredients", new[] { "Type_Id" });
            DropIndex("dbo.Ingredients", new[] { "IngredientBrand_Id" });
            DropIndex("dbo.Coffes", new[] { "CoffeBrand_Id" });
            DropIndex("dbo.CoffeIngredients", new[] { "IngredientId" });
            DropIndex("dbo.CoffeIngredients", new[] { "CoffeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.IngredientTypes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Coffes");
            DropTable("dbo.CoffeIngredients");
            DropTable("dbo.Brands");
        }
    }
}
