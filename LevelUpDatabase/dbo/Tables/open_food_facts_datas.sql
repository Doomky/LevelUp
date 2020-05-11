CREATE TABLE [dbo].[open_food_facts_datas] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [code]    VARCHAR(50)           NOT NULL,
    [name]    VARCHAR (255) NOT NULL,
    [energy_100g] FLOAT NULL, 
    [sodium_100g] FLOAT NULL, 
    [salt_100g] FLOAT NULL, 
    [fat_100g] FLOAT NULL, 
    [saturated-fat_100g] FLOAT NULL, 
    [proteins_100g] FLOAT NULL, 
    [sugars_100g] FLOAT NULL, 
    [energy_serving] FLOAT NULL, 
    [sodium_serving] FLOAT NULL, 
    [salt_serving] FLOAT NULL, 
    [fat_serving] FLOAT NULL, 
    [saturated-fat_serving] FLOAT NULL, 
    [proteins_serving] FLOAT NULL, 
    [sugars_serving] FLOAT NULL, 
    [img_url] VARCHAR(255) NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC)
);

