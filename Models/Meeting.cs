using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sacrament_Meeting_Planner.Models
{
    public class Meeting
    {
        public int Id
        {
            get; set;
        }

        [DataType(DataType.Date)]
        [Display(Name = "Meeting Day")]
        public DateTime Date
        {
            get; set;
        }

        [Required]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Letters and spaces only")]
        public string? Presiding
        {
            get; set;
        }

        [Required]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Letters and spaces only")]
        public string? Conducting
        {
            get; set;
        }

        [Required]
        [Display(Name = "Opening Hymn")]
        [RegularExpression(@"#[0-9]{1,3}\s[A-Za-z ]+", ErrorMessage = "Number Sign, then 1-3 digits, then space, then hymn title")]
        public string? OpeningHymn
        {
            get; set;
        }

        [Required]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Letters and spaces only")]
        public string? Invocation
        {
            get; set;
        }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        [RegularExpression(@"#[0-9]{1,3}\s[A-Za-z ]+", ErrorMessage = "Number Sign, then 1-3 digits, then space, then hymn title")]
        public string? SacramentHymn
        {
            get; set;
        }

        [Display(Name = "Intermediate Hymn")]
        [RegularExpression(@"#[0-9]{1,3}\s[A-Za-z ]+", ErrorMessage = "Number Sign, then 1-3 digits, then space, then hymn title")]
        public string? IntermediateHymn
        {
            get; set;
        }

        [Required]
        [Display(Name = "Closing Hymn")]
        [RegularExpression(@"#[0-9]{1,3}\s[A-Za-z ]+", ErrorMessage = "Number Sign, then 1-3 digits, then space, then hymn title")]
        public string? ClosingHymn
        {
            get; set;
        }

        [Required]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Letters and spaces only")]
        public string? Benediction
        {
            get; set;
        }

        [Required]
        [Display(Name = "Speakers' topic")]
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Letters and spaces only")]
        public string? SpeakerSubject
        {
            get; set;
        }

        [NotMapped]
        [BindNever]
        public string? NewSpeaker {get;set;}
        // Navigation property for Speakers
        public List<Speaker> Speakers { get; set; } = new List<Speaker>();
    }

    public class Speaker
    {
        public int Id
        {
            get; set;
        }
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "Letters and spaces only")]
        public string Name
        {
            get; set;
        }

        // Foreign key for Meeting
        public int MeetingId
        {
            get; set;
        }

        // Navigation property for Meeting
        public Meeting Meeting
        {
            get; set;
        }
    }
}
