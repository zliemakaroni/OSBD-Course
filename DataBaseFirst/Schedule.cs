//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public int Id { get; set; }
        public int Group_Id { get; set; }
        public int Day_Id { get; set; }
        public int Auditory_Id { get; set; }
        public int Teacher_Id { get; set; }
        public int Subject_Id { get; set; }
        public int LessonType_Id { get; set; }
        public int Lesson_Id { get; set; }
    
        public virtual Auditories Auditories { get; set; }
        public virtual Days Days { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual Lessons Lessons { get; set; }
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
        public virtual Types_Of_Lessons Types_Of_Lessons { get; set; }
    }
}
