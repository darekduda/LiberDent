using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.Intranet.Views
{
    public static class ManageNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Index => "Index";

        public static string ChangePassword => "ChangePassword";

        public static string OptionalInformation => "OptionalInformation";

        public static string ExternalLogins => "ExternalLogins";

        public static string TwoFactorAuthentication => "TwoFactorAuthentication";
        public static string DaneUzytkownika => "DaneUzytkownika";
        public static string DaneAdresowe => "DaneAdresowe";
        public static string DaneLekarza => "DaneLekarza";
        public static string MojeWizyty => "MojeWizyty";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string OptionalInformationNavClass(ViewContext viewContext) => PageNavClass(viewContext, OptionalInformation);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
        public static string DaneUzytkownikaNavClass(ViewContext viewContext) => PageNavClass(viewContext, DaneUzytkownika);
        public static string DaneAdresoweNavClass(ViewContext viewContext) => PageNavClass(viewContext, DaneAdresowe);
        public static string DaneLekarzaNavClass(ViewContext viewContext) => PageNavClass(viewContext, DaneLekarza);
        public static string MojeWizytyNavClass(ViewContext viewContext) => PageNavClass(viewContext, MojeWizyty);
    }
}
