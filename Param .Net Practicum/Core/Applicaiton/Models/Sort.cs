namespace Param_.Net_Practicum.Core.Applicaiton.Models
{
    /// <summary>
    /// Class developed for sorting in dynamic filtering
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Property that specifies which column the dynamic sorting will take place in
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Property that specifies the type of dynamic sorting
        /// </summary>
        public string SortingType { get; set; }
    }
}