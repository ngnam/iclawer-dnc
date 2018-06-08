using Services.Infrashstructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.RegEmail
{
    public interface IRegEmailService
    {
        IList<RegEmail> GenerateListEmail(int Count, string prefix);
        ResultResponse<RegEmail> RegEmail(RegEmail regEmail);
        ResultResponse<RegEmail> RegListEmail(IList<RegEmail> regEmails);
    }
}
