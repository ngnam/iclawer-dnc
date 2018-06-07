using System;
using System.Collections.Generic;
using System.Text;

namespace Services.RegEmail
{
    public interface IRegEmailService
    {
        void GenerateListEmail(int Count, string prefix);
        void RegEmail(RegEmail regEmail);
        int RegListEmail(IList<RegEmail> regEmails);
    }
}
