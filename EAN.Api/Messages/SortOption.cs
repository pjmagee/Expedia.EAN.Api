using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAN.Api.Messages
{
    public enum SortOption
    {
        /// <summary>Used only in conjunction with hotelIdList. Returns hotels in the exact order listed in the request.</summary>
        NO_SORT,
        
        /// <summary>The default sort order - returns hotels in the same order as if sort is omitted entirely. Properties within the specified city are ordered above properties in surrounding areas.</summary>
        CITY_VALUE,
        
        /// <summary>Places preferred, best-converting properties at the top.</summary>
        OVERALL_VALUE,

        /// <summary>Places properties with a promo rate or value add above properties not running promotions.</summary>
        PROMO,

        /// <summary>Sorts properties by nightly rate from low to high. The ordering is not perfect due to business/marketing office algorithms applied to property lists accessed by the API. Accurate price sorting is best achieved within your own code after results are received.</summary>
        PRICE,

        /// <summary>Sorts properties by nightly rate from high to low. Expect imperfect sort as detailed above.</summary>
        PRICE_REVERSE,

        /// <summary>Sorts properties by average nightly rate from low to high. Expect imperfect sort as detailed above.</summary>
        PRICE_AVERAGE,

        /// <summary>Sorts by property star rating from high to low.</summary>
        QUALITY,

        /// <summary>Sorts by property star rating from low to high.</summary>
        QUALITY_REVERSE,

        /// <summary>Sorts properties alphabetically</summary>
        ALPHA,

        /// <summary>Sorts based on proximity to the origin point defined via latitude & longitude parameters.</summary>
        PROXIMITY,

        /// <summary>Sorts via postal code, from alphanumerically lower codes to higher codes.</summary>
        POSTAL_CODE,

        /// <summary>If you have an approved TripAdvisor integration, this value will sort results from high to low guest ratings.</summary>
        TRIP_ADVISOR
    }
}
