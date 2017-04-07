CREATE TABLE [dbo].[IngredientCategory] (
    [Category] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED ([Category] ASC)
);

GO

CREATE TABLE [dbo].[Inventory] (
    [InventoryID]    INT          IDENTITY (1, 1) NOT NULL,
    [IngredientName] VARCHAR (25) NOT NULL,
    [Category]       VARCHAR (20) NOT NULL,
    [Amount]         FLOAT (53)   NOT NULL,
    [Measurement]    VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED ([InventoryID] ASC),
    CONSTRAINT [FK_Inventory_Metric] FOREIGN KEY ([Measurement]) REFERENCES [dbo].[Metric] ([Measurement]),
    CONSTRAINT [FK_Inventory_FoodType] FOREIGN KEY ([Category]) REFERENCES [dbo].[IngredientCategory] ([Category])
);

GO

CREATE TABLE [dbo].[LastLaunched] (
    [Date] DATE NOT NULL,
    CONSTRAINT [PK_LastLaunched] PRIMARY KEY CLUSTERED ([Date] ASC)
);

GO

CREATE TABLE [dbo].[MealHistory] (
    [MealName]  VARCHAR (25) NOT NULL,
    [RecipeID]  INT          NOT NULL,
    [DateEaten] DATE         NOT NULL,
    CONSTRAINT [PK_MealHistory] PRIMARY KEY CLUSTERED ([MealName] ASC, [RecipeID] ASC, [DateEaten] ASC),
    CONSTRAINT [FK_MealHistory_MealTime] FOREIGN KEY ([MealName]) REFERENCES [dbo].[MealTime] ([MealName]),
    CONSTRAINT [FK_MealHistory_Recipe] FOREIGN KEY ([RecipeID]) REFERENCES [dbo].[Recipe] ([RecipeID])
);

GO

CREATE TABLE [dbo].[MealTime] (
    [MealName] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_MealTime] PRIMARY KEY CLUSTERED ([MealName] ASC)
);

GO

CREATE TABLE [dbo].[Metric] (
    [Measurement] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Metric] PRIMARY KEY CLUSTERED ([Measurement] ASC)
);

GO

CREATE TABLE [dbo].[PlannedMeals] (
    [DatePlanned] DATE         NOT NULL,
    [MealName]    VARCHAR (25) NOT NULL,
    [RecipeID]    INT          NOT NULL,
    [MealEaten]   BIT          NOT NULL,
    CONSTRAINT [PK_Recipe_MealTime] PRIMARY KEY CLUSTERED ([DatePlanned] ASC, [MealName] ASC, [RecipeID] ASC),
    CONSTRAINT [FK_MealTime] FOREIGN KEY ([MealName]) REFERENCES [dbo].[MealTime] ([MealName]),
    CONSTRAINT [FK_Recipe] FOREIGN KEY ([RecipeID]) REFERENCES [dbo].[Recipe] ([RecipeID])
);

GO

CREATE TABLE [dbo].[Recipe] (
    [RecipeID]   INT          IDENTITY (1, 1) NOT NULL,
    [RecipeName] VARCHAR (20) NOT NULL,
    [Servings]   FLOAT (53)   NOT NULL,
    [RCategory]  VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED ([RecipeID] ASC),
    CONSTRAINT [FK_Recipe_RecipeClass] FOREIGN KEY ([RCategory]) REFERENCES [dbo].[RecipeClass] ([RCategory])
);

GO

CREATE TABLE [dbo].[RecipeClass] (
    [RCategory] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_RecipeClass] PRIMARY KEY CLUSTERED ([RCategory] ASC)
);

GO

CREATE TABLE [dbo].[RecipeIngredient] (
    [RecipeID]    INT          NOT NULL,
    [InventoryID] INT          NOT NULL,
    [Amount]      FLOAT (53)   NOT NULL,
    [Measurement] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Recipe_Inventory] PRIMARY KEY CLUSTERED ([RecipeID] ASC, [InventoryID] ASC),
    CONSTRAINT [FK_Recipe_Inventory_Metric] FOREIGN KEY ([Measurement]) REFERENCES [dbo].[Metric] ([Measurement]),
    CONSTRAINT [FK_Recipe_Inventory_Inventory] FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[Inventory] ([InventoryID]),
    CONSTRAINT [FK_Recipe_Inventory_Recipe] FOREIGN KEY ([RecipeID]) REFERENCES [dbo].[Recipe] ([RecipeID])
);

GO