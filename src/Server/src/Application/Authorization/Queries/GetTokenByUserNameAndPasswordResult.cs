namespace QueueManagementSystem.Application.Authorization.Queries
{
    public class GetTokenByUserNameAndPasswordResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }

        public static GetTokenByUserNameAndPasswordResult Failure()
        {
            return new GetTokenByUserNameAndPasswordResult
            {
                IsSuccess = false,
                ErrorMessage = "Login or password is wrong!"
            };
        }

        public static GetTokenByUserNameAndPasswordResult Success(string token, string email)
        {
            return new GetTokenByUserNameAndPasswordResult
            {
                IsSuccess = true,
                Token = token,
            };
        }
    }
}