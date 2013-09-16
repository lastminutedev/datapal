using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataPal.Interfaces;
using DataPal.Repositories;
using System.Runtime.Serialization;

namespace DataPal.Models
{
    public class SitesContext : DbContext
    {
        public SitesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<SimKimNews> SimKimNews { get; set; }
        public DbSet<XTNAd> XTNAds { get; set; }
    }

    [Table("SimKimNews")]
    public class SimKimNews : IArticle
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 50 characters")]
        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public string Text { get; set; }
       
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }

    [Table("XTNAds")]
    public class XTNAd : IArticle
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 50 characters")]
        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }

    [DataContract(Name = "infoPublic")]
    public class InfoPublic
    {
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "creationDate")]
        public DateTime CreationDate { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
        
        public string UserName { get; set; }
    }

    [DataContract(Name = "infoTitlesPublic")]
    public class InfoTitlesPublic
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "creationDate")]
        public DateTime CreationDate { get; set; }

        [DataMember(Name = "name")]
        public string UserName { get; set; }
    }

    [DataContract(Name = "infoImagesPublic")]
    public class InfoImagesPublic
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
      
        [DataMember(Name = "width")]
        public double Width { get; set; }

        [DataMember(Name = "height")]
        public double Height { get; set; }

        [DataMember(Name = "thumbnailLink")]
        public string ThumbnailLink { get; set; }

        [DataMember(Name = "fullSizeLink")]
        public string FullSizeLink { get; set; }
    }
}
