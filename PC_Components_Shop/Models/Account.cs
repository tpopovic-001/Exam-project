//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PC_Components_Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Account 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int AccountID { get; set; }
        [Required(ErrorMessage ="The Username field is required and cannot be empty!")]
        [StringLength(30,ErrorMessage ="Username cannot be longer than 30 characters!")]
        [RegularExpression(@"^[a-zA-Z]+[0-9]*$", ErrorMessage = "Username can contain only letters and, optionally, numbers at the end")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password field is required and cannot be empty!")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long!")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one number, and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Email Address field is required and cannot be empty!")]
        [StringLength(255,ErrorMessage ="Email Address cannot be longer than 255 characters!")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage ="First name field is required and cannot be empty!")]
        [StringLength(20,ErrorMessage = "First name cannot be longer than 20 characters!")]
        [RegularExpression(@"^[A-Z][a-z]+$",ErrorMessage = "First name is not in a correct format!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name field is required and cannot be empty!")]
        [StringLength(20, ErrorMessage = "Last name cannot be longer than 20 characters!")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Last name is not in a correct format!")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Date of birth field is required and must be populated!")]
        public System.DateTime DOB { get; set; }
        public System.DateTime DateOfRegistration { get; set; }
        public Nullable<int> Fk_BillingAddress { get; set; }
        public Nullable<int> Fk_ShippingAddress { get; set; }
        public int Fk_AccountTypeID { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Address Address1 { get; set; }
        public virtual AccountType AccountType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
