namespace SocialNetwork.ModelDTOs.ActionResponse
{
    public abstract class Response
    {
        [System.ComponentModel.DefaultValue(false)]
        public bool IsSuccesful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
