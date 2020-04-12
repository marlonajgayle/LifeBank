namespace LifeBank.Api.Routes.Version1
{
    public static class ApiRoutes
    {
        public const string Domain = "api";
        public const string Version = "v1";
        public const string Base = Domain + "/" + Version;

        public static class Donors
        {
            public const string Create = Base + "/donors";
            public const string Get = Base + "/donors/{donorId}";
            public const string GetAll = Base + "/donors";
            public const string Update = Base + "/donors/{donorId}";
            public const string Delete = Base + "/donors/{donorId}";

        }

        public static class Donations
        {
            public const string Create = Base + "/donations";
            public const string Get = Base + "/donations/{donationId}";
            public const string GetAll = Base + "/donations";
            public const string Update = Base + "/donations/{donationId}";
            public const string Delete = Base + "/donations/{donationId}";
        }

        public static class Appointments
        {
            public const string Create = Base + "/appointments";
            public const string Get = Base + "/appointments/{appointmentId}";
            public const string GetAll = Base + "/appointments";
            public const string Update = Base + "/appointments/{appointmentId}";
            public const string Delete = Base + "/appointments/{appointmentId}";
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

        public static class Recovery
        {
            public const string ForgotPassword = Base + "/ForgotPassword";
        }

        public static class Change
        {
            public const string Password = Base + "/ChangePassword";
        }
    }
}