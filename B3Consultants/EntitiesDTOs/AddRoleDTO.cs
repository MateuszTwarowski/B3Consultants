﻿using System.ComponentModel.DataAnnotations;

namespace B3Consultants.EntitiesDTOs
{
    public class AddRoleDTO
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string RoleTitle { get; set; }
    }
}
