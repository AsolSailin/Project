//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Polyclinic.ADOApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointments
    {
        public int Id { get; set; }
        public int DiagnosisId { get; set; }
        public int TreatmentId { get; set; }
    
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
