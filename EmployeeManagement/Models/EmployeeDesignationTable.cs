//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeDesignationTable
    {
        public EmployeeDesignationTable()
        {
            this.EmployeeDetailsTables = new HashSet<EmployeeDetailsTable>();
        }
    
        public int S_No { get; set; }
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public string GradeLevel { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
    
        public virtual ICollection<EmployeeDetailsTable> EmployeeDetailsTables { get; set; }
    }
}
