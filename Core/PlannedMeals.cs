//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlannedMeals
    {
        public System.DateTime DatePlanned { get; set; }
        public string MealName { get; set; }
        public int RecipeID { get; set; }
        public bool MealEaten { get; set; }
    
        public virtual MealTime MealTime { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
