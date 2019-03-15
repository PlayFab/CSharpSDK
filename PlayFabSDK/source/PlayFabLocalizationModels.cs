using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.LocalizationModels
{
    public class GetLanguageListRequest : PlayFabRequestCommon
    {
    }

    public class GetLanguageListResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of allowed languages, in BCP47 two-letter format
        /// </summary>
        public List<string> LanguageList ;

    }
}
