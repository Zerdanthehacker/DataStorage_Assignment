﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string ProjectName { get; set; } = null!;

        public string? ProjectDescription { get; set; } 

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; } 

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; } 

        public int CustomerId { get; set; } 
        public CustomerEntity Customer { get; set; } = null!; 

        public int StatusId { get; set; } 
        public StatusTypeEntity Status { get; set; } = null!; 

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!; 

        public int ProductId { get; set; } 
        public ProductEntity Product { get; set; } = null!;
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
