﻿namespace Bank.Application.Endpoints;

public static partial class Endpoints
{
    public const string ApiBase = "api/v1";
}

#region User Service

public static partial class Endpoints
{
    public static class User
    {
        public const string Base = $"{ApiBase}/users";

        public const string GetAll        = $"{Base}";
        public const string GetOne        = $"{Base}/{{id:guid}}";
        public const string Login         = $"{Base}/login";
        public const string Activate      = $"{Base}/activate";
        public const string PasswordReset = $"{Base}/password-reset";
    }
}

public static partial class Endpoints
{
    public static class Employee
    {
        public const string Base = $"{ApiBase}/employees";

        public const string GetAll = $"{Base}";
        public const string Create = $"{Base}";
        public const string GetOne = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
    }
}

public static partial class Endpoints
{
    public static class Client
    {
        public const string Base = $"{ApiBase}/clients";

        public const string GetAll = $"{Base}";
        public const string Create = $"{Base}";
        public const string GetOne = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
    }
}

#endregion
