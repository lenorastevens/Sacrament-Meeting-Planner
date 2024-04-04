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
        public DateTime Date
        {
            get; set;
        }

        public string? Presiding
        {
            get; set;
        }
        public string? Conducting
        {
            get; set;
        }

        public string? OpeningHymn
        {
            get; set;
        }

        public string? Invocation
        {
            get; set;
        }

        public string? SacramentHymn
        {
            get; set;
        }

        public string? IntermediateHymn
        {
            get; set;
        }

        public string? ClosingHymn
        {
            get; set;
        }

        public string? Benediction
        {
            get; set;
        }
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
