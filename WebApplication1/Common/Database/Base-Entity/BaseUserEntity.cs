﻿using CourseWork.Common.database.Base_Model;
using System.ComponentModel.DataAnnotations;
namespace CourseWork.Common.Database.Base_Entity
{
    public class BaseUserEntity : BaseEntity
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Password { get; set; }

        public bool? IsActive { get; set; }

        public BaseUserEntity()
        {
            IsActive = false;
        }
    }
}
