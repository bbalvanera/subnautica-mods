using BulkCraft.Helpers;
using Nautilus.Crafting;
using System;

namespace BulkCraft.Shared;

public static class RecipeDataExtensions
{
    public static int GetMaxCraftAmount(this RecipeData recipeData)
    {
        if (recipeData == null)
            return 0;

        int maxAmount = int.MaxValue;
        if (GameModeUtils.RequiresIngredients())
        {
            foreach (var ing in recipeData.Ingredients)
                maxAmount = Math.Min(maxAmount, GetAvailableCount(ing.techType) / ing.amount);
        }

        return maxAmount;
    }

    private static int GetAvailableCount(TechType techType) => EasyCraft.GetPickupCount(techType) ?? Inventory.main.GetPickupCount(techType);
}