using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreIdentityCustom.Controllers
{
    public class UserProfileController : Controller
    {
        public ActionResult Index()
        {
            UserProfile userProfile = GetUserProfileData();
            return View(userProfile);
        }

        private UserProfile GetUserProfileData()
        {
            UserProfile userProfile = new UserProfile
            {
                UserName = "GBRHFJ",
                FullName = "Örnek Kullanıcı",
                Biography = "Bu bir örnek kullanıcı profili.",
                ProfilePictureUrl = "https://example.com/profile-picture.jpg",
            };
            return userProfile;
        }
    }
}
