using System.Text.Json.Serialization;

namespace API.Domain.Models.Core
{
    public class AuthMenusViewModel
    {
        /// <summary>
        ///  Title
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Menu Icon
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Menu Info
        /// </summary>
        [JsonIgnore]
        public string? MenuInfo { get; set; }

        /// <summary>
        /// Menu Link
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Can Add
        /// </summary>
        [JsonIgnore]
        public bool? CanAdd { get; set; }

        /// <summary>
        /// Can Edit
        /// </summary>
        [JsonIgnore]
        public bool? CanEdit { get; set; }

        /// <summary>
        /// Can Delete
        /// </summary>
        [JsonIgnore]
        public bool? CanDelete { get; set; }

        /// <summary>
        /// Can View
        /// </summary>
        [JsonIgnore]
        public bool? CanView { get; set; }

        /// <summary>
        /// Application Menu GUID
        /// </summary>
        [JsonIgnore]
        public Guid? ApplicationMenuGUID { get; set; }

        /// <summary>
        /// Parent Application Menu GUID
        /// </summary>
        [JsonIgnore]
        public Guid? ParentApplicationMenuGUID { get; set; }

        /// <summary>
        /// Auth Menu Web View Model
        /// </summary>
        public List<AuthMenusViewModel>? Children { get; set; }
    }
}
