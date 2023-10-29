using Microsoft.IdentityModel.Tokens;
using vabalas_api.Enums;

namespace vabalas_api.Utils
{
    public static class JobCategoryHelper
    {
        
        public static JobCategory ParseToEnum(string category)
        {

            foreach (JobCategory jobCategory in Enum.GetValues(typeof(JobCategory)))
            {
                Console.WriteLine(jobCategory);
                if(category == jobCategory.ToString())
                {
                    return jobCategory;
                }
            }
            return JobCategory.OTHER;
        }
    }
}
