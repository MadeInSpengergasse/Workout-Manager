//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2016_06_13_Workout_Manager_ASP.NET_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class workoutstep
    {
        public int ws_id { get; set; }
        public short ws_e_exercise { get; set; }
        public byte ws_w_workout { get; set; }
    
        public virtual exercise exercise { get; set; }
        public virtual workout workout { get; set; }
    }
}