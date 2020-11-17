namespace SocialNetwork.ModelDTOs.ActionResponse
{
    public class SignInResponse
    {
        [System.ComponentModel.DefaultValue(false)]
        public bool IsSuccesful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
