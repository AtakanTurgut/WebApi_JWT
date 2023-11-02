# ASP.NET Core 6.0 Web API Security with JSON Web Token (JWT)
```
    Authentication => Kimlik Denetimi
    Authorization  => Yetki Denetimi 
```
```
                    --- UserName & Password ->>
    Api İstemci     <<-         JWT         ---     Api Server 
    (Api Client)    ---   Request + JWT     ->>
```
## Used Packages

Some packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the "Tools > NuGet Package Manager > Package Manager Console".

- [Microsoft.AspNetCore.Authentication.JwtBearer 6.0.23](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
```
    PM>  NuGet\Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 6.0.23
```
- [Microsoft.IdentityModel.Tokens 7.0.3](https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens)
```
    PM>  NuGet\Install-Package Microsoft.IdentityModel.Tokens -Version 7.0.3
```
- [System.IdentityModel.Tokens.Jwt 7.0.3](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt)
```
    PM>  NuGet\Install-Package System.IdentityModel.Tokens.Jwt -Version 7.0.3
```

[Jwt.io](https://jwt.io/)