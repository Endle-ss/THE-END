//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POLNIY_TRESH_PROISHODIT_NIKTO_NICHEGO_NE_PONIMAET
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grades
    {
        public int GradeID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> ScheduleID { get; set; }
        public Nullable<decimal> Grade { get; set; }
    
        public virtual Schedule Schedule { get; set; }
        public virtual Students Students { get; set; }
    }
}
