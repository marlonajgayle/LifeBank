namespace LifeBank.Api.Routes.Version1
{
    public static class ApiRoutes
    {
        public const string Domain = "api";
        public const string Verion = "v1";
        public const string Base = "${api}/${Version}";

        public static class Donors
        {
            public const string Create = Base + "/donors";
            public const string Get = Base + "/donors/{donorId}";
            public const string GetAll = Base + "/donors";
            public const string Update = Base + "/donors/{donorId}";
            public const string Delete = Base + "/donors/{donorId}";

        }

        public static class Registration
        {
            public const string Register = Base + "/register";
        }

        public static class Auth
        {
            public const string Login = Base + "/Login";
            public const string Logout = Base + "/Logout";
        }
    }
}