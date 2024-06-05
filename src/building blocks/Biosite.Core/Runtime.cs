namespace Biosite.Core
{
    public static class Runtime
    {
        public static string ConnectionString = "Server=appdbtest.mssql.somee.com;Database=appdbtest;User ID=carlospereira_SQLLogin_2;Password=4z6ql1a891;";
        public static string JwtSecretKey = "T`XN;|OL'T_.-cr7854154rztyi[sHle}6eCE]F>Ek]o/-5727-6450244d15-b787-c6bbbb-ZU2o!>+Y~=D;%Y;ox3/=(_M=x0S";
        public static string Audience = "https://homolog-apix.biosite.com/";
        public static string Issuer = "https://homolog-apix.biosite.com/";
        public static int ExpiresInMinutes = 120;
    }
}