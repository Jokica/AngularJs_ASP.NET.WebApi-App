CREATE TABLE [dbo].[PancakeIngredients] (
    [Id]           BIGINT IDENTITY (1, 1) NOT NULL,
    [IngredientId] BIGINT NOT NULL,
    [PancakeId]    BIGINT NOT NULL,
    CONSTRAINT [PK_dbo.PancakeIngredients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.CoffeIngredients_dbo.Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.PancakeIngredients_dbo.Pancakes_PancakeId] FOREIGN KEY ([PancakeId]) REFERENCES [dbo].[Pancakes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PancakeId]
    ON [dbo].[PancakeIngredients]([PancakeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IngredientId]
    ON [dbo].[PancakeIngredients]([IngredientId] ASC);

