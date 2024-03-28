namespace vabalas_api.Enums;

public enum OfferStatus
{
    Pending,
    Accepted,
    Declined,
    Deprecated,
}

static class OfferStatusParser
{
    public static OfferStatus ToEnum(string status)
    {
        var offerStatus = status switch
        {
            "Pending" => OfferStatus.Pending,
            "Accepted" => OfferStatus.Accepted,
            "Declined" => OfferStatus.Declined,
            _ => OfferStatus.Deprecated
        };

        return offerStatus;
    }

    public static string ToString(OfferStatus status)
    {
        var offerStatus = status switch
        {
            OfferStatus.Pending => "Pending",
            OfferStatus.Accepted => "Accepted",
            OfferStatus.Declined => "Declined",
            _ => "Deprecated"
        };

        return offerStatus;
    }
}