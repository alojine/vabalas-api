namespace vabalas_api.Enums;

public enum OfferStatus
{
    Pending,
    Accepted,
    Declined,
    Deprecated
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
}