namespace LifeBank.Api.Routes.Version1
{
    public static class ApiRoutes
    {
        public const string Domain = "api";
        public const string Verion = "v1";
        public const string Base = "${api}/${Version}";

        public static class Donors
        {
            public const string Create = "${base}" + "/donor";
            public const string Get = "${base}" + "/donor/{donorId}";
        }
    }
}