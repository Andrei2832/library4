//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace library
{
    using System;
    using System.Collections.Generic;
    
    public partial class lectureCustomer
    {
        public int idCustomer { get; set; }
        public int idLecture { get; set; }
        public int Passed { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}
