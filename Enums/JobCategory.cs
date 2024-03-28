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

    public static String ToString(JobCategory jobCategory)
    {
        var category = jobCategory switch
        {
            JobCategory.Construction => "Construction",
            JobCategory.Gardening => "Gardening",
            JobCategory.Vehicles => "Vehicles",
            JobCategory.Technology => "Technology",
            _ => "Other"
        };

        return category;
    }
}


