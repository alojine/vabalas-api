namespace vabalas_api.Enums;

public enum JobCategory
{
    Construction,
    Gardening,
    Vehicles,
    Technology,
    Other
}

static class JobCatogryParser
{
    public static JobCategory ToEnum(string category)
    {
        var jobCategory = category switch
        {
            "Construction" => JobCategory.Construction,
            "Gardening" => JobCategory.Gardening,
            "Vehicles" => JobCategory.Vehicles,
            "Technology" => JobCategory.Technology,
            _ => JobCategory.Other
        };

        return jobCategory;
    }
}


