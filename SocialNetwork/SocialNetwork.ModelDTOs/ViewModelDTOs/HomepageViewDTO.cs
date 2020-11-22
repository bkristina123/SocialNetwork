namespace SocialNetwork.ModelDTOs.ViewModelDTOs
{
    public class HomepageViewDTO
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string TextContent { get; set; }
        public string AuthorProfilePhoto { get; set; }
        public string PhotoContent { get; set; }

    }
}
