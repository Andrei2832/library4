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
    
    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            this.testsCustomer = new HashSet<testsCustomer>();
        }
    
        public int idTest { get; set; }
        public int idLecture { get; set; }
        public string Question { get; set; }
        public string answerOption_1 { get; set; }
        public string answerOption_2 { get; set; }
        public string answerOption_3 { get; set; }
        public string answerOption_4 { get; set; }
    
        public virtual Lecture Lecture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<testsCustomer> testsCustomer { get; set; }
    }
}
