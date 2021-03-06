﻿using System;
using System.Text.Json.Serialization;

namespace Training.CodersAcademy.MusicApp.Api.Models
{
    /// <summary>
    /// Music model.
    /// </summary>
    public class Music
    {
        /// <summary>
        /// Id of the music.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the music.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Duration of the music in seconds.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Id of the album this music belongs to.
        /// </summary>
        public Guid AlbumId { get; set; }
        /// <summary>
        /// The album this music belongs to.
        /// </summary>
        [JsonIgnore]
        public Album Album { get; set; }
    }
}
