using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoSeplag.Domain.Updates.Entitys
{
    public class UpdateEntity
    {
        public UpdateEntity(string Id, string Alias, string DocumentTitle, string Severity,
            DateTime InitialReleaseDate, DateTime CurrentReleaseDate, Uri CvrfUrl)
        {
            this.ID = Id;
            this.Alias = Alias;
            this.DocumentTitle = DocumentTitle;
            this.Severity = Severity;
            this.InitialReleaseDate = InitialReleaseDate;
            this.CurrentReleaseDate = CurrentReleaseDate;
            this.CvrfUrl = CvrfUrl;
        }

        // contrutor para utilização do entity
        protected UpdateEntity()
        {

        }

        [Key]
        public string ID { get; private set; }

        public string Alias { get; private set; }
        public string DocumentTitle { get; private set; }

        public string Severity { get; private set; }

        public DateTime InitialReleaseDate { get; private set; }

        public DateTime CurrentReleaseDate { get; private set; }

        public Uri CvrfUrl { get; private set; }
    }
}
