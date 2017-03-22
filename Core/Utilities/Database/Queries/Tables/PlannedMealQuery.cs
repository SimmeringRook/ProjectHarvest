﻿using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Core.Utilities.Database.Queries.Tables
{
    public class PlannedMealQuery : IHarvestQuery
    {
        public object Get(object itemID, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            if (itemID is int)
                return HarvestDatabase.PlannedMeals.ToList();
            DateTime day = (DateTime) itemID;
            return HarvestDatabase.PlannedMeals.Where(plannedMeal => DbFunctions.TruncateTime(plannedMeal.DatePlanned) == DbFunctions.TruncateTime(day)).ToList();
        }

        public void Insert(object itemToAdd, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            HarvestDatabase.PlannedMeals.Add(itemToAdd as PlannedMeals);
            HarvestDatabase.SaveChanges();
        }

        public void Remove(object itemToRemove, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            HarvestDatabase.PlannedMeals.Remove(itemToRemove as PlannedMeals);
            HarvestDatabase.SaveChanges();
        }

        public void Update(object itemToChange, HarvestEntities HarvestDatabase)
        {
            HarvestDatabase.PlannedMeals.Load();
            HarvestDatabase.PlannedMeals.AddOrUpdate(itemToChange as PlannedMeals);
            HarvestDatabase.SaveChanges();
        }
    }
}