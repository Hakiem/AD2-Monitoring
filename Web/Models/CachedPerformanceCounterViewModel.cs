using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CachedPerformanceCounterViewModel
    {
        public CachedPerformanceCounterViewModel() { }

        public List<MonitorWithStringDates> CustomDictionary { get; set; }
        public SortedDictionary<string, List<TreeViewPropertiesClass>> CustomListFromCachedDictionary { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid date in the format yyyy-mm-dd")]
        [Display(Name = "Date From")]
        public string DtFrom { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid date in the format yyyy-mm-dd")]
        [Display(Name = "Date To")]
        public string DtTo { get; set; }

        public CachedPerformanceCounterViewModel(SortedDictionary<string, List<TreeViewPropertiesClass>> retrievedDictionaryFromCache, List<MonitorWithStringDates> refinedList)
        {
            CustomListFromCachedDictionary = retrievedDictionaryFromCache;
            CustomDictionary = refinedList;
        }
    }
}