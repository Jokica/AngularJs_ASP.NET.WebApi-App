using InvestMent.DAL.Exeptions;
using InvestMent.Domain.Interfaces.DAL;
using InvestMent.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InvestMent.DAL.Converts
{
    public static class Converter
    {
        public static IDataEntity Convert(this IDomainEntity entity)
        {
            switch (entity)
            {
                case Domain.Models.Brand b:
                    return ToBrand(b);
                case Domain.Models.Ingredient I:
                    return ToIngredient(I);
                case Domain.Models.IngredientType It:
                    return ToIngredientType(It);
                case Domain.Models.Pancake p:
                    return ToPancake(p);
                case Domain.Models.PancakeIngredients Pi:
                    return ToPancakeIngredients(Pi);
                default:
                    throw new InvalidDomainEntity();
            }
        }

        private static IDataEntity ToPancakeIngredients(PancakeIngredients pi)
        {
            return new Persistence.DBFirstApproach.PancakeIngredient
            {
                Id = pi.Id,
                IngredientId = pi.IngredientId,
                PancakeId = pi.PancakeId
            };
        }

        private static IDataEntity ToPancake(Pancake p)
        {
            var list = p.Ingredients.Select(x => x.Convert() as Persistence.DBFirstApproach.PancakeIngredient).ToList();
            return new Persistence.DBFirstApproach.Pancake
            {
                Id = p.Id,
                ImageURL = p.ImageURL,
                Name = p.Name,
                PancakeIngredients = list
            };
        }

        private static IDataEntity ToIngredientType(IngredientType it)
        {
            var list = it.Ingredients.Select(x => x.Convert() as Persistence.DBFirstApproach.Ingredient).ToList();
            return new Persistence.DBFirstApproach.IngredientType
            {
                Id = it.Id,
                Ingredients = list,
                Name = it.Name
            };
        }

        private static IDataEntity ToIngredient(Ingredient i)
        {
            return new Persistence.DBFirstApproach.Ingredient
            {
                Id = i.Id,
                Name = i.Name,
                Brand = i.IngredientBrand.Convert() as Persistence.DBFirstApproach.Brand,
                IngredientBrandId = i.IngredientBrandId,
                IngredientType = i.Type.Convert() as Persistence.DBFirstApproach.IngredientType,
                TypeId = i.TypeId
            };
        }

        private static IDataEntity ToBrand(Brand b)
        {
            return new Persistence.DBFirstApproach.Brand
            {
                Id = b.Id,
                Name = b.Name
            };
        }
    }
}
