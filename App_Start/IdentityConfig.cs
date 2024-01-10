using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

public class IdentityConfig
{
    public void Configuration(IAppBuilder app)
    {
        // Identity yapılandırma kodları buraya gelecek
        ConfigureAuth(app);
    }

    public void ConfigureAuth(IAppBuilder app)
    {
        // Bu metod içinde Identity ve CookieAuthentication konfigürasyonları yapılacak
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
        });

        // Diğer yapılandırmalar buraya eklenebilir
    }
}
