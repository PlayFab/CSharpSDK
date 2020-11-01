using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.LocalizationModels
{
    public class GetLanguageListRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags ;

    }

    public class GetLanguageListResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of allowed languages, in BCP47 two-letter format
        /// </summary>
        public List<string> LanguageList ;

    }
}
