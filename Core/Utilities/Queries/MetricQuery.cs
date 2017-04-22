﻿using Core.Adapters.Database;
using Core.Utilities.UnitConversions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Core.Utilities.Queries
{
    internal class MetricQuery : IHarvestQuery
    {

        public object Get(object itemID, HarvestDatabaseEntities HarvestDatabase)
        {
            HarvestDatabase.Metric.Load();
            List<MeasurementUnit> metrics = new List<MeasurementUnit>();
            foreach (Metric unit in HarvestDatabase.Metric.ToList())
                metrics.Add((MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), unit.Measurement));
            return metrics;
        }

        public void Insert(object itemToAdd, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Remove(object itemToRemove, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }

        public void Update(object itemToChange, HarvestDatabaseEntities HarvestDatabase)
        {
            throw new NotImplementedException();
        }
    }
}